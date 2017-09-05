using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {

    public class ReadCommand : ICommand {

        Receiver _receiver;

        public ReadCommand(Receiver receiver) {
            _receiver = receiver;
        }

        public IList<string> Execute(string username, string data) {
            return _receiver.PerformRead(username);
        }
    }
}
