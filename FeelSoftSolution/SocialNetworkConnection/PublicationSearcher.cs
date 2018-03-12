using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocialNetworkConnection
{
    public abstract class PublicationSearcher
    {
        private IList<IPublication> publications;
        private IList<IQueryConfiguration> queriesConfigurations;

        private Thread searchThread;

        public SearchPublications SearchPublications
        {
            get => default(SearchPublications);
            set
            {
            }
        }

        public IList<IPublication> IPublications
        {
            get => publications;
            
        }

        public IList<IQueryConfiguration> QueriesConfigurations
        {
            get => queriesConfigurations;
            set
            {
            }
        }
    }
}