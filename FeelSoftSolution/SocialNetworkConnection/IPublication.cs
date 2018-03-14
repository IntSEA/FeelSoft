using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface IPublication: IComparable<IPublication>
    {
        string Message { get;}
        string WroteBy { get;}
        string Language { get; }
        int Favorability { get;set; }
        DateTime CreateDate { get; }
        string Location { get; }

        int CompareBy(IPublication other, Comparison<IPublication> comparator);
        void GetLenghtMessage();
    }
}