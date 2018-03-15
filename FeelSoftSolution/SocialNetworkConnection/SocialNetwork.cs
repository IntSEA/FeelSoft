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
        public string Credential { get => credential; set => credential = value; }


        public SocialNetwork()
        {
            searchDataSet = new SearchDataSet();
        }

      

        protected void SetName(string name)
        {
           this.name = name;
        }

        public IList<IPublication> Search(IList<IQueryConfiguration> )
        {
            throw new NotImplementedException();
        }

        public void GetFoundPublications()
        {
            throw new NotImplementedException();
        }

        public void GetQueriesConfiguration()
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get => name;
        }



        public ISearchDataSet SearchDataSet
        {
            get => searchDataSet;
           
        }
    }
}
