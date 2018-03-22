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
using System.Security.Cryptography;

namespace FacebookConnection
{
    public class Facebook : SocialNetwork
    {
        public const string GRAPH_URI = "https://graph.facebook.com/v2.12/";


        //README: this credential is a test crredential, therefore, it'd can generate errors.
        public const string DEFAULT_CREDENTIAL = "EAACgYLKRHbUBALYBzCsopu3EK6a9HhWfpnJxKttIxMoYgDfB" +
            "YAiLeVuL3yHVgvKZB01cvkk2EQOHOf8p8eRHp2madZBS2xL4njGbympNepRlPQ6tfjpG5gwdTAvZCZAMhwanfLjr" +
            "qU7CBJ0fpDa7pYd1XTrLZC41zKDT90xXNELnwtZB4KLEhe";


        bool revalidate;


        public Facebook(string accessToken) : base()
        {
            HttpClient client = InitializeClient();

            Searcher = new FacebookSearcher(client, accessToken);
            SetName("Facebook");
        }


        public Facebook() : base()
        {
            HttpClient client = InitializeClient();
            revalidate = true;

            InitializeSearcherWithRequestToken(client);

            SetName("Facebook");
        }

        private void InitializeWithDynamicToken(string path, HttpClient client)
        {
            string accessToken = ReadAccessToken(path);
            Searcher = new FacebookSearcher(client, accessToken);
        }

        private string ReadAccessToken(string path)
        {
            StreamReader sr = new StreamReader(path: path);
            string accessToken = sr.ReadLine();
            sr.Close();
            return accessToken;
        }

        private void InitializeSearcherWithRequestToken(HttpClient client)
        {
            FacebookSearcher searcher = new FacebookSearcher(client);
            string accessToken = RequestAccessToken(searcher);
            Credential = accessToken;
            searcher.Credential = Credential;
            Searcher = searcher;
        }

        public Facebook(bool revalidateToken) : base()
        {
            HttpClient client = InitializeClient();
            InitializeSearcherWithRequestToken(client);
            this.revalidate = revalidateToken;
            SetName("Facebook");


        }

        private string RequestAccessToken(FacebookSearcher searcher)
        {

            string encryptTokenRequest = GetEncryptTokentRequest();
            string decryptTokenRequest = GetDecryptRequest(encryptTokenRequest);
            string token = searcher.MakeTokenRequestToGraphAsync(decryptTokenRequest);
            return token;
        }

        private string EncryptRequest(string request)
        {
            string hash = "f33150ft"; //No change it
            byte[] data = UTF8Encoding.UTF8.GetBytes(request);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,

            };
            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string encrypted = Convert.ToBase64String(results, 0, results.Length);

            return encrypted;
        }

        private string GetDecryptRequest(string encryptTokenRequest)
        {
            string hash = "f33150ft"; //No change it.
            string encrypted = encryptTokenRequest;
            byte[] data = Convert.FromBase64String(encrypted);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
            {
                Key = keys,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,

            };
            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string decrypted = UTF8Encoding.UTF8.GetString(results);

            return decrypted;

        }

        private string GetEncryptTokentRequest()
        {
            string tokenRequest = System.Configuration.ConfigurationManager.AppSettings["encryptRequestToken"];

            return tokenRequest;

        }

        private HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(GRAPH_URI)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public override IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations)
        {
            try
            {
                return Searcher.SearchPublications(queriesConfigurations);
            }
            catch (HttpRequestException httpException)
            {
                if (revalidate)
                {
                    HttpClient client = InitializeClient();
                    InitializeSearcherWithRequestToken(client);
                    return Searcher.SearchPublications(queriesConfigurations);
                }
                else
                {
                    return null;
                }
            }
        }

        public override IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            try
            {
                return Searcher.SearchPublications(queryConfiguration);

            }
            catch (HttpRequestException httpException )
            {
                if (revalidate)
                {
                    HttpClient client = InitializeClient();
                    InitializeSearcherWithRequestToken(client);
                    return Searcher.SearchPublications(queryConfiguration);
                }
                else return null;
            }
           
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