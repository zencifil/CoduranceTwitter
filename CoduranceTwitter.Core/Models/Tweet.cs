using System;
namespace CoduranceTwitter.Core.Models {
    public class Tweet : IEntity {

        private string _tweetText;
        private DateTime _sendDate;

        public Tweet(string tweetText) {
            this._tweetText = tweetText;
            this._sendDate = DateTime.Now;
        }

        public string TweetText => this._tweetText;

        public DateTime SendDate => this._sendDate;
    }
}
