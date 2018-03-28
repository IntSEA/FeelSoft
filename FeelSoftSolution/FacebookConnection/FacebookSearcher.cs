using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetworkConnection;

namespace FacebookConnection
{
    public class FacebookSearcher : PublicationSearcher
    {
        private HttpClient client;
        private const int LIMIT_PUBLICATIONS = 100;
        private IList<string> pages;


        public FacebookSearcher(HttpClient client, string credential) : base(credential)
        {
            this.client = client;
            InitializeDefaultPages();

        }

        private void InitializeDefaultPages()
        {
            pages = new List<string>();
            ReadPages();

        }


        private void ReadPages()
        {
            StreamReader sr = new StreamReader("..//..//..//FacebookConnection/Resources/DefaultPages.txt");
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                pages.Add(line);
            }
            sr.Close();
        }

        public FacebookSearcher(HttpClient client) : base()
        {
            this.client = client;
            InitializeDefaultPages();
        }

        public override IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            IList<IPublication> publications = InternalSearch(queriesConfigurations);
            return publications;
        }

        internal IList<IPublication> InternalSearch(IQueryConfiguration queryConfiguration)
        {
            if (queryConfiguration != null)
            {

                IList<IPublication> publications = new List<IPublication>();
                IDictionary<string, string> fields = new Dictionary<string, string>();
                int limitPublications = queryConfiguration.MaxPublicationCount;
                int limitComments = queryConfiguration.MaxResponsesCount;

                queryConfiguration.MaxPublicationCount = 100;            

                SetQueryFields(queryConfiguration, fields);

                if (queryConfiguration.Keywords != null)
                {
                    for (int i = 0; i < queryConfiguration.Keywords.Count; i++)
                    {
                        string keyword = queryConfiguration.Keywords.ElementAt(i);
                        IList<IPublication> partialPublication = TestRequestFeedToGraph(keyword, fields, limitPublications, queryConfiguration);
                        ((List<IPublication>)publications).AddRange(partialPublication);

                    }
                  
                }


                //int totalPublications = queryConfiguration.MaxPublicationCount;
                //if (totalPublications > LIMIT_PUBLICATIONS)
                //{
                //    queryConfiguration.MaxPublicationCount = 100;
                //}
                //SetQueryFields(queryConfiguration, fields);

                //if (queryConfiguration.Keywords != null)
                //{
                //    foreach (var keyword in queryConfiguration.Keywords)
                //    {
                //        IList<IPublication> partialPublication = RequestFeedToGraph(keyword, fields, totalPublications, queryConfiguration);
                //       ((List<IPublication>) publications).AddRange(partialPublication);
                //    }
                //}

                publications = ReorganizeSearches(publications, limitPublications);


                return publications;

            }
            throw new ArgumentNullException("QueryConfiguration: " + queryConfiguration + "was null");
        }



        private IList<IPublication> ReorganizeSearches(IList<IPublication> publications, int maxPublicationCount)
        {
            IList<IPublication> responsePublications = new List<IPublication>();
            if (publications.Count > maxPublicationCount)
            {
                Random random = new Random();

                for (int i = 0; i < maxPublicationCount; i++)
                {
                    int toAdd = random.Next(0, publications.Count);
                    responsePublications.Add(publications[toAdd]);
                    publications.RemoveAt(toAdd);
                }
            }

            return responsePublications;
        }

        private bool Classify(IPublication publication, IQueryConfiguration queryConfiguration)
        {
            bool clasified = ClassifyByDate(publication, queryConfiguration.SinceDate, queryConfiguration.UntilDate);
            return clasified;
        }

        private bool ClassifyByDate(IPublication publication, DateTime sinceDate, DateTime untilDate)
        {
            bool clasified = true;
            if (publication != null)
            {
                if (publication.CreateDate.CompareTo(QueryConfiguration.NONE_DATE) != 0)
                {
                    if (!(publication.CreateDate.CompareTo(sinceDate) >= 0 && publication.CreateDate.CompareTo(untilDate) <= 0))
                    {
                        clasified = false;
                    }
                }
            }

            return clasified;

        }

        internal IList<IPublication> InternalSearch(IList<IQueryConfiguration> queriesConfigurations)
        {

            List<IPublication> publications = new List<IPublication>();
            foreach (var query in queriesConfigurations)
            {
                IList<IPublication> found = InternalSearch(query);
                if (found != null && found.Count > 0)
                {
                    publications.AddRange(found);
                }
            }

            return publications;

        }


        public override IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            return InternalSearch(queryConfiguration);
        }

        private void SetQueryFields(IQueryConfiguration queryConfiguration, IDictionary<string, string> args)
        {
            string max = (queryConfiguration.MaxPublicationCount > 0 ? queryConfiguration.MaxPublicationCount : 500) + "";
            args.Add("limit", max);
            if (queryConfiguration.SearchType == SearchTypes.Popular)
            {
                args["fields"] = "is_popular,";
            }

            if (args.TryGetValue("fields", out string fields))
            {
                args.Add("fields", fields + "message,from,created_time");
            }
            else
            {
                string commentsFields = "";
                if (queryConfiguration.MaxResponsesCount > 0)
                {
                    commentsFields = ",comments.limit(" + queryConfiguration.MaxResponsesCount + "){message,created_time,from,id}";
                }
                args.Add("fields", "message,from,created_time" + commentsFields);

            }
        }

        private IList<IPublication> TestRequestFeedToGraph(string keyword, IDictionary<string, string> args, int totalPublications, IQueryConfiguration queryConfiguration)
        {
            IList<IPublication> publications = null;

            int roundSearchCount = totalPublications / pages.Count;
            int totalPagings = roundSearchCount / 50;

            foreach (var page in pages)
            {
                var request = CreateFeedRequestToGraph(page, "feed", args);
                var task = MakeRequestToGraphAsync(request);
                if (task != null)
                {
                    publications = new List<IPublication>();
                    var jsonResponse = task.Result;

                    if (jsonResponse != null)
                    {
                        bool joinedTotalPublicationsForPage = false;
                        int pages = 0;
                        do
                        {
                            joinedTotalPublicationsForPage = AddPublications(keyword, jsonResponse, publications, roundSearchCount, queryConfiguration);
                            GetNextPublicationsRequest(!joinedTotalPublicationsForPage, jsonResponse);
                            pages++;
                        } while (!joinedTotalPublicationsForPage && pages<totalPagings);
                    }

                }


            }

            return publications;
        }

      

        private bool AddPublications(string keyword, dynamic jsonResponse, IList<IPublication> publications, int totalPublications, IQueryConfiguration queryConfiguration)
        {
           return AddPublications(keyword, jsonResponse, publications, totalPublications, queryConfiguration, null);
        }

        private bool AddPublications(string keyword, dynamic jsonResponse, IList<IPublication> publications, int totalPublications, IQueryConfiguration queryConfiguration, IPublication parentPublication)
        {
            bool totalSearched = true;
            lock (this)
            {
                if (jsonResponse.data == null)
                {
                    throw new ArgumentException("No json data");
                }
                foreach (var item in jsonResponse.data)
                {
                    IPublication publication = ParsePublicationOfJsonResponse(item, queryConfiguration, parentPublication);
                    if (publications.Count <= totalPublications && AuxClassify(keyword, publication, queryConfiguration))
                    {
                        publications.Add(publication);
                        if (publication.Responses != null && publication.Responses.Count > 0)
                        {
                            ((List<IPublication>)publications).AddRange(publication.Responses);
                        }

                    }
                    else if (publication.Responses != null)
                    {
                        foreach (var pu in publication.Responses)
                        {
                            if (publications.Count > totalPublications)
                            {
                                break;
                            }
                           else if (AuxClassify(keyword, pu, queryConfiguration))
                            {
                                publications.Add(pu);
                            }
                        }
                    }else if (publications.Count > totalPublications)
                    {
                        break;
                    }
                   
                   
                }
            }

            totalSearched = publications.Count>= totalPublications;
            return totalSearched;
        }

        private bool AuxClassify(string keyword, IPublication publication, IQueryConfiguration queryConfiguration)
        {
            bool classify = Classify(publication,queryConfiguration);
            bool containWord = ContainKeyword(keyword, publication);
            classify = classify && containWord;
            return classify;

        }

        private bool ContainKeyword(string keyword, IPublication publication)
        {
           
            string message = publication.Message;
            bool contains = message.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
            return contains;
        }

        internal IList<IPublication> RequestFeedToGraph(string user, IDictionary<string, string> args, int totalPublications, IQueryConfiguration queryConfiguration)
        {
            var request = CreateFeedRequestToGraph(user, "feed", args);
            IList<IPublication> publications = null;
            var task = MakeRequestToGraphAsync(request);
            if (task != null)
            {
                publications = new List<IPublication>();
                var jsonResponse = task.Result;

                if (jsonResponse != null)
                {


                    AddPublications(jsonResponse, publications, totalPublications, queryConfiguration);

                    AddNextPagings(totalPublications, publications, jsonResponse, queryConfiguration);
                }

            }
            return publications;

        }

        private void AddNextPagings(int totalPublications, IList<IPublication> publications, dynamic jsonResponse, IQueryConfiguration queryConfiguration)
        {
            bool underlimitFound = publications.Count < totalPublications;


            while (underlimitFound)
            {
                var nextPaging = GetNextPublicationsRequest(underlimitFound, jsonResponse);

                AddPublications(nextPaging, publications, totalPublications, queryConfiguration);

            }

        }

        private dynamic GetNextPublicationsRequest(bool underlimitFound, dynamic jsonResponse)
        {
            dynamic response = default(dynamic);
            if (underlimitFound)
            {
                if (jsonResponse.paging != null)
                {
                    if (jsonResponse.paging.next != null)
                    {
                        string next = (string)jsonResponse.paging.next;
                        response = MakeRequestToGraphAsync(next).Result;
                    }
                }
               
            }
            return response;
        }


        private void AddPublications(dynamic jsonResponse, IList<IPublication> publications, int totalPublications, IQueryConfiguration queryConfiguration)
        {
            AddPublications(jsonResponse, publications, totalPublications, queryConfiguration, null);
        }
        private void AddPublications(dynamic jsonResponse, IList<IPublication> publications, int totalPublications, IQueryConfiguration queryConfiguration, IPublication parentPublication)
        {

            lock (this)
            {
                if (jsonResponse.data == null)
                {
                    throw new ArgumentException("No json data");
                }
                foreach (var item in jsonResponse.data)
                {
                    IPublication publication = ParsePublicationOfJsonResponse(item, queryConfiguration, parentPublication);
                    if (publications.Count <= totalPublications && Classify(publication, queryConfiguration))
                    {
                        publications.Add(publication);
                        if (publication.Responses != null && publication.Responses.Count > 0)
                        {
                            ((List<IPublication>)publications).AddRange(publication.Responses);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private IPublication ParsePublicationOfJsonResponse(dynamic item, IQueryConfiguration queryConfiguration, IPublication parentPublication)
        {

            string id = item.id ?? "Not found";
            DateTime createDate = item.created_time ?? QueryConfiguration.NONE_DATE;
            string message = item.message ?? "Not message";
            string wroteBy = "Not found";
            if (item.from != null)
            {
                wroteBy = (item.from.name + item.from.id);
            }
            IPublication publication = new Publication()
            {
                Id = "Facebook:" + id,
                CreateDate = createDate,
                Message = message,
                WroteBy = wroteBy,
                Parent = parentPublication,

            };

            publication.Responses = GetResponesPublications(item, queryConfiguration, publication);

            return publication;
        }

        private IList<IPublication> GetResponesPublications(dynamic item, IQueryConfiguration queryConfiguration, IPublication publication)
        {
            List<IPublication> responses = null;
            if (item.comments != null)
            {
                int totalComments = queryConfiguration.MaxResponsesCount;
                if (totalComments > 0)
                {
                    responses = new List<IPublication>();
                    AddPublications(item.comments, responses, totalComments, queryConfiguration, publication);
                }
            }

            return responses;
        }

        private async Task<dynamic> MakeRequestToGraphAsync(string request)
        {

            dynamic response = await client.GetAsync(request);

            if (response.ReasonPhrase.Equals("Not Found"))
            {
                return default(dynamic);
            }
            if (!response.IsSuccessStatusCode)
            {
                return default(dynamic);
            }

            var result = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject(result);
        }



        public string MakeTokenRequestToGraphAsync(string request)
        {
            try
            {
                var jsonResponse = MakeRequestToGraphAsync(request).Result;

                return (string)jsonResponse.access_token;
            }catch(Exception e)
            {
                return null;
            }
        }
        private string CreateFeedRequestToGraph(string user, string consult, IDictionary<string, string> fields)
        {
            string reqConsult = $"{consult}?access_token={Credential}";
            reqConsult += GetConsultWithFields(fields);


            string request = user + "/" + reqConsult;

            return request;
        }

        private string GetConsultWithFields(IDictionary<string, string> fields)
        {
            string reqConsult = "";

            if (fields != null)
            {
                ICollection<string> keys = fields.Keys;

                foreach (var key in keys)
                {
                    if (fields.TryGetValue(key, out string value))
                    {
                        reqConsult += "&" + key + "=" + value;
                    }
                }
            }
            return reqConsult;
        }
    }
}