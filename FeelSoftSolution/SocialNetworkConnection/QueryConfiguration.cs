using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class QueryConfiguration : IQueryConfiguration
    {
        private Filters filter;
        private string geo;
        private IList<string> keywords;
        private Languages language;
        private Locations location;
        private int maxPublicationCount;
        private SearchTypes searchType;
        private DateTime sinceDate;
        private DateTime untilDate;


        public Filters Filter { get => filter; set => filter = value; }
        public string Geo { get => geo; set => geo = value; }
        public IList<string> Keywords { get => keywords; set => keywords = value; }
        public Languages Language { get => language; set => language = value; }
        public Locations Location { get => location; set => location = value; }
        public int MaxPublicationCount { get => maxPublicationCount; set => maxPublicationCount = value; }
        public SearchTypes SearchType { get => searchType; set => searchType = value; }
        public DateTime SinceDate { get => sinceDate; set => sinceDate = value; }
        public DateTime UntilDate { get => untilDate; set => untilDate = value; }

        public QueryConfiguration()
        {
            Filter = Filters.None;
            Geo = "";
            Language = Languages.Spanish;
            Location = Locations.Colombia;
            MaxPublicationCount = 500;
            SearchType = SearchTypes.Mixed;

        }

      
    }
}