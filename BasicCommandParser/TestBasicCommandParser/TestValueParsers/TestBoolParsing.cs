using BasicCommandParser.ValueParsers;
using BasicCommandParser.ValueParsers.BoolParsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimpleCommandParser.TestValueParsers {
    public class TestBoolParsing {
        [Fact]
        public void TestEmptyInputList() {
            // Arrange
            IList<string> list = new List<string>();
            var parser = new BoolParser();

            // Act
            bool result = parser.Parse(ref list);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEmptyInputListForList() {
            // Arrange
            IList<string> list = new List<string>();
            var parser = new BoolParser();
            ValueParsingConfig valueParsingConfig = new ValueParsingConfig();

            // Act
            IList<bool> result = parser.Parse(ref list, valueParsingConfig);

            // Assert
            Assert.True(result.Count() == 0);
        }

        [Theory]
        [InlineData("t")]
        [InlineData("true")]
        [InlineData("y")]
        [InlineData("yes")]
        [InlineData("f")]
        [InlineData("false")]
        [InlineData("n")]
        [InlineData("no")]
        [InlineData("m")]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(" ")]
        public void TestValueParsings(string input) {
            // Arrange
            Dictionary<string, bool> boolFormats = new Dictionary<string, bool> {
                {"t", true},
                {"true", true},
                {"y", true},
                {"yes", true},
                {"f", false},
                {"false", false},
                {"n", false},
                {"no", false}
            };

            IList<string> list = new List<string>() { input };
            var parser = new BoolParser();

            bool exceptionThrown = false;
            // Act

            bool result = false;
            try {
                result = parser.Parse(ref list);
            } catch (Exception ex) {
                exceptionThrown = true;
            }

            // Assert
            if (exceptionThrown) {
                Assert.False(boolFormats.ContainsKey(input));
            } else {
                Assert.Equal(boolFormats[input], result);
                Assert.True(list.Count() == 0);
            }
        }

        [Theory]
        [InlineData(new string[] { "|." }, new bool[] { }, new string[] { })]
        [InlineData(new string[] { "y", "n", "|." }, new bool[] { true, false }, new string[] { })]
        [InlineData(new string[] { "|.", "test" }, new bool[] { }, new string[] { "test" })]
        [InlineData(new string[] { "y", "n", "|.", "test" }, new bool[] { true, false }, new string[] { "test" })]
        public void TestListValueParsings(string[] input, bool[] expected, string[] inputExpected) {
            // Arrange
            IList<string> inputLst = input.ToList();
            var parser = new BoolParser();
            ValueParsingConfig valueParsingConfig = new ValueParsingConfig();

            // Act
            var result = parser.Parse(ref inputLst, valueParsingConfig);

            // Assert
            Assert.Equal(expected, result.ToArray());
            Assert.Equal(inputExpected, inputLst.ToArray());
        }

        [Fact]
        public void TestIncorrectListValue() {
            // Arrange
            IList<string> list = new List<string>() { "a", "b", "c" };
            var parser = new BoolParser();
            ValueParsingConfig valueParsingConfig = new ValueParsingConfig();

            // Act

            bool caughtException = false;
            try {
                var result = parser.Parse(ref list, valueParsingConfig);
            } catch(Exception ex) {
                caughtException = true;
            }

            // Assert
            Assert.True(caughtException);
        }
    }
}
