using System;
using Moq;
using Xunit;

using CoduranceTwitter.Core.Services;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;

namespace CoduranceTwitter.Core.Test.Services {
    
    public class UserServiceTest {
        
        IUserService _userService;

        public UserServiceTest() {
            var userRepo = new Mock<InMemoryRepo<User>>();

            var username = "ExistingUser";
            var user = new User(username);
            userRepo.Object.Add(user);
            userRepo.Object.Save(user);

            _userService = new UserService(userRepo.Object);
        }

        [Fact]
        public void PostTweet_ShouldAddTweetToList() {
			var username = "ExistingUser";
            var tweetText = "This tweet is sent by service.";

            _userService.PostTweet(username, tweetText);

            var actualText = _userService.GetTweetList(username)[0].TweetText;

			Assert.Equal(tweetText, actualText);
        }

        [Fact]
        public void WhenUserNotExistFollowUser_ShouldThrowException() {
            var username = "NonExistingUser";
            var usernameToFollow = "user2follow";

            Assert.Throws(typeof(ArgumentException), () => { _userService.FollowUser(username, usernameToFollow); });
        }

        [Fact]
        public void GetTweets_ShouldReturnTweetList() {
            var username = "ExistingUser";

            var tweet1 = "Hi, this is my first tweet.";
            var tweet2 = "Hi, this is my second tweet.";

            _userService.PostTweet(username, tweet1);
            _userService.PostTweet(username, tweet2);

            Assert.Equal(2, _userService.GetTweetList(username).Count);
        }
    }
}
