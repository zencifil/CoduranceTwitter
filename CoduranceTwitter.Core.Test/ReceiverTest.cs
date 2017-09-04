﻿using System;
using CoduranceTwitter.Core.Models;
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
            var tweetText = "this is my first tweet.";
            _receiver.PerformPost(username, tweetText);
            var user = _receiver.GetUser(username);

            Assert.Equal(username, user.Username);
		}

        [Fact]
        public void WhenPerformFollowCalledWithNonExistingUsername_ShouldThrowException() {
			var username = "savas";
			var usernameToFollow = "ThisUserDoesNotExist";

			Assert.Throws<ArgumentException>(() => _receiver.PerformFollow(username, usernameToFollow));
        }

        [Fact]
        public void WhenPerformReadCalled_ShouldReturnTweetList() {
            var username = "savas";
            var tweet1 = "first tweet of the day...";
            var tweet2 = "second tweet of the day...";
            _receiver.PerformPost(username, tweet1);
            _receiver.PerformPost(username, tweet2);

            var tweets = _receiver.PerformRead(username);

            Assert.Equal(2, tweets.Count);
        }
    }
}
