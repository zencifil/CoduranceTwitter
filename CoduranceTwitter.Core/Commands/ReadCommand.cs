using System;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {
    
    public class ReadCommand : ICommand {

        private Receiver _receiver;

        public ReadCommand(Receiver receiver) {
            this._receiver = receiver;
        }

        public IList<string> Execute(string username, string data) {
            return _receiver.PerformRead(username);
        }
    }
}
