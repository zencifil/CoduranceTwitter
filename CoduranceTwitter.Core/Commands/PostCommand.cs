﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core.Commands {

    public class PostCommand : ICommand {

        private Receiver _receiver;

        public PostCommand(Receiver receiver) {
            this._receiver = receiver;
        }

        public IEnumerable Execute() {
            return new List<string>();
        }
    }
}
