using SimpleCommandParser.ValueParsers.IntParsing;
using SimpleCommandParser.ValueParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCommandParser.ValueParsers.FloatParsing;

namespace TestSimpleCommandParser.TestValueParsers {
    public class TestIntParsing {

        [Theory]
        [InlineData(new string[] { "1" }, 1)]
        [InlineData(new string[] { "-1" }, -1)]
        public void TestIntValueParsing(string[] input, int expected) {
            // Arrange
            var parser = new IntParser();
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.Parse(ref inputLst);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "<1" }, int.MinValue, 1)]
        [InlineData(new string[] { ">1" }, 1, int.MaxValue)]
        [InlineData(new string[] { "1", "10" }, 1, 10)]
        public void TestIntRangeValueParsing(string[] input, int expectedStart, int expectedEnd) {
            // Arrange
            var parser = new IntParser();
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.ParseRange(ref inputLst);

            // Assert
            Assert.Equal(expectedStart, result.Start);
            Assert.Equal(expectedEnd, result.End);
        }


        [Theory]
        [InlineData(new string[] { "1", "2", "3" }, new int[] { 1, 2, 3 })]
        [InlineData(new string[] { "-1", "2", "|.", "test" }, new int[] { -1, 2 } )]
        public void TestIntListParsing(string[] input, int[] expected) {
            // Arrange
            var parser = new IntParser();
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.Parse(ref inputLst, new ValueParsingConfig());

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestIntRangeListData() {

            yield return new object[] { new string[] { "<10", ">10", "1", "10" }, new IntRange[] {
                new IntRange(int.MinValue, 10),
                new IntRange(10, int.MaxValue),
                new IntRange(1, 10)
            } };
        }

        [Theory]
        [MemberData(nameof(TestIntRangeListData))]
        public void TestIntRangeListParsing(string[] input, IntRange[] expected) {
            // Arrange
            var parser = new IntParser();
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.ParseRange(ref inputLst, new ValueParsingConfig());

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
