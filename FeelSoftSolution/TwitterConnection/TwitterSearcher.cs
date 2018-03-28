using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetworkConnection;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using HtmlAgilityPack;

namespace TwitterConnection
{
    public class TwitterSearcher : PublicationSearcher
    {
        private WebClient webClient;
        private HtmlDocument htmlDocument;

        public TwitterSearcher(string credential) : base(credential)
        {
            webClient = new WebClient();
            webClient = new WebClient();
            htmlDocument = new HtmlDocument();
        }

        public override IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            List<IPublication> publications = new List<IPublication>();
            foreach (var item in queriesConfigurations)
            {

                publications.AddRange(SearchPublications(item));
            }


            return publications;
        }

        private IList<IPublication> ReorganizeSearches(IList<IPublication> publications, int maxPublicationCount)
        {
            IList<IPublication> responsePublications = new List<IPublication>();
            if (publications.Count > maxPublicationCount)
            {
                Random random = new Random();

                for (int i = 0; i < maxPublicationCount; i++)
                {
                    int toAdd = random.Next(0, publications.Count);
                    responsePublications.Add(publications[toAdd]);
                    publications.RemoveAt(toAdd);
                }
            }

            return responsePublications;
        }

        private void ParseTweets(IEnumerable<ITweet> tweets, IList<IPublication> publications)
        {
            if (tweets != null)
            {
                ITweet[] arrayTweets = tweets.ToArray();
                for (int i = 0; i < arrayTweets.Length; i++)
                {
                    IPublication parsedPublication = ParseTweet(arrayTweets[i]);
                    if (arrayTweets[i] == null)
                    {
                        throw new ArgumentException("No deberia suceder.");
                    }

                    if (parsedPublication != null)
                    {
                        publications.Add(parsedPublication);
                    }
                }

            }


        }

        private IList<IPublication> ParseTweets(IEnumerable<ITweet> tweets, IPublication parent)
        {
            List<IPublication> publications = new List<IPublication>();
            foreach (var item in tweets)
            {
                IPublication parsedPublication = ParseTweet(item);
                parsedPublication.Parent = parent;

                if (parsedPublication != null)
                {
                    publications.Add(parsedPublication);
                }

            }


            return publications;

        }


        private IPublication ParseTweet(ITweet tweet)
        {
            string message = ReadHtmlContent(tweet);
            IPublication publication = null;
            long id = tweet.Id;

            if (String.IsNullOrEmpty(message))
            {
                if (String.IsNullOrEmpty(tweet.FullText))
                {

                    message = tweet.Prefix + tweet.Text + tweet.Suffix;
                }
                else
                {
                    message = tweet.FullText;
                }
            }

            publication = new Publication()
            {
                Id = "Twitter:" + id,
                Message = message,
                WroteBy = tweet.CreatedBy.Name,
                CreateDate = tweet.TweetLocalCreationDate,

            };

            return publication;


        }

        private string ReadHtmlContent(ITweet tweet)
        {
            string response = null;
            response = ReadHtmlContentFromIOembededTweet(tweet);
            if (response == null)
            {
                response = ReadHtmlContentFromURL(tweet);
            }


            return response;
        }

        private string ReadHtmlContentFromURL(ITweet tweet)
        {
            if (tweet != null)
            {
                string url = tweet.Url;

                try
                {
                    string html = webClient.DownloadString(url);
                    htmlDocument.LoadHtml(html);
                    string mes = htmlDocument.DocumentNode.Descendants("title").FirstOrDefault().InnerText;
                    return mes;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return null;


        }

        private string ReadHtmlContentFromIOembededTweet(ITweet tweet)
        {
            string text = null;
            IOEmbedTweet aux = Tweet.GetOEmbedTweet(tweet.Id);
            if (aux != null)
            {
                string htmlCode = aux.HTML;
                if (htmlCode != null)
                {
                    htmlDocument.LoadHtml(htmlCode);
                    text = htmlDocument.DocumentNode.InnerText;

                }
            }

            return text;
        }

        public override IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            IList<IPublication> publications = new List<IPublication>();

            foreach (var key in queryConfiguration.Keywords)
            {
                ISearchTweetsParameters parameters = ParseSearchTweetsParameters(queryConfiguration, key);


                IEnumerable<ITweet> tweets = Search.SearchTweets(parameters);


                ParseTweets(tweets, publications);


            }

            publications = ReorganizeSearches(publications, queryConfiguration.MaxPublicationCount);


            return publications;
        }

        private ISearchTweetsParameters ParseSearchTweetsParameters(IQueryConfiguration queryConfiguration, string key)
        {
            ISearchTweetsParameters parameters = new SearchTweetsParameters(key);
            parameters.MaximumNumberOfResults = queryConfiguration.MaxPublicationCount;
            ParseFilter(parameters, queryConfiguration);
            ParseLanguage(parameters, queryConfiguration);
            ParseLocation(parameters, queryConfiguration);
            ParseSearchType(parameters, queryConfiguration);
            ParseSearchDates(parameters, queryConfiguration);
            //TODO ParseGeoCoordinates.

            return parameters;

        }

        private void ParseSearchDates(ISearchTweetsParameters parameters, IQueryConfiguration queryConfiguration)
        {
            if (queryConfiguration.SinceDate.CompareTo(QueryConfiguration.NONE_DATE) != 0)
            {
                parameters.Since = queryConfiguration.SinceDate;
            }
            if (queryConfiguration.UntilDate.CompareTo(QueryConfiguration.NONE_DATE) != 0)
            {
                parameters.Until = queryConfiguration.UntilDate;
            }

        }

        private void ParseSearchType(ISearchTweetsParameters parameters, IQueryConfiguration queryConfiguration)
        {
            if (queryConfiguration.SearchType == SearchTypes.Mixed)
            {
                parameters.SearchType = SearchResultType.Mixed;
            }
            else if (queryConfiguration.SearchType == SearchTypes.Popular)
            {
                parameters.SearchType = SearchResultType.Popular;
            }

            else if (queryConfiguration.SearchType == SearchTypes.Recent)
            {
                parameters.SearchType = SearchResultType.Recent;
            }
        }

        private void ParseLocation(ISearchTweetsParameters parameters, IQueryConfiguration queryConfiguration)
        {
            //if (queryConfiguration.Location == Locations.Colombia)
            //{
            //    parameters.Locale = "Colombia";
            //}
            //else if(queryConfiguration.Location == Locations.USA)
            //{
            //    parameters.Locale = "USA";
            //}
        }

        private void ParseLanguage(ISearchTweetsParameters parameters, IQueryConfiguration queryConfiguration)
        {
            if (queryConfiguration.Language == Languages.English)
            {
                parameters.Lang = LanguageFilter.English;
            }

            else if (queryConfiguration.Language == Languages.Spanish)
            {
                parameters.Lang = LanguageFilter.Spanish;
            }
        }

        private void ParseFilter(ISearchTweetsParameters parameters, IQueryConfiguration queryConfiguration)
        {
            switch (queryConfiguration.Filter)
            {
                case Filters.Hashtag:
                    {
                        parameters.Filters = TweetSearchFilters.Hashtags;
                        break;
                    }
                case Filters.Image:
                    {
                        parameters.Filters = TweetSearchFilters.Images;
                        break;
                    }
                case Filters.News:
                    {
                        parameters.Filters = TweetSearchFilters.News;
                        break;
                    }
                case Filters.None:
                    {
                        parameters.Filters = TweetSearchFilters.None;
                        break;
                    }
                case Filters.Video:
                    {
                        parameters.Filters = TweetSearchFilters.Videos;
                        break;
                    }
            }
        }
    }
}
