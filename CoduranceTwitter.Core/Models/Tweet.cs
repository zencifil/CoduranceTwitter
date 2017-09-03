using System;
namespace CoduranceTwitter.Core.Models {
    public class Tweet : ITweet {

        private string _tweetText;
        private DateTime _sendDate;

        public Tweet(string tweetText) {
            this._tweetText = tweetText;
            this._sendDate = DateTime.Now;
        }

        public string TweetText => throw new NotImplementedException();

        public DateTime SendDate => throw new NotImplementedException();
    }
}
