using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworkConnection;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwitterConnection
{
    public class TwitterSearcher : PublicationSearcher
    {
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

        private IList<IPublication> ParseTweets(IEnumerable<ITweetWithSearchMetadata> tweets)
        {
            IList<IPublication> publications = new List<IPublication>();
            foreach (var item in tweets)
            {
                publications.Add(ParseTweet(item));
            }

            return publications;
        }

        private IPublication ParseTweet(ITweetWithSearchMetadata tweet)
        {
            IPublication publication = new Publication()
            {
                Message = tweet.Text,
                WroteBy = tweet.CreatedBy.Name,
                CreateDate = tweet.TweetLocalCreationDate,

            };

            return publication;


        }

        public override IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            List<IPublication> publications = new List<IPublication>();
            foreach (var key in queryConfiguration.Keywords)
            {


                ISearchTweetsParameters parameters = ParseSearchTweetsParameters(queryConfiguration, key);

                publications.AddRange(ParseTweets(Search.SearchTweetsWithMetadata(parameters).Tweets));

            }

            return publications;
        }

        private ISearchTweetsParameters ParseSearchTweetsParameters(IQueryConfiguration queryConfiguration, string key)
        {
            ISearchTweetsParameters parameters = new SearchTweetsParameters(key);
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
            if (queryConfiguration.SinceDate.CompareTo(QueryConfiguration.NONE_DATE)!=0)
            {
                parameters.Since = queryConfiguration.SinceDate;
            }
            if (queryConfiguration.UntilDate.CompareTo(QueryConfiguration.NONE_DATE)!=0)
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
