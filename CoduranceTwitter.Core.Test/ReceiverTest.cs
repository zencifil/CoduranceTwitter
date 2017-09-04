using System;
using Xunit;

namespace CoduranceTwitter.Core.Test {

    public class ReceiverTest {

        private Receiver _receiver;

        public ReceiverTest() {
            if (_receiver != null)
                _receiver.Dispose();
            
            _receiver = Receiver.Instance;
        }

        [Fact]
        public void ShouldCreateOnlyOneInstance() {
            Receiver receiver1 = Receiver.Instance;
            Receiver receiver2 = Receiver.Instance;

            Assert.Same(receiver1, receiver2);
        }

        [Fact]
        public void ShouldCreateUserIfUsernameNotExists() {
            var username = "savas";
            _receiver.CreateUser(username);
            var user = _receiver.GetUser(username);

            Assert.Equal(username, user.Username);
        }

		[Fact]
		public void WhenTweetsForFirstTime_ShouldCreateUser() {
			var username = "firstTimeUser";
            var tweet = new Models.Tweet("this is my first tweet.");
            _receiver.PerformPost(username, tweet);
            var user = _receiver.GetUser(username);

            Assert.Equal(username, user.Username);
		}
    }
}
