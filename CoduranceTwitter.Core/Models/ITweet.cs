using System;
namespace CoduranceTwitter.Core.Models {
    
    public interface ITweet {
        
        string TweetText { get; }
        DateTime SendDate { get; }
    }
}
