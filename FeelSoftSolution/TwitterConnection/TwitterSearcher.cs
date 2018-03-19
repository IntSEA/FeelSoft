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

        private IPublication ParseTweet(ITweet tweet)
        {
            IPublication publication = new Publication()
            {
                Message = tweet.FullText,
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

                ISearchTweetsParameters query = new SearchTweetsParameters(key)
                {

                };

                publications.AddRange(ParseTweets(Search.SearchTweetsWithMetadata(query).Tweets));

            }

            return publications;
        }
    }
}
