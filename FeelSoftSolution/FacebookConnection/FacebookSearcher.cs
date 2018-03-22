using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetworkConnection;

namespace FacebookConnection
{
    public class FacebookSearcher : PublicationSearcher
    {
        private HttpClient client;
        private const int LIMIT_PUBLICATIONS = 100;

        public FacebookSearcher(HttpClient client, string credential) : base(credential)
        {
            this.client = client;

        }

        public FacebookSearcher(HttpClient client) : base()
        {
            this.client = client;
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
                List<IPublication> publications = new List<IPublication>();
                IDictionary<string, string> fields = new Dictionary<string, string>();
                int totalPublications = queryConfiguration.MaxPublicationCount;
                if (totalPublications > LIMIT_PUBLICATIONS)
                {
                    queryConfiguration.MaxPublicationCount = 100;
                }
                SetQueryFields(queryConfiguration, fields);

                if (queryConfiguration.Keywords != null)
                {
                    foreach (var keyword in queryConfiguration.Keywords)
                    {
                        IList<IPublication> partialPublication = Classify(RequestFeedToGraph(keyword, fields, totalPublications), queryConfiguration);
                        publications.AddRange(partialPublication);
                    }
                }



                return publications;

            }
            throw new ArgumentNullException("QueryConfiguration: " + queryConfiguration + "was null");
        }

        private IList<IPublication> Classify(IList<IPublication> publications, IQueryConfiguration queryConfiguration)
        {
            ClassifyByDate(publications, queryConfiguration.SinceDate, queryConfiguration.UntilDate);
            return publications;
        }

        private void ClassifyByDate(IList<IPublication> publications, DateTime sinceDate, DateTime untilDate)
        {
            if (publications != null)
            {
                for (int i = 0; i < publications.Count; i++)
                {
                    var item = publications.ElementAt(i);
                    if (item.CreateDate.CompareTo(QueryConfiguration.NONE_DATE) != 0)
                    {
                        if (!(item.CreateDate.CompareTo(sinceDate) >= 0 && item.CreateDate.CompareTo(untilDate) <= 0))
                        {
                            publications.RemoveAt(i);
                            i--;
                        }
                    }

                }
            }

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
                args.Add("fields", "message,from,created_time");

            }
        }



        internal IList<IPublication> RequestFeedToGraph(string user, IDictionary<string, string> args, int totalPublications)
        {
            var request = CreateFeedRequestToGraph(user, "feed", args);
            IList<IPublication> publications = new List<IPublication>();
            var task = MakeRequestToGraphAsync(request);
            var jsonResponse = task.Result;


            if (jsonResponse == null)
            {
                throw new HttpRequestException("Refresh access token");
                
            }

            else if (jsonResponse.data == null)
            {
                
                throw new HttpRequestException("Refresh access token");

            }

            AddPublications(jsonResponse, publications, totalPublications);

            AddNextPagings(totalPublications, publications, jsonResponse);



            return publications;

        }

        private void AddNextPagings(int totalPublications, IList<IPublication> publications, dynamic jsonResponse)
        {
            bool underlimitFound = publications.Count < totalPublications;

            List<dynamic> nextPaggings = new List<dynamic>();

            while (underlimitFound)
            {
                var nextPagging = GetNextPublicationsRequest(underlimitFound, jsonResponse);
                AddPublications(nextPagging, publications, totalPublications);

            }

            nextPaggings = null;
        }

        private dynamic GetNextPublicationsRequest(bool underlimitFound, dynamic jsonResponse)
        {
            if (underlimitFound)
            {
                string next = (string)jsonResponse.paging.next;
                return MakeRequestToGraphAsync(next);
            }
            return null;
        }

        private void AddPublications(dynamic jsonResponse, IList<IPublication> publications, int totalPublications)
        {
            lock (this)
            {
                foreach (var item in jsonResponse.data)
                {
                    IPublication publication = ParsePublicationOfJsonResponse(item);
                    if (publications.Count <= totalPublications)
                    {
                        publications.Add(publication);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private IPublication ParsePublicationOfJsonResponse(dynamic item)
        {
            string id = item.id != null ? item.id : "Not found";
            DateTime createDate = item.created_time != null ? item.created_time : QueryConfiguration.NONE_DATE;
            string message = item.message != null ? item.message : "Not message";
            string wroteBy = "Not found";
            if (item.from != null)
            {
                wroteBy = (item.from.name + item.from.id);
            }
            return new Publication()
            {

                Id = id,
                CreateDate = createDate,
                Message = message,

                WroteBy = wroteBy,     
                

            };
        }

        private async Task<dynamic> MakeRequestToGraphAsync(string request)
        {

            InitializeClient();
            dynamic response = await client.GetAsync(request);
            
            if (response.ReasonPhrase.Equals("Not Found"))
            {
                throw new ArgumentNullException("Not found user");
            }
            if (!response.IsSuccessStatusCode)
            {
                return default(dynamic);
            }

            var result = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject(result);
        }

        private void InitializeClient()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Facebook.GRAPH_URI),
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string MakeTokenRequestToGraphAsync(string request)
        {
            var jsonResponse = MakeRequestToGraphAsync(request).Result;

            return (string)jsonResponse.access_token;
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