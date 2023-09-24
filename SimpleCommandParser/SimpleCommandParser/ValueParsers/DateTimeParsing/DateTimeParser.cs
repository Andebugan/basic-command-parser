using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal class DateTimeParser : IDateTimeParser {
        DateFormats dateFormats;

        private string stopper = ",";
        
        public DateTimeParser(DateFormats dateFormats) {
            this.dateFormats = dateFormats;
        }

        public DateTime Parse(ref IList<string> value) {
            if (value.Count() == 0) {
                return DateTime.Now;
            }

            var time = new DateTime();

            bool success = false;
            // try parse time
            success = DateTime.TryParseExact(value.First(), "h:m", System.Globalization.CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out time);
            

            if (success && (value.Count() == 0 || value.First().EndsWith(stopper))) {
                value.RemoveAt(0);
                var tmp = DateTime.Now;
                return new DateTime(tmp.Year, tmp.Month, tmp.Day, time.Hour, time.Minute, 0);
            }

            if (success) {
                value.RemoveAt(0);
            }

            var date = new DateTime();
            // try parse date, if success return
            foreach (var dateFormat in dateFormats.dateFormats) {
                if (success = DateTime.TryParseExact(value.First(), dateFormat, System.Globalization.CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out date))
                    break;
            }

            if (success) {
                value.RemoveAt(0);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // try parse day, if success 
            if (value.First() == "next") {
                value.RemoveAt(0);
                date = DateTime.Now;
                if (!dateFormats.dayOfWeekTextFormat.ContainsKey(value.First()))
                    throw new Exception("can't parse datetime: incorrect day of week name");

                var dayOfWeek = dateFormats.dayOfWeekTextFormat[value.First()];

                value.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek + 7);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);

            }
            else if (value.First() == "previous") {
                value.RemoveAt(0);
                date = DateTime.Now;
                if (!dateFormats.dayOfWeekTextFormat.ContainsKey(value.First()))
                    throw new Exception("can't parse datetime: incorrect day of week name");

                var dayOfWeek = dateFormats.dayOfWeekTextFormat[value.First()];

                value.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek - 7);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }
            else if (dateFormats.dayOfWeekTextFormat.ContainsKey(value.First())) {
                var dayOfWeek = dateFormats.dayOfWeekTextFormat[value.First()];

                value.RemoveAt(0);
                date = date.AddDays(dayOfWeek - date.DayOfWeek);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // try parse special days
            if (dateFormats.specialDayTextFormat.ContainsKey(value.First())) {
                date = dateFormats.specialDayTextFormat[value.First()];
                value.RemoveAt(0);
                return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            }

            // time only, return current 
            date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }
    }
}
