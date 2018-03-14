using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface IQueryConfiguration
    {
        IList<string> Keywords { get; set; }
        string Location { get; set; }
        DateTime SinceDate { get; set; }
        DateTime UntilDate { get; set; }
        string Language { get; set; }
        string Filter { get; set; }
        int SearchType { get; set; }
        string Geo { get; set; }
        int MaxPublicationCount { get; set; }
    }
}