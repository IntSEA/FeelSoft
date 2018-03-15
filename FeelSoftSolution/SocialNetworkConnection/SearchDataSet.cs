using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class SearchDataSet : ISearchDataSet
    {
        private IList<IPublication> publications;
        private IList<IQueryConfiguration> queriesConfiguration;

        public IList<IPublication> Publications { get => publications; set => publications = value; }
        public IList<IQueryConfiguration> QueriesConfiguration { get => queriesConfiguration; set => queriesConfiguration = value; }
        public IList<IQueryConfiguration> QueriesConfigurations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddPublications(IList<IPublication> publications)
        {
            if (publications != null)
            {
                foreach (var item in publications)
                {
                    AddPublications(item);
                }
            }
        }

        public void AddPublications(IPublication publication)
        {
            this.publications.Add(publication);
        }

        public void AddQueriesConfigurations(IList<IQueryConfiguration> queriesConfigurations)
        {
            if (queriesConfigurations != null)
            {
                foreach (var item in queriesConfigurations)
                {
                    AddQueriesConfigurations(item);
                }
            }
        }

        public void AddQueriesConfigurations(IQueryConfiguration queryConfiguration)
        {
            this.queriesConfiguration.Add(queryConfiguration);
        }
    }
}