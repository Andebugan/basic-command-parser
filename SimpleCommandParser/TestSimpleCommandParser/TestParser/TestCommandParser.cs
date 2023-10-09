using SimpleCommandParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SimpleCommandParser.Option;
using SimpleCommandParser.Command;

namespace TestSimpleCommandParser.TestParser {
    public class TestCommandParser {

        [Fact]
        public void TestCommandNormalOptionParsing() {
            // Arrange
            IOption option_1 = Mock.Of<IOption>();
            IOption option_2 = Mock.Of<IOption>();
            IOption option_3 = Mock.Of<IOption>();

            var commandOptionParser1 = new Mock<CommandOptionParser>();
            commandOptionParser1.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_1);
            commandOptionParser1.Object.Name = "o1";

            var commandOptionParser2 = new Mock<CommandOptionParser>();
            commandOptionParser2.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_2);
            commandOptionParser2.Object.Name = "o2";

            var commandOptionParser3 = new Mock<CommandOptionParser>();
            commandOptionParser3.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_3);
            commandOptionParser3.Object.Name = "o3";

            var command = new Mock<ICommand>();
            command.Setup(m => m.ApplyOptions(It.IsAny<List<IOption>>())).Returns(command.Object);

            var commandParser = new Mock<CommandParser>();

            commandParser.Object.Name = "test";
            commandParser.Object.Command = command.Object; 

            commandParser.Object.Options = new List<ICommandOptionParser> {
                commandOptionParser1.Object,
                commandOptionParser2.Object,
                commandOptionParser3.Object
            };

            // Act

            var result = commandParser.Object.Parse("test --o1 --o2 --o3");

            // Assert

            Assert.Equal(result, command.Object);
        }

        [Fact] void TestSuboptionParsing() {
            // Arrange
            IOption option_1 = Mock.Of<IOption>();
            IOption option_2 = Mock.Of<IOption>();
            IOption option_3 = Mock.Of<IOption>();

            var commandOptionParser1 = new Mock<CommandOptionParser>();
            commandOptionParser1.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_1);
            commandOptionParser1.Object.Name = "o1";

            var commandOptionParser2 = new Mock<CommandOptionParser>();
            commandOptionParser2.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_2);
            commandOptionParser2.Object.Name = "o2";

            var commandOptionParser3 = new Mock<CommandOptionParser>();
            commandOptionParser3.Setup(m => m.ParseOption(It.IsAny<string>())).Returns(option_3);
            commandOptionParser3.Object.Name = "o3";

            commandOptionParser1.Object.Suboptions = new List<ICommandOptionParser>() {
                commandOptionParser2.Object
            };

            commandOptionParser2.Object.Suboptions = new List<ICommandOptionParser>() {
                commandOptionParser3.Object
            };

            var command = new Mock<ICommand>();
            command.Setup(m => m.ApplyOptions(It.IsAny<List<IOption>>())).Returns(command.Object);

            var commandParser = new Mock<CommandParser>();

            commandParser.Object.Name = "test";
            commandParser.Object.Command = command.Object;

            commandParser.Object.Options = new List<ICommandOptionParser> {
                commandOptionParser1.Object
            };

            // Act

            var result = commandParser.Object.Parse("test --o1-o2-o3");

            // Assert

            Assert.Equal(result, command.Object);
        }
    }
}
