using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Models {
    
    public class User : IUser {

        private string _username;
        private IList<Models.ITweet> _tweets;
        private IList<Models.IUser> _following;

        public User(string username) {
            this._username = username;
            this._tweets = new List<Models.ITweet>();
            this._following = new List<Models.IUser>();
        }

        public string Username {
            get {
                return _username;
            }
            set {
                _username = value;
            }
        }

        public IList<Models.ITweet> Tweets {
            get {
                return _tweets;
            }
            set {
                _tweets = value;
            }
        }

        public IList<Models.IUser> Following {
            get {
                return _following;
            }
            set {
                _following = value;
            }
        }


    }
}
