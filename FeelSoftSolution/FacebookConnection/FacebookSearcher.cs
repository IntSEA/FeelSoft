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

        public FacebookSearcher(HttpClient client, ICredential credential) : base(credential)
        {
            this.client = client;

        }

        internal async Task<string> GetUserNameAsync(string accessToken)
        {
            var response = await RequestToGraphAsync<dynamic>(accessToken, "/me",null);
            Task.WaitAll(response);
            var name = response.result;
            return name;
        }

        private async Task<T> RequestToGraphAsync<T>(string accessToken, string endpoint,IDictionary<string,string> args)
        {
           
            var response = await client.GetAsync($"{endpoint}?access_token={accessToken}&{args}");


            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
