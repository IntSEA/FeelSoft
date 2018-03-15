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

        private void ValidateAuthConnection()
        {
            Auth.SetUserCredentials("","","","");
        }
    }
}
