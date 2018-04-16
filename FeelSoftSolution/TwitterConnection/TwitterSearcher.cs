using HtmlAgilityPack;
using SocialNetworkConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwitterConnection
{
    public class TwitterSearcher : PublicationSearcher
    {
        public static WebClient webClient = new WebClient();
        public static HtmlDocument htmlDocument = new HtmlDocument();

        public TwitterSearcher(string credential) : base(credential)
        {

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
            else
            {
                responsePublications = publications;
            }

            return responsePublications;
        }

        private void ParseTweets(IEnumerable<ITweet> tweets, IList<IPublication> publications, IQueryConfiguration queryConfiguration)
        {
            if (tweets != null)
            {
                ITweet[] arrayTweets = tweets.ToArray();
                for (int i = 0; i < arrayTweets.Length; i++)
                {
                    IPublication parsedPublication = ParseTweetToPublication(arrayTweets[i], queryConfiguration);
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


        private IPublication ParseTweetToPublication(ITweet tweet, IQueryConfiguration queryConfiguration)
        {
            string message = "";
            message = tweet.FullText ?? (tweet.Text + tweet.Suffix);
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
                ConfigurationName = queryConfiguration.Name

            };

            return publication;
        }

        public override IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            IList<IPublication> publications = new List<IPublication>();
            int totalPublications = queryConfiguration.MaxPublicationCount;
            int totalSearchesByKeyword = queryConfiguration.MaxPublicationCount / queryConfiguration.Keywords.Count;
            queryConfiguration.MaxPublicationCount = totalSearchesByKeyword + 1000;
            foreach (var key in queryConfiguration.Keywords)
            {
                ISearchTweetsParameters parameters = ParseSearchTweetsParameters(queryConfiguration, key);
                IEnumerable<ITweet> tweets = Search.SearchTweets(parameters);
                ParseTweets(tweets, publications, queryConfiguration);
                if (publications.Count > totalPublications)
                {
                    break;
                }


            }
            queryConfiguration.MaxPublicationCount = totalPublications;
            publications = ReorganizeSearches(publications, queryConfiguration.MaxPublicationCount);
            return publications;
        }

        private ISearchTweetsParameters ParseSearchTweetsParameters(IQueryConfiguration queryConfiguration, string key)
        {
            ISearchTweetsParameters parameters = new SearchTweetsParameters(key)
            {
                MaximumNumberOfResults = queryConfiguration.MaxPublicationCount
            };
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
