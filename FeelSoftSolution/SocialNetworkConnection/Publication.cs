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
        public string WroteBy { get => throw new NotImplementedException(); }
        public string Language { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Favorability { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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