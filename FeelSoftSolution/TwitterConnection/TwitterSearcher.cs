using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialNetworkConnection;

namespace TwitterConnection
{
    public class TwitterSearcher : PublicationSearcher
    {
        public TwitterSearcher(string credential) : base(credential)
        {

        }

        public override IList<IPublication> SearchPublications(IList<IQueryConfiguration> queriesConfigurations)
        {
            throw new NotImplementedException();
        }

        public override IList<IPublication> SearchPublications(IQueryConfiguration queryConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}