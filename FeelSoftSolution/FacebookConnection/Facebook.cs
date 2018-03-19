using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using System.IO;
using Newtonsoft.Json;



namespace FacebookConnection
{
    public class Facebook : SocialNetwork
    {
        public const string GRAPH_URI = "https://graph.facebook.com/v2.12/";
        public Facebook(string accessToken) : base()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(GRAPH_URI)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Searcher = new FacebookSearcher(client, accessToken);
            SetName("Facebook");
        }

        public override IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations)
        {
            return Searcher.SearchPublications(queriesConfigurations);
        }

        public override IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            return Searcher.SearchPublications(queryConfiguration);
        }

        public override IList<IPublication> GetFoundPublications()
        {
            throw new NotImplementedException();
        }

        public override IList<IQueryConfiguration> GetQueriesConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}