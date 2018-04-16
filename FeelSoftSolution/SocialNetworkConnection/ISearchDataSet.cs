using System.Collections.Generic;

namespace SocialNetworkConnection
{
    public interface ISearchDataSet
    {
        IDictionary<string, IQueryConfiguration> QueriesConfigurations { get; set; }
        IDictionary<string, IPublication> Publications { get; set; }
        string BasePath { get; set; }
        int TotalPublications { get; set; }
        string BaseName { get; set; }

        void AddQueriesConfigurations(IList<IQueryConfiguration> queriesConfigurations);
        void AddPublications(IList<IPublication> publications);
        void AddOrReplacePublications(IList<IPublication> publications);
        void AddQueriesConfigurations(IQueryConfiguration queryConfiguration);
        void AddPublications(IPublication publication);
        void ExportDataSet();
        void ExportDataSet(int quantity);
        IPublication[] ImportDataSet(string path);
        IPublication[] ImportDataset();
        IList<IPublication> GetPublications();
    }
}