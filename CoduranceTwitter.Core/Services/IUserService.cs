using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public interface IUserService {

        void AddTweet(Tweet tweet);
        void AddFollowing(User user);
        IList<Tweet> GetTweetList();
    }
}
