using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {
    
    public class FollowCommand : ICommand {

        private Receiver _receiver;
        
        public FollowCommand(Receiver receiver) {
            this._receiver = receiver;
        }

        public IEnumerable<string> Execute(string username, string data) {
            return this._receiver.PerformFollow(username, data);
        }
    }
}
