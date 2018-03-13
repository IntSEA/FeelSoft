using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface ICredential
    {
        void SetCredentials(string credentials);
        void GetCredentials();
    }
}