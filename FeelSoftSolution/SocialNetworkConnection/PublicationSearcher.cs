using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocialNetworkConnection
{
    public abstract class PublicationSearcher
    {
        private string credential;

        public PublicationSearcher(string credential)
        {

        }       
        

        public IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            throw new System.NotImplementedException();
        }

        public IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            throw new System.NotImplementedException();
        }
    }
}