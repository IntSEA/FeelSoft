using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocialNetworkConnection
{
    public abstract class PublicationSearcher
    {
        private IEnumerable<IPublication> publications;

        private Thread searchThread;

        public SearchPublications SearchPublications
        {
            get => default(SearchPublications);
            set
            {
            }
        }

        public IEnumerable<IPublication> IPublication
        {
            get => publications;
            
        }
    }
}