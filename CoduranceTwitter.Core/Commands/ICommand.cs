using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {

    public interface ICommand {
        IList<string> Execute(string username, string data);
    }
}
