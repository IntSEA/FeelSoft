using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SocialNetworkConnection
{
    public abstract class PublicationSearcher
    {
        private Thread searchThread;
        private ICredential credential;

        public PublicationSearcher(ICredential credential)
        {
            this.credential = credential;
        }

        
        public ICredential Credential
        {
            get => credential;          
        }

        public IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            throw new System.NotImplementedException();
        }

        public IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations , int max)
        {
            throw new System.NotImplementedException();
        }

        private ThreadStart SearchStart(IList<IQueryConfiguration> queriesConfigurations, int max)
        {
            throw new System.NotImplementedException();
        }


    }
}