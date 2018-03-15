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
        private const string CREDENTIAL = "EAACgYLKRHbUBAMCRPrALwP4kal8rUGpBGWl5Gc89" +
            "wuU4wuJd3zhlICUc75wQvZAlo33xQrF3iT1W0eUpYJvsfmRSZB98RmJLkFwJ16PSuRk00npVfv" +
            "QzIkom16Oaxiohi2prjZAEwKs4UglaYZB8pToQEOe8nzY4kG4nAsRZAeTms0i855F0OsVJIKpNZC2SZBuzq8Adn9wtgZDZD";
        private readonly HttpClient client;

        public FacebookSearcher(HttpClient client) : base()
        {
            this.client = client;
        }

        override
        public IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            List<IPublication> publications = new List<IPublication>();
            foreach (var query in queriesConfigurations)
            {
                IList<IPublication> found = SearchPublications(query);
                if (found != null && found.Count > 0)
                {
                    publications.AddRange(found);
                }
            }

            return publications;

        }

        override
        public IList<IPublication> SearchPublications(IQueryConfiguration queriesConfigurations)
        {
            List<IPublication> publications = new List<IPublication>();

        }

        internal async Task<string> GetUserNameAsync(string accessToken)
        {
            var response = await RequestToGraphAsync<dynamic>(accessToken, "/me",null);
            Task.WaitAll(response);
            var name = response.result;
            return name;
        }

        private async Task<T> RequestToGraphAsync<T>(string endpoint,IDictionary<string,string> args)
        {
           
            var response = await client.GetAsync($"{endpoint}?access_token={CREDENTIAL}&{args}");


            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
