using System;
using CoduranceTwitter.Core.Commands;
using Xunit;

namespace CoduranceTwitter.Core.Test.Commands {
    
    public class ReadCommandTest {

        private Receiver _receiver;

        public ReadCommandTest() {
			if (_receiver != null)
				_receiver.Dispose();

			_receiver = Receiver.Instance;
        }

        [Fact]
        public void ReadCommandReturnsAListOfTweet() {
            var username = "ReadCommandUser";
            var tweet1 = "This could be my first tweet.";
            var tweet2 = "And this could be my second...";
            _receiver.PerformPost(username, tweet1);
            _receiver.PerformPost(username, tweet2);

            var readCommand = new ReadCommand(_receiver);
            var tweets = readCommand.Execute(username, string.Empty);

            Assert.Equal(2, tweets.Count);
        }
    }
}
