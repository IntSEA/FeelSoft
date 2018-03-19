using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class QueryConfiguration : IQueryConfiguration
    {
        public static DateTime NONE_DATE = new DateTime(1731, 1,1);

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
            InitializeQuery();           

        }

        private void InitializeQuery()
        {
            Keywords = new List<string>();
            Filter = Filters.None;
            Geo = "";
            Language = Languages.Spanish;
            Location = Locations.Colombia;
            MaxPublicationCount = 500;
            SearchType = SearchTypes.Mixed;
            sinceDate = NONE_DATE;
            untilDate = NONE_DATE;
        }

        public QueryConfiguration(string[] keyWords)
        {
            InitializeQuery();
            ((List<string>)Keywords).AddRange(keyWords);
        }

        
        public override String ToString()
        {
            string parse = sinceDate.ToString()+" -- "+UntilDate.ToString()+" Max: "+maxPublicationCount;
            return parse;
        }
      
    }
}