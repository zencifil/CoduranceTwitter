using System.Collections;
using CoduranceTwitter.Core.Commands;
using System.Collections.Generic;

namespace CoduranceTwitter.Core {

    public class Invoke {

        ICommand _command;

        public IList<string> ExecuteCommand(CommandInput commandInput) {
            _command = commandInput.Command;
            return _command.Execute(commandInput.Username, commandInput.Data);
        }
    }
}
