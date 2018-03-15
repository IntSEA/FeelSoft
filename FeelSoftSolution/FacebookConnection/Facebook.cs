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

        public Facebook() : base()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.12/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Searcher = new FacebookSearcher(client);
            SetName("Facebook");

        }

        override
        public IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations)
        {
            return Searcher.SearchPublications(queriesConfigurations);
        }

        override
        public IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            return Searcher.SearchPublications(queryConfiguration);
        }











    }

}
