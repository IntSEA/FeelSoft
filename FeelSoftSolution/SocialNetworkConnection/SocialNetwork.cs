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
        private ICredential credential;
        private ISearchDataSet searchDataSet;


        public PublicationSearcher Searcher { get => searcher; set => searcher = value; }
        public ICredential Credential { get => credential; set => credential = value; }


        public SocialNetwork()
        {
        }

      

        protected void SetName(string name)
        {
           this.name = name;
        }

        public string Name
        {
            get => name;
        }



        public ISearchDataSet SearchDataSet
        {
            get => searchDataSet;
            set
            {
            }
        }
    }
}
