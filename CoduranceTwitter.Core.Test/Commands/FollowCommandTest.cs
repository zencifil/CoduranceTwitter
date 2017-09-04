using System;
using CoduranceTwitter.Core.Commands;
using CoduranceTwitter.Core.Models;
using Xunit;

namespace CoduranceTwitter.Core.Test.Commands {
    
    public class FollowCommandTest {

        private Receiver _receiver;
        
        public FollowCommandTest() {
			if (_receiver != null)
				_receiver.Dispose();

			_receiver = Receiver.Instance;
        }

        [Fact]
        public void FollowCommandShouldFollowThatUser() {
            var username = "savas";
            var usernameToFollow = "FollowMe";

            _receiver.CreateUser(username);
            _receiver.CreateUser(usernameToFollow);

            var followCommand = new FollowCommand(_receiver);
            followCommand.Execute(username, usernameToFollow);

            var user = _receiver.GetUser(username);
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
