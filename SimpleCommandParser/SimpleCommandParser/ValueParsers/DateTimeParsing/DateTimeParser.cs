using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    public class DateTimeParser : IDateTimeParser {
        DateFormats dateFormats;

        private string stopper = ",";
        
        public DateTimeParser(DateFormats dateFormats) {
            this.dateFormats = dateFormats;
        }

        public DateTime Parse(ref IList<string> input) {
            if (input.Count() == 0) {
                return DateTime.Now;
            }

            var time = new DateTime();

            bool success = false;

            var tmpTime = input.First();
            if (tmpTime.EndsWith(stopper))
                tmpTime = tmpTime.Remove(tmpTime.Length - 1);
            // try parse time
            foreach (var tFormat in dateFormats.timeFormats) {
                if (success = DateTime.TryParseExact(tmpTime, tFormat, System.Globalization.CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out time))
                    break;
            }

            if (success && (input.Count() == 0 || input.First().EndsWith(stopper))) {
                input.RemoveAt(0);
                var tmp = DateTime.Now;
                return new DateTime(tmp.Year, tmp.Month, tmp.Day, time.Hour, time.Minute, 0);
            }

            if (success) {
                input.RemoveAt(0);
            }

            var date = new DateTime();
            // try parse date, if success return
            foreach (var dateFormat in dateFormats.dateFormats) {
                if (success = DateTime.TryParseExact(input.First(), dateFormat, System.Globalization.CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out date))
                    break;
            }

            if (success) {
                input.RemoveAt(0);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // try parse day, if success 
            if (input.First() == "next") {
                input.RemoveAt(0);
                date = DateTime.Now;
                if (!dateFormats.dayOfWeekTextFormat.ContainsKey(input.First()))
                    throw new Exception("can't parse datetime: incorrect day of week name");

                var dayOfWeek = dateFormats.dayOfWeekTextFormat[input.First()];

                input.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek + 7);

                if (date.DayOfWeek == DayOfWeek.Sunday)
                    date = date.AddDays(7);

                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);

            }
            else if (input.First() == "previous") {
                input.RemoveAt(0);
                date = DateTime.Now;
                if (!dateFormats.dayOfWeekTextFormat.ContainsKey(input.First()))
                    throw new Exception("can't parse datetime: incorrect day of week name");

                var dayOfWeek = dateFormats.dayOfWeekTextFormat[input.First()];

                input.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek - 7);

                if (date.DayOfWeek == DayOfWeek.Sunday)
                    date = date.AddDays(7);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }
            else if (dateFormats.dayOfWeekTextFormat.ContainsKey(input.First())) {
                var dayOfWeek = dateFormats.dayOfWeekTextFormat[input.First()];

                date = DateTime.Now;

                input.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek);

                if (date.DayOfWeek == DayOfWeek.Sunday)
                    date = date.AddDays(7);

                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // try parse special days
            if (dateFormats.specialDayTextFormat.ContainsKey(input.First())) {
                date = dateFormats.specialDayTextFormat[input.First()];
                input.RemoveAt(0);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // time only, return current 
            date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }

        public IList<DateTime> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<DateTime>();

            var result = new List<DateTime>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(Parse(ref input));
                input.RemoveAt(0);
            }

            return result;
        }

        public DateTimeRange ParseRange(ref IList<string> input) {
            if (input.Count() == 0) {
                return new DateTimeRange(DateTime.MinValue, DateTime.MaxValue);
            }

            DateTime start;
            DateTime end;

            // try parse > or <
            if (input.First()[0] == '<') {
                input[0] = input[0].Replace("<", "");
                end = Parse(ref input);
                return new DateTimeRange(DateTime.MinValue, end);
            } else if (input.First()[0] == '>') {
                input[0] = input[0].Replace(">", "");
                start = Parse(ref input);
                return new DateTimeRange(start, DateTime.MaxValue);
            }

            if (input.Count() < 2) {
                throw new Exception("incorrect datetime range format");
            }

            start = Parse(ref input);
            end = Parse(ref input);

            if (start > end) {
                throw new Exception($"incorrect datetime range value, start can't be greater then end: {start}, {end}");
            }

            return new DateTimeRange(start, end);
        }

        public IList<DateTimeRange> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<DateTimeRange>();

            var result = new List<DateTimeRange>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(ParseRange(ref input));
            }

            return result;
        }
    }
}
