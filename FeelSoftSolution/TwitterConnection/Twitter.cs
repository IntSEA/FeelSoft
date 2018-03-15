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

        public Twitter() : base()
        {
            Credential = null;
            ValidateAuthConnection();
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

        private void ValidateAuthConnection()
        {
            Auth.SetUserCredentials("","","","");
        }
    }
}
