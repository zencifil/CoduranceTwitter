using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core {
    
    public sealed class Receiver {

        private bool _disposed = false;
        private static volatile Receiver _receiver;
        private static readonly object _syncLock = new object();

        private List<Models.IUser> _users;

        private Receiver() {
            _users = new List<Models.IUser>();
        }

        public static Receiver Instance {
            get {
                if (_receiver != null)
                    return _receiver;

                lock (_syncLock) {
                    if (_receiver == null)
                        _receiver = new Receiver();
                }

                return _receiver;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (_disposed)
                return;

            if (disposing) {
                _receiver = null;
                _users = null;
                _disposed = true;
            }
        }

        public IEnumerable PerformPost(string username, Models.ITweet tweet) {
            CreateUser(username);
            var user = GetUser(username);
            IUser userController = new User(user);
            userController.AddTweet(tweet);

            return new List<string>();
        }

        public void CreateUser(string username) {
            var user = GetUser(username);
            if (user == null)
                this._users.Add(new Models.User(username));
        }

        public Models.IUser GetUser(string username) {
            return this._users.Find(u => u.Username == username);
        }

        public List<Models.ITweet> GetUserTweets(string username) {
            List<Models.ITweet> tweetList = new List<Models.ITweet>();
            var tweets = this._users.Find(u => u.Username == username).Tweets;
            foreach (var tweet in tweets) {
                tweetList.Add((Models.ITweet)tweet);
            }

            return tweetList;
        }

    }
}
