using System.Collections;
using CoduranceTwitter.Core.Commands;

namespace CoduranceTwitter.Core {

    public class Invoke {

        ICommand _command;

        public IEnumerable ExecuteCommand(ICommand command, string username, string data) {
            _command = command;
            return _command.Execute(username, data);
        }
    }
}
