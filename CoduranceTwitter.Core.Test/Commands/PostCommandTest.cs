using Moq;
using Xunit;

using CoduranceTwitter.Core.Commands;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.Core.Test.Commands {

    public class PostCommandTest {

        [Fact]
        public void PostCommandPostsATweet() {
			var userRepo = new Mock<InMemoryRepo<User>>();

			var username = "ExistingUser";
			var user = new User(username);
			userRepo.Object.Add(user);
			userRepo.Object.Save(user);

			var userService = new UserService(userRepo.Object);

            var tweetText = "hello twitter, this is my first tweet...";
            var postCommand = new PostCommand(new Receiver(userService));
            postCommand.Execute(username, tweetText);

            Assert.Equal(tweetText, user.Tweets[user.Tweets.Count - 1].TweetText);
        }

    }
}
