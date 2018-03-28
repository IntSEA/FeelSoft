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
        ISearchDataSet DataSet { get; set; }

        IList<IPublication> Search(IList<IQueryConfiguration> queriesConfiguration);
        IList<IPublication> Search(IQueryConfiguration queryConfiguration);
        IList<IPublication> GetFoundPublications();
        IList<IQueryConfiguration> GetQueriesConfiguration();
        void SavePublications(IList<IPublication> publications);
        void SavePublications(IPublication publication);
        void SaveQueriesConfigurations(IList<IQueryConfiguration> queriesConfiguration);
        void SaveQueriesConfiguration(IQueryConfiguration queryConfiguration);
    }
}