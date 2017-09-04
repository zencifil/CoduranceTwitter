using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Models {
    
    public class User : IEntity {

        private string _username;
        private IList<Tweet> _tweets;
        private IList<User> _following;

        public User(string username) {
            this._username = username;
            this._tweets = new List<Tweet>();
            this._following = new List<User>();
        }

        public string Username {
            get {
                return _username;
            }
            set {
                _username = value;
            }
        }

        public IList<Tweet> Tweets {
            get {
                return _tweets;
            }
            set {
                _tweets = value;
            }
        }

        public IList<User> Following {
            get {
                return _following;
            }
            set {
                _following = value;
            }
        }


    }
}
