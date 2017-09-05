using Moq;
using Xunit;

using CoduranceTwitter.Core.Commands;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.Core.Test.Commands {

    public class FollowCommandTest {

        [Fact]
        public void FollowCommandShouldFollowThatUser() {
			var userRepo = new Mock<InMemoryRepo<User>>();

			var username = "ExistingUser";
			var user = new User(username);
			userRepo.Object.Add(user);

            var usernameToFollow = "FollowMe";
            var userToFollow = new User(usernameToFollow);
            userRepo.Object.Add(userToFollow);

            userRepo.Object.Save(user);

			var userService = new UserService(userRepo.Object);

            var followCommand = new FollowCommand(new Receiver(userService));
            followCommand.Execute(username, usernameToFollow);

            var isFollowing = false;
            foreach (var following in user.Following) {
                if (following.Username == usernameToFollow) {
                    isFollowing = true;
                    break;
                }
            }

            Assert.True(isFollowing);
        }
    }
}
