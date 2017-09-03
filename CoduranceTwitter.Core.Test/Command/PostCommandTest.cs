using System;
using CoduranceTwitter.Core.Commands;
using Xunit;

namespace CoduranceTwitter.Core.Test.Command {
    
    public class CommandTest {

        private Receiver _receiver;

        public CommandTest() {
            _receiver = Receiver.Instance;
        }

        [Fact]
        public void PostCommandPostsATweet() {
            ICommand postCommand = new PostCommand(_receiver);
            var actual = postCommand.Execute();
        }
        


    }
}
