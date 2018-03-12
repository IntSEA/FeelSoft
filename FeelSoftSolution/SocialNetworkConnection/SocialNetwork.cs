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
        private IQueryConfiguration[] queryConfigurations;
        private string name;
        private PublicationSearcher[] searchers;


        public string Name
        {
            get => name;
        }

        public IQueryConfiguration[] QueryConfigurations
        {
            get => queryConfigurations;
            set
            {
                queryConfigurations = value;
            }
        }

        public PublicationSearcher[] PublicationSearcher
        {
            get => searchers;
            set
            {
                searchers = value;
            }
        }
    }
}
