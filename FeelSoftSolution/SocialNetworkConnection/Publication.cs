using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;

namespace SocialNetworkConnection
{
    public class Publication : IPublication
    {

        private string id;
        private string message;
        private string wroteBy;
        private Languages language;
        private int favorability;
        private DateTime createDate;
        private Locations location;
        private IPublication parent;
        private IList<IPublication> responses;

        public string Id { get => id; set => id = value; }
        public string Message { get => message; set => message = SetCorrectInfo(value); }
        public string WroteBy { get => wroteBy; set => wroteBy = SetCorrectInfo(value); }
        public Languages Language { get => language; set => language = value; }
        public int Favorability { get => favorability; set => favorability = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public Locations Location { get => location; set => location = value; }
        public IPublication Parent { get => parent; set => parent = value; }
        public IList<IPublication> Responses { get => responses; set => responses = value; }

        public Publication()
        {
            Language = Languages.Spanish;
            Location = Locations.Colombia;
            createDate = QueryConfiguration.NONE_DATE;
        }
        public int CompareBy(IPublication other, Comparison<IPublication> comparator)
        {
            return comparator.Invoke(this, other);
        }

        private string SetCorrectInfo(string value)
        {
            string withoutSplit = value.Replace('|', ':');
            string withoutLines = withoutSplit.Replace('\n', '\t');
            return withoutLines;
        }

        public int CompareTo(IPublication other)
        {
            return this.id.CompareTo(other.Id);
        }

        public string ToExportFormat()
        {
            string splitSeparator = "|";
            string format = Id + splitSeparator;
            format += WroteBy + splitSeparator;
            format += CreateDate.ToShortDateString() + splitSeparator;
            format += message + splitSeparator;
            format += LanguageToExportFormat() + splitSeparator;
            format += LocationToExportFormat() + splitSeparator;
            format += ParentToExportFormat() + splitSeparator;
            format += ResponsesToExportFormat();

            return format;
        }

        private string ResponsesToExportFormat()
        {
            string format = "NONE";
            if (Responses != null)
            {
                format = "";
                string splitSeparator = ",";
                for (int i = 0; i < Responses.Count - 1; i++)
                {
                    format += Responses.ElementAt(i).Id + splitSeparator;
                }

                format += Responses.ElementAt(Responses.Count - 1).Id;
            }
            return format;
        }

        private string ParentToExportFormat()
        {
            string format = Parent != null ? parent.Id : "NONE";
            return format;
        }

        private string LocationToExportFormat()
        {
            string format = QueryConfiguration.LocationToExportFormat(Location);
            return format;
        }

        private string LanguageToExportFormat()
        {
            string format = QueryConfiguration.LanguageToExportFormat(Language);
            return format;
        }

        internal static IPublication ParsePublication(string line, out string parent, out IList<string> responses)
        {

            string[] info = line.Split('|');
            string id = info[0];
            

            string wroteBy = info[1];
            DateTime createdDate = DateTime.Parse(info[2]);
            string message = info[3];
            Languages language = QueryConfiguration.ParseLanguage(info[4]);
            Locations location = QueryConfiguration.ParseLocation(info[5]);
            parent = info[6].Equals("NONE", StringComparison.OrdinalIgnoreCase) ? null : info[6];

            responses = null;
            if (!info[7].Equals("NONE", StringComparison.OrdinalIgnoreCase))
            {
                string[] responsesInfo = info[7].Split(',');
                responses = new List<string>(responsesInfo);
            }

            IPublication publication = new Publication
            {
                Id = id,
                WroteBy = wroteBy,
                CreateDate = createdDate,
                Message = message,
                Language = language,
                Location = location
            };

            return publication;
        }
    }
}

