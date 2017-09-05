using CoduranceTwitter.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoduranceTwitter.Core {

    public class Twitter : IDisposable {

        bool _disposed = false;
        Receiver _receiver;

        public Twitter(Receiver receiver) {
            _receiver = receiver;
        }

        public string Execute(string commandText) {
            var command = GetCommand(commandText);
            var invoke = new Invoke();

            return "";
        }

        public ICommand GetCommand(string commandText) {
            var textArray = commandText.Split(" ", 3, StringSplitOptions.RemoveEmptyEntries);
            if (textArray.Length == 1)
                return new ReadCommand(_receiver);
            else if (textArray.Length == 2)
                return new WallCommand(_receiver);
            else if (textArray.Length == 3 && textArray[1] == "follows")
                return new FollowCommand(_receiver);
            else if (textArray.Length == 3 && textArray[1] == "->")
                return new PostCommand(_receiver);
            else
                throw new ArgumentException("Unrecognized command!");
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
