using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface ISearchDataSet
    {
        IDictionary<string,IQueryConfiguration> QueriesConfigurations { get; set; }
        IDictionary<string,IPublication> Publications { get; set; }
        string BasePath { get; set; }
        int TotalPublications { get ; set ; }

        void AddQueriesConfigurations(IList<IQueryConfiguration> queriesConfigurations);
        void AddPublications(IList<IPublication> publications);
        void AddQueriesConfigurations(IQueryConfiguration queryConfiguration);
        void AddPublications(IPublication publication);
        void ExportDataSet();
        IPublication[] ImportDataSet(string path);
        IPublication[] ImportDataset();
        IPublication[] GetPublications();
    }
}