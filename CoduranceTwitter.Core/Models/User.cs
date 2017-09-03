using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Models {
    
    public class User : IUser {

        private string _username;
        private IEnumerable _tweets;
        private IList _following;

        public User(string username) {
            this._username = username;
            this._tweets = new List<Tweet>();
            this._following = new List<User>();
        }

        public string Username => _username;

        public IEnumerable Tweets => _tweets;

        public IList Following => _following;
    }
}
