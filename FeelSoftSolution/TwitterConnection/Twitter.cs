using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocialNetworkConnection;
using Tweetinvi;

namespace TwitterConnection
{
    public class Twitter : SocialNetwork
    {
        public const string TWITTER_CREDENTIALS = "";

        public Twitter(string credential) : base()
        {
            Credential = credential;
            Searcher = new TwitterSearcher(Credential);
        }

        public Twitter() : base()
        {
            InitializeWithDynamicCredentials(TWITTER_CREDENTIALS, out string parseCredential);           
            Credential = parseCredential;
            Searcher = new TwitterSearcher(Credential);
        }


        private void InitializeWithDynamicCredentials(string path, out string parseCredential)
        {
            
            string consumerKey = System.Configuration.ConfigurationManager.AppSettings["consumerKey"];
            string consumerSecret = System.Configuration.ConfigurationManager.AppSettings["consumerSecret"]; ;
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"]; ;
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"]; ;

            
            parseCredential = consumerKey + "|" + consumerSecret + "|" + accessToken + "|" + secretToken;
        }

        

        public override IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations)
        {

            return Searcher.SearchPublications(queriesConfigurations);


        }

        public override IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            return Searcher.SearchPublications(queryConfiguration);
        }


    }
}
