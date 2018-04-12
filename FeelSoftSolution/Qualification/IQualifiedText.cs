using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkConnection;

namespace Qualification
{
    public interface IQualifiedText
    {
        IList<IPublication> DefaultQualifiedPublications(string resource);



    }
}
