using System;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public interface IUserService {

        void AddTweet(ITweet tweet);
    }
}
