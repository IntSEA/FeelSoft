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

        public string Credential { get => credential; set => credential = value; }


        public PublicationSearcher(string credential)
        {
            this.Credential = credential;
        }

        public PublicationSearcher()
        {

        }


        public abstract IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations);

        public abstract IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration);
    }
}