using System;
using Xunit;

namespace CoduranceTwitter.Core.Test {

    public class ReceiverTest {

        [Fact]
        public void ShouldCreateOnlyOneInstance() {
            Receiver receiver1 = Receiver.Instance;
            Receiver receiver2 = Receiver.Instance;

            Assert.Same(receiver1, receiver2);
        }
    }
}
