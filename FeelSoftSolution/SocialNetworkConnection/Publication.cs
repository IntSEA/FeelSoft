using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public class Publication : IPublication
    {
        private string message;
        private string wroteBy;
        private string language;
        private int favorability;
        private DateTime createDate;
        private string location;

        public string Message { get =>message ; }
        public string WroteBy { get => wroteBy; }
        public string Language { get => language; }
        public int Favorability { get => favorability;set => favorability = value; }
        public DateTime CreateDate { get => createDate; }
        public string Location { get => location; }

        public int CompareBy(IPublication other, Comparison<IPublication> comparator)
        {
            return comparator.Invoke(this,other);
        }

        public int CompareTo(IPublication other)
        {
            throw new NotImplementedException();
        }
    }
}