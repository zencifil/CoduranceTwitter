using System;
using System.Collections;
using System.Collections.Generic;

namespace CoduranceTwitter.Core {
    
    public sealed class Receiver {

        private bool _disposed = false;
        private static volatile Receiver _receiver;
        private static readonly object _syncLock = new object();

        private Receiver() {
        }

        public static Receiver Instance {
            get {
                if (_receiver != null)
                    return _receiver;

                lock (_syncLock) {
                    if (_receiver == null)
                        _receiver = new Receiver();
                }

                return _receiver;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (_disposed)
                return;

            if (disposing) {
                _receiver = null;
                _disposed = true;
            }
        }

    }
}
