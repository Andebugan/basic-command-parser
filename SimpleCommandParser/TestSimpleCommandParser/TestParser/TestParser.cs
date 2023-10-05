using SimpleCommandParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using SimpleCommandParser.Command;

namespace TestSimpleCommandParser.TestParser {
    public class TestParser {
        [Fact]
        public void TestParserNormal() {
            // Arrange
            ICommand testCommand1 = Mock.Of<ICommand>();
            ICommand testCommand2 = Mock.Of<ICommand>();
            ICommand testCommand3 = Mock.Of<ICommand>();

            ICommandParser testCommandParser1 = Mock.Of<ICommandParser>(
                p => p.Parse(It.Is<string>(x => x.StartsWith("command1"))) == testCommand1);
            testCommandParser1.Name = "command1";
            ICommandParser testCommandParser2 = Mock.Of<ICommandParser>(
                p => p.Parse(It.Is<string>(x => x.StartsWith("command2"))) == testCommand2);
            testCommandParser2.Name = "command2";
            ICommandParser testCommandParser3 = Mock.Of<ICommandParser>(
                p => p.Parse(It.Is<string>(x => x.StartsWith("command3"))) == testCommand3);
            testCommandParser3.Name = "command3";

            var commandParserList = new List<ICommandParser>() {
                testCommandParser1,
                testCommandParser2,
                testCommandParser3
            };

            Parser parser = new Parser(commandParserList);

            // Act
            var command1 = parser.Parse("command1 -a -b -c");
            var command2 = parser.Parse("command2 -a -b -c");
            var command3 = parser.Parse("command3 -a -b -c");

            // Assert
            Assert.Equal(testCommand1, command1);
            Assert.Equal(testCommand2, command2);
            Assert.Equal(testCommand3, command3);
        }

        [Fact]
        public void TestParserNonexistCommand() {
            // Arrange

            var commandParserList = new List<ICommandParser>() {
            };

            Parser parser = new Parser(commandParserList);

            // Act
            try {
                var command = parser.Parse("command1 -a -b -c");
            } catch (Exception e) {
                // Assert
                Assert.True(true);
                return;
            }

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void TestParserIncorrectCommand() {
            // Arrange
            ICommand testCommand1 = Mock.Of<ICommand>();
            ICommand testCommand2 = Mock.Of<ICommand>();
            ICommand testCommand3 = Mock.Of<ICommand>();

            ICommandParser testCommandParser1 = Mock.Of<ICommandParser>(
                p => p.Parse(It.IsAny<string>()) == testCommand1);
            ICommandParser testCommandParser2 = Mock.Of<ICommandParser>(
                p => p.Parse(It.IsAny<string>()) == testCommand2);
            ICommandParser testCommandParser3 = Mock.Of<ICommandParser>(
                p => p.Parse(It.IsAny<string>()) == testCommand3);

            var commandParserList = new List<ICommandParser>() {
                testCommandParser1,
                testCommandParser2,
                testCommandParser3
            };

            Parser parser = new Parser(commandParserList);

            // Act
            try {
                var command = parser.Parse("command0 -a -b -c");
            } catch (Exception e) {
                // Assert
                Assert.True(true);
                return;
            }

            // Assert
            Assert.True(false);
        }
    }
}
