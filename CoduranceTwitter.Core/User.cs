using System;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core {
    
    public class User : IUser {

        private Models.IUser _user;
        
        public User(string username) {
            
        }

        public void AddTweet(Tweet tweet) {
            throw new NotImplementedException();
        }


    }
}
