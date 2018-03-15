using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface IPublication: IComparable<IPublication>
    {
        string Message { get; set; }
        string WroteBy { get; set; }
        Languages Language { get; set; }
        int Favorability { get;set; }
        DateTime CreateDate { get; set; }
        Locations Location { get; set; }

        int CompareBy(IPublication other, Comparison<IPublication> comparator);
    }
}