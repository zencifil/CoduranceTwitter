using System;
using System.Collections;
using CoduranceTwitter.Core.Commands;

namespace CoduranceTwitter.Core {
    
    public class Invoke {

        private ICommand _command;

        public IEnumerable ExecuteCommand(ICommand command) {
            this._command = command;
            return this._command.Execute();
        }
    }
}
