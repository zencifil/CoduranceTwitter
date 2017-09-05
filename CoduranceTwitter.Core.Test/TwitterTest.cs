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
        public void ParseCommand_ShouldReturnProperCommandForPost() {
            var commandText = "user -> tweet";
            var command = _twitter.ParseCommand(commandText);

            Assert.IsType<PostCommand>(command.Command);
        }

        [Fact]
        public void ParseCommand_ShouldReturnProperCommandForRead() {
            var commandText = "user";
            var command = _twitter.ParseCommand(commandText);

            Assert.IsType<ReadCommand>(command.Command);
        }

        [Fact]
        public void ParseCommand_ShouldReturnProperCommandForFollow() {
            var commandText = "user follows anotherUser";
            var command = _twitter.ParseCommand(commandText);

            Assert.IsType<FollowCommand>(command.Command);
        }

        [Fact]
        public void ParseCommand_ShouldReturnProperCommandForWall() {
            var commandText = "user wall";
            var command = _twitter.ParseCommand(commandText);

            Assert.IsType<WallCommand>(command.Command);
        }

        [Fact]
        public void WhenPostGivenToExecute_ShouldReturnEmptyString() {
            var commandText = "user -> tweet";
            var actual = _twitter.Execute(commandText);

            Assert.Equal(0, actual.Count);
        }
    }
}
