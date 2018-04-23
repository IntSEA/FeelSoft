using System;
using System.Collections.Generic;

namespace SocialNetworkConnection
{
    public interface IQueryConfiguration : ICloneable
    {
        string Name { get; set; }
        IList<string> Keywords { get; set; }
        Locations Location { get; set; }
        DateTime SinceDate { get; set; }
        DateTime UntilDate { get; set; }
        Languages Language { get; set; }
        Filters Filter { get; set; }
        SearchTypes SearchType { get; set; }
        string Geo { get; set; }
        int MaxPublicationCount { get; set; }
        int MaxResponsesCount { get; set; }
        string ToExportFormat();



    }
}