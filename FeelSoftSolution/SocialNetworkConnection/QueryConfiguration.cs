using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SocialNetworkConnection
{
    public class QueryConfiguration : IQueryConfiguration
    {
        private IList<string> keywords;
        private string location;
        private DateTime sinceDate;
        private DateTime untilDate;
        private string language;
        private string filter;
        private int searchType;
        private string geo;

        public IList<string> Keywords { get => keywords; set => keywords = value; }
        public string Location { get => location; set => location = value; }
        public DateTime SinceDate { get => sinceDate; set => sinceDate = value; }
        public DateTime UntilDate { get => untilDate; set => untilDate = value; }
        public string Language { get => language; set => language = value; }
        public string Filter { get => filter; set => filter = value; }
        public int SearchType { get => searchType; set => searchType = value; }
        public string Geo { get => geo; set => geo = value; }
    }
}