using System;
using System.Text;


namespace SocialNetworkConnection
{
    public class Publication : IPublication
    {
        public const string END_LINE = "&!!!END!!!&";

        private string id;
        private string message;
        private string wroteBy;
        private Languages language;
        private DateTime createDate;
        private Locations location;
        private string configurationName;
        private string lemmatizedMessage;

        public string Id { get => id; set => id = value; }
        public string Message { get => message; set => message = SetCorrectInfo(value); }
        public string WroteBy { get => wroteBy; set => wroteBy = SetCorrectInfo(value); }
        public Languages Language { get => language; set => language = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public Locations Location { get => location; set => location = value; }
        public string ConfigurationName { get => configurationName; set => configurationName = value; }
        public string LemmatizedMessage { get => lemmatizedMessage; set => lemmatizedMessage = value; }

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
            string withoutQuotes = withoutLines.Replace("&quot", "");
            string withSpecialCharacter = withoutQuotes.Replace("&#10", "");

            return withSpecialCharacter;
        }

        public static string DecodeMessage(string value)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            string decodeString = Encoding.UTF8.GetString(bytes);
            return decodeString;
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
            format += configurationName + splitSeparator;
            format += lemmatizedMessage ?? "not yet lemmatized";
            format +=  splitSeparator;

            format += END_LINE;

            return format;
        }

        string LocationToExportFormat()
        {
            string format = QueryConfiguration.LocationToExportFormat(Location);
            return format;
        }

        private string LanguageToExportFormat()
        {
            string format = QueryConfiguration.LanguageToExportFormat(Language);
            return format;
        }

        public static IPublication ParsePublication(string line)
        {
            string[] info = line.Split('|');
            string id = info[0];

            if (info.Length < 8)
            {
                throw new Exception("wrong format in line: " + line + " with id: " + id);
            }

            string wroteBy = info[1];

            //DateTime createdDate = DateTime.Parse(info[2]);

            DateTime createdDate;
            try
            {
                createdDate = DateTime.Parse(info[2]);
            }
            catch
            {
                string[] dates = info[2].Split('/');
                string cero = "";
                string cero2 = "";
                if (Convert.ToInt32(dates[1]) < 10)
                {
                    cero = "0";
                }
                if (Convert.ToInt32(dates[0]) < 10)
                {
                    cero2 = "0";
                }
                string nuevo = cero + dates[1] + "/" + cero2 + dates[0] + "/" + dates[2];

                createdDate = DateTime.Parse(nuevo);
            }
            string message = info[3];

            Languages language = QueryConfiguration.ParseLanguage(info[4]);
            Locations location = QueryConfiguration.ParseLocation(info[5]);
            string configurationName = info[6];
            string lemmatizedMessage = "not yet lemmatized";

            lemmatizedMessage = info[7];

            IPublication publication = new Publication
            {
                Id = id,
                WroteBy = wroteBy,
                CreateDate = createdDate,
                Message = message,
                Language = language,
                Location = location,
                ConfigurationName = configurationName,
                LemmatizedMessage = lemmatizedMessage
            };

            return publication;
        }



        public static bool IsTweet(IPublication publication)
        {
            string twitter = publication.Id.Split(':')[0];

            return twitter.Equals("Twitter");
        }
    }
}

