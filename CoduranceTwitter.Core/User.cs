using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core {
    
    public class User : IUser {

        private Models.IUser _user;
        
        public User(Models.IUser user) {
            _user = user;
        }

        public void AddTweet(Models.ITweet tweet) {
            if (_user.Tweets == null)
                _user.Tweets = new List<Models.ITweet>();

            _user.Tweets.Add(tweet);
        }


    }
}
