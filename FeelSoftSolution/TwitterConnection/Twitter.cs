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
<<<<<<< HEAD
        
        public Twitter(string credential) : base()
        {
            Credential = credential;
            Searcher = new TwitterSearcher(Credential);

=======

        public Twitter(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) : base()
        {
            Credential = null;
            Searcher = new TwitterSearcher(accessTokenSecret);
>>>>>>> c9ef4f1ebc7728c9a9caa97e8dcb13ad1c4ab9eb
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

<<<<<<< HEAD
        
=======

>>>>>>> c9ef4f1ebc7728c9a9caa97e8dcb13ad1c4ab9eb
    }
}
