using System;
using System.Collections.Generic;

using CoduranceTwitter.Core.Commands;

namespace CoduranceTwitter.Core {

    public class Twitter : IDisposable {

        bool _disposed = false;
        Receiver _receiver;

        public Twitter(Receiver receiver) {
            _receiver = receiver;
        }

        public IList<string> Execute(string commandText) {
            var invoke = new Invoke();
            var command = ParseCommand(commandText);
            return invoke.ExecuteCommand(command);
        }

        public CommandInput ParseCommand(string commandText) {
            CommandInput commandInput;
            var textArray = commandText.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries);
            if (textArray.Length == 1)
                commandInput = new CommandInput(new ReadCommand(_receiver), textArray[0], string.Empty);
            else if (textArray.Length == 2)
                commandInput = new CommandInput(new WallCommand(_receiver), textArray[0], string.Empty);
            else if (textArray.Length == 3 && textArray[1] == "follows")
                commandInput = new CommandInput(new FollowCommand(_receiver), textArray[0], textArray[2]);
            else if (textArray.Length == 3 && textArray[1] == "->")
                commandInput = new CommandInput(new PostCommand(_receiver), textArray[0], textArray[2]);
            else
                throw new ArgumentException("Unrecognized command!");

            return commandInput;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (_disposed)
                return;

            if (disposing) {
                _disposed = true;
                _receiver = null;
            }
        }
    }
}
