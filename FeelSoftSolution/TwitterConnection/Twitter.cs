using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using Tweetinvi;

namespace TwitterConnection
{
    public class Twitter : SocialNetwork
    {

        public Twitter(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) : base()
        {
            Credential = null;
            Searcher = new TwitterSearcher(accessTokenSecret);
        }



        public override IList<IPublication> GetFoundPublications()
        {
            throw new NotImplementedException();
        }

        public override IList<IQueryConfiguration> GetQueriesConfiguration()
        {
            throw new NotImplementedException();
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
