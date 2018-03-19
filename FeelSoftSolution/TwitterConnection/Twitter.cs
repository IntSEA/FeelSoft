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
        
        public Twitter(string credential) : base()
        {
            Credential = credential;
            Searcher = new TwitterSearcher(Credential);

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
            throw new NotImplementedException();
        }

        public override IList<IPublication> Search(IQueryConfiguration queryConfiguration)
        {
            throw new NotImplementedException();
        }

        
    }
}
