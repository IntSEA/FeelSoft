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
        private ISearchDataSet searchDataSet;


        public PublicationSearcher Searcher { get => searcher; set => searcher = value; }
        public string Credential { get => credential; set { credential = value; }}
        public ISearchDataSet DataSet { get => searchDataSet; set => searchDataSet = value; }




        public SocialNetwork()
        {
            DataSet = new SearchDataSet();
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

        public void SavePublications(IList<IPublication> publications)
        {
            DataSet.AddPublications(publications);
        }

        public void SavePublications(IPublication publication)
        {
            DataSet.AddPublications(publication);
        }

        public void SaveQueriesConfigurations(IList<IQueryConfiguration> queriesConfiguration)
        {
            DataSet.AddQueriesConfigurations(queriesConfiguration);
        }

        public void SaveQueriesConfiguration(IQueryConfiguration queryConfiguration)
        {
            DataSet.AddQueriesConfigurations(queryConfiguration);
        }

        public string Name
        {
            get => name;
        }

        
    }
}
