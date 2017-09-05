using CoduranceTwitter.Core.Commands;

namespace CoduranceTwitter.Core {

    public class CommandInput {

        ICommand _command;
        string _username;
        string _data;

        public CommandInput(ICommand command, string username, string data) {
            _command = command;
            _username = username;
            _data = data;
        }

        public ICommand Command {
            get {
                return _command;
            }
        }

        public string Username {
            get {
                return _username;
            }
        }

        public string Data {
            get {
                return _data;
            }
        }
    }
}
