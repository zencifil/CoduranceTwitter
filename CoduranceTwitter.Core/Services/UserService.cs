using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public class UserService : IUserService {

        private IUser _user;
        
        public UserService(IUser user) {
            this._user = user;
        }

        public void AddTweet(ITweet tweet) {
            if (this._user.Tweets == null)
                this._user.Tweets = new List<ITweet>();

            this._user.Tweets.Add(tweet);
        }

        public void AddFollowing(IUser user) {
            if (this._user.Following == null)
                this._user.Following = new List<IUser>();

            this._user.Following.Add(user);
        }
    }
}
