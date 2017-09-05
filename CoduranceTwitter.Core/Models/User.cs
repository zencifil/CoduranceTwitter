using System.Collections.Generic;

namespace CoduranceTwitter.Core.Models {

    public class User : IEntity {

        string _username;
        IList<Tweet> _tweets;
        IList<User> _following;

        public User(string username) {
            _username = username;
            _tweets = new List<Tweet>();
            _following = new List<User>();
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
