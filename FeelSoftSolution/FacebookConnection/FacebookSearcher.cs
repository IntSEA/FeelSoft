using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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

                int totalPublications = queryConfiguration.MaxPublicationCount;

                if (totalPublications > 100)
                {
                    queryConfiguration.MaxPublicationCount = 100;
                }

                SetQueryFields(queryConfiguration, fields);

                int roundSearchesByPage = totalPublications / pages.Count;

                foreach (string page in pages)
                {
                    IList<IPublication> partialPublication = RequestFeedToGraph(page, fields, roundSearchesByPage, queryConfiguration);
                    ((List<IPublication>)publications).AddRange(partialPublication);
                    if(publications.Count>  (totalPublications*2))
                    {
                        break;
                    }
                }



                publications = FilterPublications(publications, queryConfiguration.Keywords);
                publications = ReorganizeSearches(publications, totalPublications);


                return publications;

            }
            return null;
        }

        private IList<IPublication> FilterPublications(IList<IPublication> publications, IList<string> keywords)
        {
            IList<IPublication> pubs = new List<IPublication>();
            foreach (string word in keywords)
            {
                ((List<IPublication>)pubs).AddRange(FilterPublicationsByWord(publications, word));
            }

            return pubs;
        }

        private IList<IPublication> FilterPublicationsByWord(IList<IPublication> publications, string word)
        {
            return ((List<IPublication>)publications).FindAll(x => x.Message.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private IList<IPublication> ReorganizeSearches(IList<IPublication> publications, int maxPublicationCount)
        {
            IDictionary<string, string> selectedPublications = new Dictionary<string, string>();
            IList<IPublication> responsePublications = new List<IPublication>();
            if (publications.Count > maxPublicationCount)
            {
                Random random = new Random();

                for (int i = 0; i < maxPublicationCount; i++)
                {
                    int toAdd = random.Next(0, publications.Count);
                    IPublication publication = publications[toAdd];

                    if (!selectedPublications.ContainsKey(publication.Id))
                    {
                        responsePublications.Add(publication);
                        publications.RemoveAt(toAdd);
                        
                    }
                    else
                    {
                        publications.RemoveAt(toAdd);
                        i--;
                    }
                  

                   

                }
            }

            return responsePublications;
        }

        private bool Classify(IPublication publication, IQueryConfiguration queryConfiguration)
        {
            bool clasified = false;
            if (publication != null)
            {
                clasified = ClassifyByDate(publication, queryConfiguration.SinceDate, queryConfiguration.UntilDate);
            }
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

        internal IList<IPublication> RequestFeedToGraph(string user, IDictionary<string, string> args, int totalPublications, IQueryConfiguration queryConfiguration)
        {
            var request = CreateFeedRequestToGraph(user, "feed", args);
            IList<IPublication> publications = null;
            var task = MakeRequestToGraphAsync(request);
            int totalPagings = (totalPublications / 30); // I Expected found at most 30 publications for page
            if (task != null)
            {
                publications = new List<IPublication>();
                var jsonResponse = task.Result;

                if (jsonResponse != null)
                {
                    var before = GetBeforePublicationsRequest(jsonResponse);
                    var next = GetNextPublicationsRequest(jsonResponse);

                    List<dynamic> responsesPages = new List<dynamic>
                    {
                        jsonResponse,
                        before,
                        next,

                     };
                    totalPagings -= 3; //remove paging of jsonResponse, next and before

                    int pagings = (totalPagings / 2);

                    SetPublicationsRequests(responsesPages, pagings, next, before);


                    foreach (var response in responsesPages)
                    {
                        AddPublications(response, publications, queryConfiguration);
                    }

                }

            }
            return publications;

        }

        private void SetPublicationsRequests(List<dynamic> responsesPages, int pagings, dynamic next, dynamic before)
        {
            int beforePagings = 0;
            int nextPagings = 0;
            before = GetBeforePublicationsRequest(before);
            next = GetNextPublicationsRequest(next);

            while (beforePagings < pagings && before != null)
            {
                responsesPages.Add(before);
                before = GetBeforePublicationsRequest(before);
                ++beforePagings;
            }
            int restPagings = pagings - beforePagings;
            if (restPagings > 0)
            {
                pagings = pagings + restPagings;
            }

            while (nextPagings < pagings && next!=null)
            {
                responsesPages.Add(next);
                next = GetNextPublicationsRequest(next);
                ++nextPagings;
            }

          

        }

        private dynamic GetNextPublicationsRequest(dynamic jsonResponse)
        {
            dynamic response = default(dynamic);
            if (jsonResponse != null)
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

        private dynamic GetBeforePublicationsRequest(dynamic jsonResponse)
        {
            dynamic response = default(dynamic);
            if (jsonResponse != null)
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

        private void AddPublications(dynamic jsonResponse, IList<IPublication> publications, IQueryConfiguration queryConfiguration)
        {

            lock (this)
            {
                if (jsonResponse.data == null)
                {
                    throw new ArgumentException("No json data");
                }
                foreach (var item in jsonResponse.data)
                {
                    if (item != null)
                    {
                        IPublication publication = ParsePublicationOfJsonResponse(item, queryConfiguration);
                        IList<IPublication> responses = GetResponesPublications(item, queryConfiguration);

                        if (Classify(publication, queryConfiguration))
                        {
                            publications.Add(publication);
                            if (responses != null)
                            {
                                for (int i = 0; i < responses.Count; i++)
                                {

                                    var response = responses.ElementAt(i);
                                    if (Classify(response, queryConfiguration))
                                    {
                                        response.Id = "Response " + i + " with id: " + response.Id + " of: " + publication.Id;
                                        publications.Add(response);
                                    }
                                }

                            }

                        }
                        else if (responses != null)
                        {
                            for (int i = 0; i < responses.Count; i++)
                            {

                                var response = responses.ElementAt(i);
                                if (Classify(response, queryConfiguration))
                                {
                                    response.Id = "Response " + i + " with id: " + response.Id + " of: " + publication.Id;
                                    publications.Add(response);
                                }
                            }

                        }


                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private IPublication ParsePublicationOfJsonResponse(dynamic item, IQueryConfiguration queryConfiguration)
        {

            string id = item.id ?? "Not found";
            DateTime createDate = item.created_time ?? QueryConfiguration.NONE_DATE;
            string message = item.message ?? "Not message";
            string decodeMessage = DecodeHtmlText(message);
            if (decodeMessage != null)
            {
                message = decodeMessage;
            }
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

            };

            return publication;
        }

        private string DecodeHtmlText(string text)
        {
            return WebUtility.HtmlDecode(text);
        }

        private IList<IPublication> GetResponesPublications(dynamic item, IQueryConfiguration queryConfiguration)
        {
            List<IPublication> responses = null;
            if (item.comments != null)
            {
                int totalComments = queryConfiguration.MaxResponsesCount;
                if (totalComments > 0)
                {
                    responses = new List<IPublication>();
                    AddPublications(item.comments, responses, queryConfiguration);
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
            }
            catch (Exception)
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