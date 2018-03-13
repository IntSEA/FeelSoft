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
        private IList<PublicationSearcher> searchers;
        private ICredential credential;


        public SocialNetwork()
        {
            name = GetSocialNetworkName();
            searchers = new List<PublicationSearcher>();
        }

        protected void SetName(string name)
        {
           this.name = name;
        }

        public string Name
        {
            get => name;
        }

        public IList<PublicationSearcher> PublicationSearcher
        {
            get => searchers;
            set
            {
                searchers = value;
            }
        }
            
        public void AddSearcher(PublicationSearcher searcher)
        {
            searchers.Add(searcher);
        }

        private string GetSocialNetworkName()
        {
            throw new NotImplementedException();
        }
    }
}
