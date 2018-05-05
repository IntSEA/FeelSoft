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
        private PublicationSearcher searcher;
        private string credential;


        public PublicationSearcher Searcher { get => searcher; set => searcher = value; }
        public string Credential { get => credential; set { credential = value; }}



        public SocialNetwork()
        {
        }

      

        protected void SetName(string name)
        {
           this.name = name;
        }

        public abstract IList<IPublication> Search(IList<IQueryConfiguration> queriesConfigurations);


        public abstract IList<IPublication> Search(IQueryConfiguration queryConfiguration);

        public IList<IPublication> GetFoundPublications()
        {
            return null;
        }

        public IList<IQueryConfiguration> GetQueriesConfiguration()
        {
            return null;
        }

      
        public string Name
        {
            get => name;
        }

        
    }
}
