using System;

namespace SocialNetworkConnection
{
    public interface IPublication : IComparable<IPublication>
    {
        string Id { get; set; }
        string Message { get; set; }
        string WroteBy { get; set; }
        Languages Language { get; set; }
        DateTime CreateDate { get; set; }
        Locations Location { get; set; }
        string ConfigurationName { get; set; }
        string LemmatizedMessage { get; set; }

        int CompareBy(IPublication other, Comparison<IPublication> comparator);
        string ToExportFormat();
    }
}