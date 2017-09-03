using System;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core {
    
    public interface IUser {

        void AddTweet(Tweet tweet);
    }
}
