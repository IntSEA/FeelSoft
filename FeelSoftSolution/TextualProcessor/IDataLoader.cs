using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;


namespace TextualProcessor
{
    public interface IDataLoader
    {
        
        IList<String> StopWords { get; set; }
        IDictionary<String, String> CompoundWords { get; set; }
        IList<IPublication> LoadRawPublicationsWithResources(string resource);


    }
}
