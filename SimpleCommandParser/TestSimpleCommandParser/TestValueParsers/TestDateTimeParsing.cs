using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SimpleCommandParser.ValueParsers;
using SimpleCommandParser.ValueParsers.BoolParsing;
using SimpleCommandParser.ValueParsers.DateTimeParsing;
using Xunit.Sdk;

namespace TestSimpleCommandParser.TestValueParsers {

    public class TestDateTimeParsing {

        public static IEnumerable<object[]> TestDateTimeValueData() {
            // empty value
            yield return new object[] { new string[] { }, DateTime.Now, new string[] { } };
            // date formats with time
            yield return new object[] { new string[] { "12:00", "2023" }, new DateTime(2023, 1, 1, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "3.23" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "03.23" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "3.3.23" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "03.03.23" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "3.2023" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "03.2023" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "3.3.2023" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "03.03.2023" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "12:00", "3.3" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { } };
            // date formats without time
            yield return new object[] { new string[] { "2023" }, new DateTime(2023, 1, 1, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "3.23" }, new DateTime(2023, 3, 1, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "03.23" }, new DateTime(2023, 3, 1, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "3.3.23" }, new DateTime(2023, 3, 3, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "03.03.23" }, new DateTime(2023, 3, 3, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "3.2023" }, new DateTime(2023, 3, 1, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "03.2023" }, new DateTime(2023, 3, 1, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "3.3.2023" }, new DateTime(2023, 3, 3, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "03.03.2023" }, new DateTime(2023, 3, 3, 0, 0, 0), new string[] { } };
            yield return new object[] { new string[] { "3.3" }, new DateTime(2023, 3, 3, 0, 0, 0), new string[] { } };
            // test input ending
            yield return new object[] { new string[] { "12:00", "2023", "test" }, new DateTime(2023, 1, 1, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "3.23", "test" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "03.23", "test" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "3.3.23", "test" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "03.03.23", "test" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "3.2023", "test" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "03.2023", "test" }, new DateTime(2023, 3, 1, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "3.3.2023", "test" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "03.03.2023", "test" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { "test" } };
            yield return new object[] { new string[] { "12:00", "3.3", "test" }, new DateTime(2023, 3, 3, 12, 0, 0), new string[] { "test" } };
        }

        public static IEnumerable<object[]> TestWeekDayValueData() {

            DateTime dateTime = DateTime.Today;

            dateTime = dateTime.ToLocalTime();

            dateTime = dateTime.AddDays(DayOfWeek.Monday - dateTime.DayOfWeek);

            DateFormats formats = new DateFormats();

            foreach (var day in formats.dayOfWeekTextFormat.Keys) {

                if (formats.dayOfWeekTextFormat[day] != dateTime.DayOfWeek)
                    dateTime = dateTime.AddDays(1);

                yield return new object[] { new string[] { "12:00", day }, dateTime.AddHours(12), new string[] { } };
                yield return new object[] { new string[] { day }, dateTime, new string[] { } };
                yield return new object[] { new string[] { "12:00", day, "test" }, dateTime.AddHours(12), new string[] { "test" } };

                // test next

                yield return new object[] { new string[] { "12:00", "next", day }, dateTime.AddDays(7).AddHours(12), new string[] { } };
                yield return new object[] { new string[] { "next", day }, dateTime.AddDays(7), new string[] { } };
                yield return new object[] { new string[] { "12:00", "next", day, "test" }, dateTime.AddDays(7).AddHours(12), new string[] { "test" } };

                // test previous

                yield return new object[] { new string[] { "12:00", "previous", day }, dateTime.AddDays(-7).AddHours(12), new string[] { } };
                yield return new object[] { new string[] { "previous", day }, dateTime.AddDays(-7), new string[] { } };
                yield return new object[] { new string[] { "12:00", "previous", day, "test" }, dateTime.AddDays(-7).AddHours(12), new string[] { "test" } };
            }
        }

        public static IEnumerable<object[]> TestSpecialDayValueData() {

            DateTime dateTime = DateTime.Today;

            yield return new object[] { new string[] { "12:00", "yesterday" }, dateTime.AddDays(-1).AddHours(12), new string[] { } };
            yield return new object[] { new string[] { "yesterday" }, dateTime.AddDays(-1), new string[] { } };
            yield return new object[] { new string[] { "12:00", "yesterday", "test" }, dateTime.AddDays(-1).AddHours(12), new string[] { "test" } };

            yield return new object[] { new string[] { "12:00", "tomorrow" }, dateTime.AddDays(1).AddHours(12), new string[] { } };
            yield return new object[] { new string[] { "tomorrow" }, dateTime.AddDays(1), new string[] { } };
            yield return new object[] { new string[] { "12:00", "tomorrow", "test" }, dateTime.AddDays(1).AddHours(12), new string[] { "test" } };

            yield return new object[] { new string[] { "12:00", "today" }, dateTime.AddHours(12), new string[] { } };
            yield return new object[] { new string[] { "today" }, dateTime, new string[] { } };
            yield return new object[] { new string[] { "12:00", "today", "test" }, dateTime.AddHours(12), new string[] { "test" } };
        }

        // Values
        [Theory]
        [MemberData(nameof(TestDateTimeValueData))]
        [MemberData(nameof(TestWeekDayValueData))]
        [MemberData(nameof(TestSpecialDayValueData))]
        public void TestDateTimeValueParsing(string[] input, DateTime expectedDate, string[] expectedInputChange) {
            // Arrange
            var parser = new DateTimeParser(new DateFormats());
            IList<string> inputLst = input.ToList();

            // Act
            var date = parser.Parse(ref inputLst);

            // Assert
            Assert.Equal(expectedDate, date);
            Assert.Equal(expectedInputChange, inputLst.ToArray());
        }

        public static IEnumerable<object[]> TestDateTimeRangeValueData() {
            // empty value
            yield return new object[] { new string[] {  },
                new DateTime[] { DateTime.MinValue, DateTime.MaxValue },
                new string[] { } };
            // without additional input
            // with additional input
            yield return new object[] { new string[] { "12:00", "2023", "13:00", "2023" },
                new DateTime[] { new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 13, 0, 0) },
                new string[] {  } };
            yield return new object[] { new string[] { "<1.1.2023" },
                new DateTime[] { DateTime.MinValue, new DateTime(2023, 1, 1, 0, 0, 0) },
                new string[] {} };
            yield return new object[] { new string[] { ">1.1.2023" },
                new DateTime[] {new DateTime(2023, 1, 1, 0, 0, 0), DateTime.MaxValue },
                new string[] {} };

            // with additional input
            yield return new object[] { new string[] { "12:00", "2023", "13:00", "2023", "test" },
                new DateTime[] { new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 13, 0, 0) },
                new string[] { "test" } };
            yield return new object[] { new string[] { "<1.1.2023", "test" },
                new DateTime[] { DateTime.MinValue, new DateTime(2023, 1, 1, 0, 0, 0) },
                new string[] { "test" } };
            yield return new object[] { new string[] { ">1.1.2023", "test" },
                new DateTime[] {new DateTime(2023, 1, 1, 0, 0, 0), DateTime.MaxValue },
                new string[] { "test" } };
        }

        // Values
        [Theory]
        [MemberData(nameof(TestDateTimeRangeValueData))]
        public void TestDateTimeRangeValueParsing(string[] input, DateTime[] expectedRange, string[] expectedInputChange) {
            // Arrange
            var parser = new DateTimeParser(new DateFormats());
            IList<string> inputLst = input.ToList();

            // Act
            var dateRange = parser.ParseRange(ref inputLst);

            // Assert
            for (int i = 0; i < expectedRange.Length; i++) {
                Assert.Equal(expectedRange[0], dateRange.Start);
                Assert.Equal(expectedRange[1], dateRange.End);
            }
            Assert.Equal(expectedInputChange, inputLst.ToArray());
        }

        public static IEnumerable<object[]> TestDateTimeListData() {
            // empty value
            yield return new object[] { new string[] { },
                new DateTime[] { },
                new string[] { } };

            // normal list
            yield return new object[] { new string[] { "12:00,", "13:00", "1.1.23", "14:00", "3.3.23" },
                new DateTime[] {
                new DateTime(2023, 9, 29, 12, 0, 0),
                new DateTime(2023, 1, 1, 13, 0, 0),
                new DateTime(2023, 1, 1, 14, 0, 0) },
                new string[] { } };

            // test terminator
            yield return new object[] { new string[] { "12:00,", "13:00", "1.1.23", "|.", "test" },
                new DateTime[] {
                new DateTime(2023, 9, 29, 12, 0, 0),
                new DateTime(2023, 1, 1, 13, 0, 0), },
                new string[] { "test" } };
        }

        // Value lists
        [Theory]
        [MemberData(nameof(TestDateTimeListData))]
        public void TestDateTimeListParsing(string[] input, DateTime[] expectedList, string[] expectedInputChange) {
            // Arrange
            var parser = new DateTimeParser(new DateFormats());
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.Parse(ref inputLst, new ValueParsingConfig());

            // Assert
            Assert.Equal(expectedList.ToList(), result);
            Assert.Equal(expectedInputChange, inputLst.ToArray());
        }

        public static IEnumerable<object[]> TestDateTimeRangeListData() {
            // empty value
            yield return new object[] { new string[] { },
                new DateTime[][] { },
                new string[] { } };

            // normal list
            yield return new object[] { new string[] { ">12:00,", "13:00", "1.1.23" },
                new DateTime[][] {
                new DateTime[] { DateTime.Today.AddHours(12), DateTime.MaxValue },
                new DateTime[] { DateTime.MinValue, new DateTime(2023, 1, 1, 13, 0, 0) } },
                new string[] { } };

            // test terminator
            yield return new object[] { new string[] { ">12:00,", "13:00", "1.1.23", "|.", "test" },
                new DateTime[][] {
                new DateTime[] { DateTime.Today.AddHours(12), DateTime.MaxValue },
                new DateTime[] { DateTime.MinValue, new DateTime(2023, 1, 1, 13, 0, 0) } },
                new string[] { "test" } };
        }

        [Theory]
        [MemberData(nameof(TestDateTimeRangeListData))]
        public void TestDateTimeRangeListParsing(string[] input, DateTime[][] expectedList, string[] expectedInputChange) {
            // Arrange
            var parser = new DateTimeParser(new DateFormats());
            IList<string> inputLst = input.ToList();

            // Act
            var result = parser.ParseRange(ref inputLst, new ValueParsingConfig());

            // Assert
            for (var i = 0; i < expectedList.Length; i++) {
                Assert.Equal(expectedList[i][0], result[i].Start);
                Assert.Equal(expectedList[i][1], result[i].End);
            }
            Assert.Equal(expectedInputChange, inputLst.ToArray());
        }
    }
}
