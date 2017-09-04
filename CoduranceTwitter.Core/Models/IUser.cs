using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Models {
    
    public interface IUser {
        string Username { get; set; }
        IList<Models.ITweet> Tweets { get; set; }
        IList<Models.IUser> Following { get; set; }
    }
}
