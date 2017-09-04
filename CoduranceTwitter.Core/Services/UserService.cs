using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public class UserService : IUserService {

        private User _user;
        
        public UserService(User user) {
            this._user = user;
        }

        public void AddTweet(Tweet tweet) {
            if (this._user.Tweets == null)
                this._user.Tweets = new List<Tweet>();

            this._user.Tweets.Add(tweet);
        }

        public void AddFollowing(User user) {
            if (this._user.Following == null)
                this._user.Following = new List<User>();

            this._user.Following.Add(user);
        }

        public IList<Tweet> GetTweetList() {
            return this._user.Tweets;
        }
    }
}
