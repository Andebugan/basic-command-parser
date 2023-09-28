using SimpleCommandParser.ValueParsers.FloatParsing;
using SimpleCommandParser.ValueParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimpleCommandParser.TestValueParsers {
    public class TestFloatParsing {
        [Theory]
        [InlineData("0.0", 0.0f)]
        [InlineData("5.5", 5.5f)]
        [InlineData("-5.5", -5.5f)]
        public void TestFloatValue(string input, float expectedResult) {
            // Arrange
            var parser = new FloatParser();
            IList<string> inputList = new List<string>() { input };

            // Act
            var result = parser.Parse(ref inputList);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new string[] { "0.0", "1.0" }, 0.0f, 1.0f)]
        [InlineData(new string[] { "<5.5" }, float.NegativeInfinity, 5.5f)]
        [InlineData(new string[] { ">5.5" }, 5.5f, float.PositiveInfinity)]
        public void TestFloatRangeValue(string[] input, float expectedStart, float expectedEnd) {
            // Arrange
            var parser = new FloatParser();
            IList<string> inputList = input.ToList();

            // Act
            var result = parser.ParseRange(ref inputList);

            // Assert
            Assert.Equal(result.Start, expectedStart);
            Assert.Equal(result.End, expectedEnd);
        }

        [Theory]
        [InlineData(new string[] { "0.0", "1.1", "2" }, new float[] { 0.0f, 1.1f, 2.0f })]
        [InlineData(new string[] { "0.0", "-1.1", "-2" }, new float[] { 0.0f, -1.1f, -2.0f })]
        public void TestFloatListValue(string[] input, float[] expected) {
            // Arrange
            var parser = new FloatParser();
            IList<string> inputList = input.ToList();

            // Act
            var result = parser.Parse(ref inputList, new ValueParsingConfig());

            // Assert
            Assert.Equal(expected.ToList(), result);
        }

        public static IEnumerable<object[]> TestFloatRangeListData() {

            yield return new object[] { new string[] { "<10", ">10", "1", "10" }, new FloatRange[] {
                new FloatRange(float.NegativeInfinity, 10.0f),
                new FloatRange(10.0f, float.PositiveInfinity),
                new FloatRange(1.0f, 10.0f)
            } };
        }

        [Theory]
        [MemberData(nameof(TestFloatRangeListData))]
        public void TestFloatRangeListValue(string[] input, FloatRange[] expected) {
            // Arrange
            var parser = new FloatParser();
            IList<string> inputList = input.ToList();

            // Act
            var result = parser.ParseRange(ref inputList, new ValueParsingConfig());

            // Assert
            Assert.Equal(expected.ToList(), result);
        }
    }
}
