using BasicCommandParser.ValueParsers.StringParsing;
using BasicCommandParser.ValueParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimpleCommandParser.TestValueParsers {
    public class TestStringParsing {

        [Theory]
        [InlineData(new string[] { "test", "a", "|", "b", "c" }, new string[] { "test a", "b c" })]
        public void TestStringListParsing(string[] input, string[] expected) {
            // Arrange
            var parser = new StringParser();
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.Parse(ref inputLst, new ValueParsingConfig());

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
