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
    public class Facebook:SocialNetwork
    {
        private readonly HttpClient client; 

        public Facebook() : base()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.12/"),
                                
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            FacebookSearcher searcher = new FacebookSearcher(client);
            AddSearcher(searcher);
            SetName("Facebook");
            
        }

        private string GetAccessToken()
        {

            WebRequest request = WebRequest.Create("https://graph.facebook.com/oauth/access_token?grant_type=client_credentials&client_id=363152994161659&client_secret=07d96e35603c6c3478128daa7dca22d8");
            request.Method = "POST";
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            System.IO.Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer.Split(':')[1].Split(',')[0].Replace("\"", "");


        }
    }
    
}
