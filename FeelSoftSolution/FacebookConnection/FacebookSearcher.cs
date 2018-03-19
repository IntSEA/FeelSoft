using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetworkConnection;

namespace FacebookConnection
{
    public class FacebookSearcher : PublicationSearcher
    {
        private readonly HttpClient client;

        public FacebookSearcher(HttpClient client, string credential) : base(credential)
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
                SetQueryFields(queryConfiguration, fields);

                if (queryConfiguration.Keywords != null)
                {
                    foreach (var keyword in queryConfiguration.Keywords)
                    {
                        IList<IPublication> partialPublication = Classify(RequestFeedToGraph(keyword, fields), queryConfiguration);
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



        internal IList<IPublication> RequestFeedToGraph(string user, IDictionary<string, string> args)
        {
            var jsonResponse = RequestToGraphAsync(user, "feed", args).Result;
            IList<IPublication> publications = new List<IPublication>();
            if (jsonResponse == null)
            {
                throw new HttpRequestException("Refresh access token");
            }

            else if (jsonResponse.data == null)
            {

                throw new HttpRequestException("Refresh access token");

            }
            foreach (var item in jsonResponse.data)
            {
                IPublication publication = new Publication()
                {
                    Id = item.id,
                    CreateDate = item.created_time,
                    Message = item.message,
                    WroteBy = (item.from.name + item.from.id),

                };
                publications.Add(publication);

            }

            return publications;

        }

        private async Task<dynamic> RequestToGraphAsync(string user, string consult, IDictionary<string, string> fields)
        {
            string reqConsult = $"{consult}?access_token={Credential}";
            reqConsult += GetConsultWithFields(fields);


            string request = user + "/" + reqConsult;

            var response = await client.GetAsync(request);


            if (!response.IsSuccessStatusCode)
                return default(dynamic);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<dynamic>(result);
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