using System;
using System.Collections;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.Core {

    // After the structure change, this class looks like redundant... 
    public class Receiver {

        IUserService _userService;

        public Receiver(IUserService userService) {
            _userService = userService;
        }

        public IList<string> PerformPost(string username, string data) {
            _userService.PostTweet(username, data);

            // might return actual post but for now just an empty list.
            return new List<string>();
        }

        public IList<string> PerformFollow(string username, string usernameToFollow) {
            _userService.FollowUser(username, usernameToFollow);

            // just return an empty string same as post
            return new List<string>();
        }

        public IList<string> PerformRead(string username) {
            var tweets = _userService.GetTweetList(username);

            var returnList = new List<string>();
            foreach (var tweet in tweets) {
                returnList.Add(tweet.TweetText);
            }

            return returnList;
        }

    }
}
