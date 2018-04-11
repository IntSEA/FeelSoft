using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocialNetworkConnection;
using Tweetinvi;
using Tweetinvi.Models;

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
            string accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
            string secretToken = System.Configuration.ConfigurationManager.AppSettings["secretToken"];
            parseCredential = consumerKey + "|" + consumerSecret + "|" + accessToken + "|" + secretToken;
        }

        public override IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations)
        {
            return Searcher.SearchPublications(queriesConfigurations);
        }

        public static string ReadHtmlContent(long tweetId)
        {
            ITweet tweet = Tweet.GetTweet(tweetId);
            string content = ReadHtmlContent(tweet);
            return content;
        }

        public static string ReadHtmlContent(ITweet tweet)
        {
            string response = null;
            response = ReadHtmlContentFromIOembededTweet(tweet);
            if (response == null)
            {
                response = ReadHtmlContentFromURL(tweet);
            }
            return response;
        }

        public static string ReadHtmlContentFromURL(ITweet tweet)
        {
            if (tweet != null)
            {
                string url = tweet.Url;
                try
                {
                    string html = TwitterSearcher.webClient.DownloadString(url);
                    TwitterSearcher.htmlDocument.LoadHtml(html);
                    string htmlContent = TwitterSearcher.htmlDocument.DocumentNode.Descendants("title").FirstOrDefault().InnerText;
                    return htmlContent;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public static string ReadHtmlContentFromIOembededTweet(ITweet tweet)
        {
            string htmlContent = null;
            IOEmbedTweet aux = Tweet.GetOEmbedTweet(tweet.Id);
            if (aux != null)
            {
                string htmlCode = aux.HTML;
                if (htmlCode != null)
                {
                    TwitterSearcher.htmlDocument.LoadHtml(htmlCode);
                    htmlContent = TwitterSearcher.htmlDocument.DocumentNode.InnerText;
                }
            }
            return htmlContent;
        }

        public override IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            return Searcher.SearchPublications(queryConfiguration);
        }
    }
}
