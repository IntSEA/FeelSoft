using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkConnection
{
    public abstract class SocialNetwork : ISocialNetwork
    {
        private string name;
        private IList<PublicationSearcher> searchers;


        public string Name
        {
            get => name;
        }

        public IList<PublicationSearcher> PublicationSearcher
        {
            get => searchers;
            set
            {
                searchers = value;
            }
        }
    }
}
