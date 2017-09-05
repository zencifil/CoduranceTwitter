using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CoduranceTwitter.Core.Services;
using CoduranceTwitter.Core.Commands;

namespace CoduranceTwitter.Core.Test {

    public class TwitterTest {

        Twitter _twitter;

        public TwitterTest() {
            var userServiceMock = new Mock<IUserService>();
            var receiverMock = new Mock<Receiver>(userServiceMock.Object);

            _twitter = new Twitter(receiverMock.Object);
        }

        [Fact]
        public void GetCommand_ShouldReturnProperCommandForPost() {
            var commandText = "user -> tweet";
            var command = _twitter.GetCommand(commandText);

            Assert.IsType<PostCommand>(command);
        }

        [Fact]
        public void GetCommand_ShouldReturnProperCommandForRead() {
            var commandText = "user";
            var command = _twitter.GetCommand(commandText);

            Assert.IsType<ReadCommand>(command);
        }

        [Fact]
        public void GetCommand_ShouldReturnProperCommandForFollow() {
            var commandText = "user follows anotherUser";
            var command = _twitter.GetCommand(commandText);

            Assert.IsType<FollowCommand>(command);
        }

        [Fact]
        public void GetCommand_ShouldReturnProperCommandForWall() {
            var commandText = "user wall";
            var command = _twitter.GetCommand(commandText);

            Assert.IsType<WallCommand>(command);
        }
    }
}
