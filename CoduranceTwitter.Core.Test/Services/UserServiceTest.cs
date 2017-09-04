using System;
using Xunit;
using CoduranceTwitter.Core.Services;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Test.Services {
    
    public class UserServiceTest {

        [Fact]
        public void AddTweetShouldAddTweetToList() {
			var username = "serviceUser";
            var user = new User(username);
            var userService = new UserService(user);

            var tweetText = "This tweet is sent by service.";
            var tweet = new Tweet(tweetText);

            userService.AddTweet(tweet);

			Assert.Equal(tweetText, user.Tweets[user.Tweets.Count - 1].TweetText);
        }

        [Fact]
        public void AddFollowingShouldAddUserToList() {
            var username = "firstUser";
            var user = new User(username);
            var userService = new UserService(user);

            var usernameToFollow = "user2follow";
            var userToFollow = new User(usernameToFollow);

            userService.AddFollowing(userToFollow);

            Assert.Equal(usernameToFollow, user.Following[user.Following.Count - 1].Username);
        }
    }
}
