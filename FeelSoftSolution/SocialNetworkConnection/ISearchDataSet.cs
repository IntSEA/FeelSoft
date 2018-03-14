using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface ISearchDataSet
    {
        IList<IQueryConfiguration> QueriesConfigurations { get; set; }
        IList<IPublication> Publications { get; set; }

        void AddQueriesConfigurations(IList<IQueryConfiguration> queriesConfigurations);
        void AddPublications(IList<IPublication> publications);
        void AddQueriesConfigurations(IQueryConfiguration queryConfiguration);
        void AddPublications(IPublication publication);
    }
}