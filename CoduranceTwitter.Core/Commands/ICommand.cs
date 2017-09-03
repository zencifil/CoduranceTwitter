using System;
using System.Collections;

namespace CoduranceTwitter.Core.Commands {
    
    public interface ICommand {
        IEnumerable Execute();
    }
}
