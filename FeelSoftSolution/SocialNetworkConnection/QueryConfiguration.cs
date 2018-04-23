using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkConnection
{
    public class QueryConfiguration : IQueryConfiguration
    {
        public static DateTime NONE_DATE = new DateTime(1731, 1, 1);


        private Filters filter;
        private string geo;
        private IList<string> keywords;
        private Languages language;
        private Locations location;
        private int maxPublicationCount;
        private SearchTypes searchType;
        private DateTime sinceDate;
        private DateTime untilDate;
        private string name;
        private int maxResponsesCount;


        public Filters Filter { get => filter; set => filter = value; }
        public string Geo { get => geo; set => geo = value; }
        public IList<string> Keywords { get => keywords; set => keywords = value; }
        public Languages Language { get => language; set => language = value; }
        public Locations Location { get => location; set => location = value; }
        public int MaxPublicationCount { get => maxPublicationCount; set => maxPublicationCount = value; }
        public SearchTypes SearchType { get => searchType; set => searchType = value; }
        public DateTime SinceDate { get => sinceDate; set => sinceDate = value; }
        public DateTime UntilDate { get => untilDate; set => untilDate = value; }
        public string Name { get => name; set => name = value; }
        public int MaxResponsesCount { get => maxResponsesCount; set => maxResponsesCount = value; }

        public QueryConfiguration()
        {
            InitializeQuery();

        }

        public QueryConfiguration(string queryFormat)
        {
            InitializeQuery();
            ParseFromQueryFormat(queryFormat);
        }

        private void ParseFromQueryFormat(string queryFormat)
        {
            string[] info = queryFormat.Split(new string[] { Environment.NewLine },
               StringSplitOptions.None);
            Name = info[0];
            ParseKeywords(info[1]);
            Location = ParseLocation(info[2]);
            Language = ParseLanguage(info[3]);
            SearchType = ParseSearchType(info[4]);
            Filter = ParseFilter(info[5]);
            SinceDate = DateTime.Parse(info[6]);
            UntilDate = DateTime.Parse(info[7]);
            MaxPublicationCount = int.Parse(info[8]);
            MaxResponsesCount = int.Parse(info[9]);
            Geo = info[10];
        }

        private static Filters ParseFilter(string format)
        {
            Filters fil = Filters.Hashtag;
            switch (format)
            {

                case "News":
                    {
                        fil = Filters.News;
                        break;
                    }
                case "None":
                    {
                        fil = Filters.None;
                        break;
                    }
                case "Image":
                    {
                        fil = Filters.Image;
                        break;
                    }
                case "Video":
                    {
                        fil = Filters.Video;
                        break;
                    }
            }

            return fil;
        }

        private static SearchTypes ParseSearchType(string format)
        {
            SearchTypes st = SearchTypes.Mixed;
            switch (format)
            {
                case "Popular":
                    {
                        st = SearchTypes.Popular;
                        break;
                    }

                case "Recent":
                    {
                        st = SearchTypes.Recent;
                        break;
                    }
            }

            return st;
        }

        public static Languages ParseLanguage(string format)
        {
            Languages lang = Languages.English;
            switch (format)
            {

                case "Spanish":
                    {
                        lang = Languages.Spanish;
                        break;
                    }
            }

            return lang;
        }

        public static Locations ParseLocation(string format)
        {
            Locations loc = Locations.Colombia;
            switch (format)
            {

                case "United States":
                    {
                        loc = Locations.USA;
                        break;
                    }

            }

            return loc;
        }

        private void ParseKeywords(string keywordFormat)
        {
            string[] keys = keywordFormat.Split('|');
            Keywords = new List<string>(keys);

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
            string parse = Name;
            return parse;
        }

        public string ToExportFormat()
        {
            string format = Name + Environment.NewLine;
            format += KeywordsToExportFormat() + Environment.NewLine;
            format += LocationToExportFormat(Location) + Environment.NewLine;
            format += LanguageToExportFormat(Language) + Environment.NewLine;
            format += SearchTypeToExportFormat(SearchType) + Environment.NewLine;
            format += FilterToExportFormat(Filter) + Environment.NewLine;
            format += SinceDateToExportFormat() + Environment.NewLine;
            format += UntilDateToExportFormat() + Environment.NewLine;
            format += MaxPublicationCountToExportFormat() + Environment.NewLine;
            format += MaxResponsesCountToExportFormat() + Environment.NewLine;
            format += GeoToExportFormat() + Environment.NewLine;

            return format;
        }

        private string GeoToExportFormat()
        {
            return Geo;
        }

        private string MaxResponsesCountToExportFormat()
        {
            return MaxResponsesCount + "";
        }

        private string MaxPublicationCountToExportFormat()
        {
            return MaxPublicationCount + "";
        }

        private string UntilDateToExportFormat()
        {
            return UntilDate.ToShortDateString();
        }

        private string SinceDateToExportFormat()
        {
            return SinceDate.ToShortDateString();
        }

        public static string FilterToExportFormat(Filters fil)
        {
            string filter = "";

            switch (fil)
            {
                case Filters.News:
                    {
                        filter = "News";
                        break;
                    }
                case Filters.Hashtag:
                    {
                        filter = "Hashtag";
                        break;
                    }
                case Filters.Image:
                    {
                        filter = "Image";
                        break;
                    }
                case Filters.None:
                    {
                        filter = "None";
                        break;
                    }
                case Filters.Video:
                    {
                        filter = "Video";
                        break;
                    }
            }

            return filter;

        }

        public static string SearchTypeToExportFormat(SearchTypes st)
        {
            string format = "";
            switch (st)
            {
                case SearchTypes.Mixed:
                    {
                        format = "mixed";
                        break;
                    }
                case SearchTypes.Popular:
                    {
                        format = "popular";
                        break;
                    }
                case SearchTypes.Recent:
                    {
                        format = "recent";
                        break;
                    }
            }
            return format;
        }

        public static string LanguageToExportFormat(Languages lang)
        {
            string format = "";

            switch (lang)
            {
                case Languages.English:
                    {
                        format = "English";
                        break;
                    }
                case Languages.Spanish:
                    {
                        format = "Spanish";
                        break;
                    }

            }

            return format;
        }

        public static string LocationToExportFormat(Locations location)
        {
            string loc = "";
            switch (location)
            {
                case Locations.Colombia:
                    {
                        loc = "Colombia";
                        break;
                    }
                case Locations.USA:
                    {
                        loc = "United States";
                        break;
                    }

            }

            return loc;
        }

        private string KeywordsToExportFormat()
        {
            string format = "";
            for (int i = 0; i < Keywords.Count - 1; i++)
            {
                format += Keywords.ElementAt(i) + "|";
            }
            format += Keywords.ElementAt(Keywords.Count - 1);

            return format;
        }

        public object Clone()
        {

            return this.MemberwiseClone();
        }
    }
}