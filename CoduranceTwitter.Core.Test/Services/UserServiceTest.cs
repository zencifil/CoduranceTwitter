using System;
using System.Collections.Generic;

using Moq;
using Xunit;

using CoduranceTwitter.Core.Services;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;

namespace CoduranceTwitter.Core.Test.Services {
    
    public class UserServiceTest {
        
        IUserService _userService;

        public UserServiceTest() {
            var username = "ExistingUser";
            var user = new User(username) {
                Tweets = new List<Tweet>()
            };
            user.Tweets.Add(new Tweet("This tweet is my first tweet."));

            var username2 = "ExistingUser2";
            var user2 = new User(username2) {
                Tweets = new List<Tweet>()
            };
            user2.Tweets.Add(new Tweet("This is second user's tweet."));

            user.Following = new List<User> {
                user2
            };

            var userRepo = new Mock<IRepository<User>>();
            userRepo.SetupGet(u => u.Entities).Returns(new List<User> { user, user2 });

            _userService = new UserService(userRepo.Object);
        }

   //     [Fact]
   //     public void WhenUserNotExists_PostTweet_ShouldCreateAUser() {
			//var username = "NonExistingUser";
			//var tweetText = "This tweet is sent by service.";

        //    var userServiceMock = new Mock<IUserService>();
        //    userServiceMock.SetupSequence(u => u.GetUser(It.IsAny<string>()))
        //                   .Returns(new User(username));
        //    userServiceMock.Setup(u => u.RegisterUser(It.Is<string>(s => s == username)))
        //                   .Verifiable();

        //    userServiceMock.Object.PostTweet(username, tweetText);

        //    userServiceMock.Verify();
        //}

        [Fact]
        public void WhenUserNotExist_FollowUser_ShouldThrowException() {
            var username = "NonExistingUser2";
            var usernameToFollow = "ExistingUser";

            Assert.Throws(typeof(ArgumentException), () => { _userService.FollowUser(username, usernameToFollow); });
        }

		[Fact]
		public void WhenUserToFollowNotExist_FollowUser_ShouldThrowException() {
			var username = "ExistingUser";
			var usernameToFollow = "user2follow";

			Assert.Throws(typeof(ArgumentException), () => { _userService.FollowUser(username, usernameToFollow); });
		}

        [Fact]
        public void GetTweets_ShouldReturnTweetList() {
            var username = "ExistingUser";

            Assert.Equal(1, _userService.GetTweetList(username).Count);
        }

        [Fact]
        public void WhenUserNotExists_Wall_ShouldThrowException() {
            var username = "NonExistingUser";

            Assert.Throws(typeof(ArgumentException), () => { _userService.GetWall(username); });
        }

    }
}
