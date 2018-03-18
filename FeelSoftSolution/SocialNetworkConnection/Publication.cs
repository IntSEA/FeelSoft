using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class Publication : IPublication
    {
        public static DateTime NONE_DATE = new DateTime(2006,01,01);

        private string id;
        private string message;
        private string wroteBy;
        private Languages language;
        private int favorability;
        private DateTime createDate;
        private Locations location;

        public string Id { get => id; set => id = value; }
        public string Message { get => message; set => message = value; }
        public string WroteBy { get => wroteBy; set => wroteBy = value; }
        public Languages Language { get => language; set => language = value; }
        public int Favorability { get => favorability; set => favorability = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public Locations Location { get => location; set => location = value; }


        public Publication()
        {
            Language = Languages.Spanish;
            Location = Locations.Colombia;
            createDate = NONE_DATE;
        }
        public int CompareBy(IPublication other, Comparison<IPublication> comparator)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IPublication other)
        {
            throw new NotImplementedException();
        }
    }
}