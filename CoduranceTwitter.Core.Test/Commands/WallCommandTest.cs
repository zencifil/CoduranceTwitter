using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Commands;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Services;
using Moq;
using Xunit;

namespace CoduranceTwitter.Core.Test.Commands {
    
    public class WallCommandTest {
        
        [Fact]
        public void WallCommand_ShouldReturnAllTweets() {
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

			var userService = new UserService(userRepo.Object);

            var wallCommand = new WallCommand(new Receiver(userService));
            var actual = wallCommand.Execute(username, string.Empty);

            Assert.Equal(2, actual.Count);
        }
    }
}
