using System;
using System.Collections;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.Core {
    
    public sealed class Receiver {

        private bool _disposed;
        private static volatile Receiver _receiver;
        private static readonly object _syncLock = new object();

        private List<IUser> _users;

        private Receiver() {
            _users = new List<IUser>();
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

        public IList<string> PerformPost(string username, string data) {
            CreateUser(username);
            var user = GetUser(username);
            IUserService userService = new UserService(user);
            ITweet tweet = new Tweet(data);
            userService.AddTweet(tweet);

            // might return actual post but for now just an empty list.
            return new List<string>();
        }

        public IList<string> PerformFollow(string username, string usernameToFollow) {
            var user = GetUser(username);
            if (user == null)
                throw new ArgumentException("User does not exist!");

            var userToFollow = GetUser(usernameToFollow);
            if (userToFollow == null)
                throw new ArgumentException("The user you're trying to follow does not exist!");

            IUserService userService = new UserService(user);
            userService.AddFollowing(userToFollow);

            // just return an empty string
            return new List<string>();
        }

        public IList<string> PerformRead(string username) {
            var user = GetUser(username);
            if (user == null)
                throw new ArgumentException("User does not exists!");

            var userService = new UserService(user);
            var tweets = userService.GetTweetList();

            var returnList = new List<string>();
            foreach (var tweet in tweets) {
                returnList.Add(tweet.TweetText);
            }

            return returnList;
        }

        public void CreateUser(string username) {
            var user = GetUser(username);
            if (user == null)
                this._users.Add(new Models.User(username));
        }

        public IUser GetUser(string username) {
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
