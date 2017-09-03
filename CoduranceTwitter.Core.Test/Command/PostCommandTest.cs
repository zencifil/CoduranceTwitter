using System;
using CoduranceTwitter.Core.Commands;
using Xunit;

namespace CoduranceTwitter.Core.Test.Command {
    
    public class CommandTest {

        private Receiver _receiver;

        public CommandTest() {
            if (_receiver != null)
                _receiver.Dispose();
            
            _receiver = Receiver.Instance;
        }

        [Fact]
        public void PostCommandPostsATweet() {
            var username = "savas";
            var tweetText = "hello twitter, this is my first tweet...";
            ICommand postCommand = new PostCommand(_receiver);
            postCommand.Execute();
            var actual = _receiver.GetUser(username);
        }
        


    }
}
