using System;
using System.Collections;

namespace CoduranceTwitter.Core.Models {
    
    public interface IUser {
        string Username { get; }
        IEnumerable Tweets { get; }
        IList Following { get; }
    }
}
