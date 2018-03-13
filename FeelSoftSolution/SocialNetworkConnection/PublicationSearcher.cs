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

        public PublicationSearcher()
        {
            publications = new List<IPublication>();
            queriesConfigurations = new List<IQueryConfiguration>();
        }

        public SearchPublications SearchPublications
        {
            get => default(SearchPublications);
            
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
                queriesConfigurations = value;
            }
        }

       
        public IList<IPublication> Search()
        {
            throw new System.NotImplementedException();
        }

        public void AddQueryConfiguration(IQueryConfiguration queryConfiguration)
        {
            throw new System.NotImplementedException();
        }
    }
}