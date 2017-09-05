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

        public IList<Tweet> GetTweetList(string username) {
            var user = GetUser(username);
            if (user == null)
                throw new ArgumentException("User does not exist!");
            
            return user.Tweets;
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

            return null;
        }
    }
}
