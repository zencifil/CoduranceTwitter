using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Services {
    
    public class UserService : IUserService {

        private IUser _user;
        
        public UserService(IUser user) {
            _user = user;
        }

        public void AddTweet(ITweet tweet) {
            if (_user.Tweets == null)
                _user.Tweets = new List<ITweet>();

            _user.Tweets.Add(tweet);
        }


    }
}
