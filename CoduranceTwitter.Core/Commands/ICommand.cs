using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {
    
    public interface ICommand {
        IEnumerable<string> Execute(string username, string data);
    }
}
