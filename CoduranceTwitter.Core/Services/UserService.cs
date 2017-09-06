using System;
using System.Collections.Generic;
using System.Linq;

using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;

namespace CoduranceTwitter.Core.Services {

    public class UserService : IUserService {

        IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository) {
            _userRepository = userRepository;
        }

        public void PostTweet(string username, string tweetText) {
            var user = GetUser(username);

            if (user == null) {
                RegisterUser(username);
                user = GetUser(username);
            }

            if (user.Tweets == null)
                user.Tweets = new List<Tweet>();

            user.Tweets.Add(new Tweet(tweetText));
        }

        public void FollowUser(string username, string usernameToFollow) {
            var user = GetUser(username);
            if (user == null)
                throw new ArgumentException("User does not exist!");

            var userToFollow = GetUser(usernameToFollow);
            if (userToFollow == null)
                throw new ArgumentException("The user you're trying to follow does not exist!");

            if (user.Following == null)
                user.Following = new List<User>();

            user.Following.Add(userToFollow);
        }

        public IList<string> GetTweetList(string username) {
            var user = GetUser(username);
            if (user == null)
                throw new ArgumentException("User does not exist!");

            return user.Tweets.OrderByDescending(a => a.SendDate)
                              .Select(a => $"{a.TweetText} {TimeAgo(a.SendDate)}")
                              .ToList();

        }

        public User GetUser(string username) {
            return _userRepository.Entities.FirstOrDefault(u => u.Username == username);
        }

        public void RegisterUser(string username) {
            var user = GetUser(username);

            if (user != null)
                throw new Exception("User already exists!");

            _userRepository.Add(new User(username));
        }

        public IList<string> GetWall(string username) {
            var user = GetUser(username);

            if (user == null)
                throw new ArgumentException("User does not exist!");

            var tweets = user.Tweets.Select(t => new { user.Username, Tweet = t }).ToList();

            foreach (var u in user.Following) {
                foreach (var t in u.Tweets) {
                    tweets.Add(new { u.Username, Tweet = t });
                }
            }

            return tweets.OrderByDescending(a => a.Tweet.SendDate)
                         .Select(a => $"{a.Username} - {a.Tweet.TweetText} {TimeAgo(a.Tweet.SendDate)}")
                         .ToList();
        }

        private string TimeAgo(DateTime sendDate) {
            TimeSpan span = DateTime.Now - sendDate;
            var innerText = string.Empty;

            if (span.Days > 30)
                innerText = sendDate.ToString("dd.MM.yyyy");
            else if (span.Days > 0) {
                var day = span.Days == 1 ? "day" : "days";
                innerText = $"{span.Days} {day}";
            }
            else if (span.Hours > 0) {
                var hour = span.Hours == 1 ? "hour" : "hours";
                innerText = $"{span.Hours} {hour}";
            }
            else if (span.Minutes > 0) {
                var minute = span.Minutes == 1 ? "minute" : "minutes";
                innerText = $"{span.Minutes} {minute}";
            }
            else if (span.Seconds > 0) {
                var second = span.Seconds == 1 ? "second" : "seconds";
                innerText = $"{span.Seconds} {second}";
            }

            if (string.IsNullOrEmpty(innerText))
                return string.Empty;

            return $"({innerText} ago)";
        }
    }
}
