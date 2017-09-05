using System;

namespace CoduranceTwitter.Core.Models {
    
    public class Tweet : IEntity {

        string _tweetText;
        DateTime _sendDate;

        public Tweet(string tweetText) {
            _tweetText = tweetText;
            _sendDate = DateTime.Now;
        }

        public string TweetText => _tweetText;

        public DateTime SendDate => _sendDate;
    }
}
