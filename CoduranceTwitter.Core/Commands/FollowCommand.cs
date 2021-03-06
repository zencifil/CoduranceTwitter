﻿using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {
    
    public class FollowCommand : ICommand {

        Receiver _receiver;
        
        public FollowCommand(Receiver receiver) {
            _receiver = receiver;
        }

        public IList<string> Execute(string username, string data) {
            return _receiver.PerformFollow(username, data);
        }
    }
}
