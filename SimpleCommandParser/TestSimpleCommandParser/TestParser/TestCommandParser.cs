using SimpleCommandParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SimpleCommandParser.Option;

namespace TestSimpleCommandParser.TestParser {
    public class TestCommandParser {

        public static IEnumerable<object[]> TestCommandParserData() {
            IOption option_1 = Mock.Of<IOption>();

            ICommandOptionParser commandOptionParser1 = Mock.Of<ICommandOptionParser>();

            ICommandParser commandParser = Mock.Of<ICommandParser>();
            commandParser.Name = "test";
            commandParser.Options = new List<ICommandOptionParser> {

            };

            yield return new object[] { };
            yield return new object[] { };
            yield return new object[] { };
        }

        [Theory]
        [MemberData(nameof(TestCommandParserData)]
        public void TestCommandNormalOptionParsing() {
            
        }

        [Fact] void TestCommandIncorrectOptionParsing() {

        }
    }
}
