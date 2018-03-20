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
        public const string TWITTER_CREDENTIALS = "";

        public Twitter(string credential) : base()
        {
            Credential = credential;
            Searcher = new TwitterSearcher(Credential);
        }

        public Twitter() : base()
        {
            InitializeWithDynamicCredentials(TWITTER_CREDENTIALS );
        }

        private void InitializeWithDynamicCredentials(string path)
        {
            throw new NotImplementedException();
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
