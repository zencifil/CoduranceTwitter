using CoduranceTwitter.Core.Commands;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Services;
using Moq;
using Xunit;

namespace CoduranceTwitter.Core.Test.Commands {

    public class ReadCommandTest {

        [Fact]
        public void ReadCommandReturnsAListOfTweet() {
			var userRepo = new Mock<InMemoryRepo<User>>();

			var username = "ExistingUser";
			var user = new User(username);
			userRepo.Object.Add(user);
			userRepo.Object.Save(user);

			var userService = new UserService(userRepo.Object);

            var tweet1 = "This could be my first tweet.";
            var tweet2 = "And this could be my second...";
            userService.PostTweet(username, tweet1);
            userService.PostTweet(username, tweet2);

            var readCommand = new ReadCommand(new Receiver(userService));
            var tweets = readCommand.Execute(username, string.Empty);

            Assert.Equal(2, tweets.Count);
        }
    }
}
