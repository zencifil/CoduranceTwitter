using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {

    public class PostCommand : ICommand {

        Receiver _receiver;

        public PostCommand(Receiver receiver) {
            _receiver = receiver;
        }

        public IList<string> Execute(string username, string data) {
            return _receiver.PerformPost(username, data);
        }
    }
}
