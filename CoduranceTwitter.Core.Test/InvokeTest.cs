using System;
using CoduranceTwitter.Core.Commands;
using Xunit;

namespace CoduranceTwitter.Core.Test {
    
    public class InvokeTest {

        private Receiver _receiver;
        
        public InvokeTest() {
			if (_receiver != null)
				_receiver.Dispose();

			_receiver = Receiver.Instance;
        }

        [Fact]
        public void WhenPostCommandSentToExecute_ShouldPostTweet() {
            var postCommand = new PostCommand(_receiver);
            var invoke = new Invoke();

            string username = "invokeUser";
            string data = "This tweet is sent via invoke.";

            invoke.ExecuteCommand(postCommand, username, data);

            var userTweets = _receiver.GetUserTweets(username);
            Assert.Equal(data, userTweets[userTweets.Count - 1].TweetText);
        }

    }
}
