using System;
using CoduranceTwitter.Core.Commands;
using Xunit;

namespace CoduranceTwitter.Core.Test.Commands {
    
    public class PostCommandTest {

        private Receiver _receiver;

        public PostCommandTest() {
            if (_receiver != null)
                _receiver.Dispose();
            
            _receiver = Receiver.Instance;
        }

        [Fact]
        public void PostCommandPostsATweet() {
            var username = "PostCommandUser";
            var tweetText = "hello twitter, this is my first tweet...";
            var postCommand = new PostCommand(_receiver);
            postCommand.Execute(username, tweetText);
            var user = _receiver.GetUser(username);

            Assert.Equal(tweetText, user.Tweets[user.Tweets.Count - 1].TweetText);
        }
        


    }
}
