using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class QueryConfiguration : IQueryConfiguration
    {
        private IList<string> keywords;
        private Locations location;
        private DateTime sinceDate;
        private DateTime untilDate;
        private Languages language;
        private Filters filter;
        private SearchTypes searchType;
        private string geo;
        private int maxPublicationCount;

        public IList<string> Keywords { get => keywords; set => keywords = value; }
        public Locations Location { get => location; set => location = value; }
        public DateTime SinceDate { get => sinceDate; set => sinceDate = value; }
        public DateTime UntilDate { get => untilDate; set => untilDate = value; }
        public Languages Language { get => language; set => language = value; }
        public Filters Filter { get => filter; set => filter = value; }
        public SearchTypes SearchType { get => searchType; set => searchType = value; }
        public string Geo { get => geo; set => geo = value; }
        public int MaxPublicationCount { get => maxPublicationCount; set => maxPublicationCount = value; }

        
        public QueryConfiguration()
        {
           
        }
    }
}