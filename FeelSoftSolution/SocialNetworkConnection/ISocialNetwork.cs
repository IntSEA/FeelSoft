using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface ISocialNetwork
    {
        string Name { get; }
        string Credential { get; set; }
        PublicationSearcher Searcher { get; set; }

        IList<IPublication> Search(IList<IQueryConfiguration> queriesConfiguration);
        IList<IPublication> Search(IQueryConfiguration queryConfiguration);
        IList<IPublication> GetFoundPublications();
        IList<IQueryConfiguration> GetQueriesConfiguration();
       
    }
}