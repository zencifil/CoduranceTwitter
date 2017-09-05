using System.Collections.Generic;

using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.Core {

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
            return _userService.GetTweetList(username);
        }

        public IList<string> PerformWall(string username) {
            return _userService.GetWall(username);
        }

    }
}
