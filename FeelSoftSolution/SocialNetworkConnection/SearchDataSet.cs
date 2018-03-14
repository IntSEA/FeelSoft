using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class SearchDataSet : ISearchDataSet
    {
        private IList<IQueryConfiguration> queriesConfigurations;
        private IList<IPublication> publications;

        public IList<IQueryConfiguration> QueriesConfigurations { get => queriesConfigurations; set => queriesConfigurations = value; }
        public IList<IPublication> Publications { get => publications; set => publications = value; }

        public SearchDataSet()
        {
            queriesConfigurations = new List<IQueryConfiguration>();
            publications = new List<IPublication>();
        }

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
            this.queriesConfigurations.Add(queryConfiguration);
        }
    }
}