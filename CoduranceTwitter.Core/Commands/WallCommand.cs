using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {
    
    public class WallCommand : ICommand {

        Receiver _receiver;

        public WallCommand(Receiver receiver) {
            _receiver = receiver;
        }

        public IList<string> Execute(string username, string data) {
            return _receiver.PerformWall(username);
        }
    }
}
