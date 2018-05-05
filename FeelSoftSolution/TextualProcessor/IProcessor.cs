using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;
using Lematization;

namespace TextualProcessor
{
    public interface IProcessor
    {
        
        ISearchDataSet DataSet { get; set; }
        IDataLoader DataLoader { get; set; }
        Stemmer Lemmatizer { get; set; }

        IList<IPublication> LemmatizedPublications(string path);
        IList<IPublication> LemmatizedPublicationsWithResources(string resource);
        IList<IPublication> LemmatizedPublications(IList<IPublication> path);
    }
}
