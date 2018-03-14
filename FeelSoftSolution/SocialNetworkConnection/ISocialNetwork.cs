﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworkConnection
{
    public interface ISocialNetwork
    {
        string Name { get; }
        string Credential { get; }
        PublicationSearcher Searcher { get; set; }

       
    }
}