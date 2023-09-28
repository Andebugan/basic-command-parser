using SimpleCommandParser.ValueParsers.FloatParsing;
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
        [InlineData("0.0 1.0", 0.0f, 1.0f)]
        [InlineData("<5.5", float.NegativeInfinity, 5.5f)]
        [InlineData(">5.5", 5.5f, float.PositiveInfinity)]
        public void TestFloatRangeValue(string input, float expectedStart, float expectedEnd) {
            // Arrange
            var parser = new FloatParser();
            IList<string> inputList = new List<string>() { input };

            // Act
            var result = parser.ParseRange(ref inputList);

            // Assert
            Assert.Equal(result.Start, expectedStart);
            Assert.Equal(result.End, expectedEnd);
        }

        [Theory]
        [InlineData("0.0 1.1 2.2", new float[] { 0.0f, 1.1f, 2.2f })]
        public void TestFloatListValue(string input, float[] result) {
            // Arrange


            // Act

            
            // Assert

        }

        public void TestFloatRangeListValue(string input, FloatRange result) {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void TestFloatEmptyInput() {
            //
            //Arrange

            // Act

            // Assert

        }

        [Fact]
        public void TestFloatRangeEmptyInput() {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void TestFloatListEmptyInput() {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void TestFloatRangeListEmptyInput() {
            // Arrange

            // Act

            // Assert

        }
    }
}
