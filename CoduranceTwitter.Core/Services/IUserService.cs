using System.Collections.Generic;

using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {

    public interface IUserService {

        void PostTweet(string username, string tweetText);
        void FollowUser(string username, string usernameToFollow);
        IList<Tweet> GetTweetList(string username);
        User GetUser(string username);
        void RegisterUser(string username);
        IList<string> GetWall(string username);
    }
}
