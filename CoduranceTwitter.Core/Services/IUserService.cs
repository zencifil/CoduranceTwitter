using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public interface IUserService {

        void AddTweet(ITweet tweet);
        void AddFollowing(IUser user);
        IList<ITweet> GetTweetList();
    }
}
