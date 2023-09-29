using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    public struct DateFormats {

        public List<string> timeFormats { get; set; } = new List<string> {
            "H:m",
            "HH:m",
            "H:mm",
            "HH:mm"
        };

        public List<string> dateFormats { get; set; } = new List<string> {
            "yyyy",
            "M.yy",
            "MM.yy",
            "d.M.yy",
            "dd.MM.yy",
            "M.yyyy",
            "MM.yyyy",
            "d.M.yyyy",
            "dd.MM.yyyy",
            "d.M"
        };

        public Dictionary<string, DayOfWeek> dayOfWeekTextFormat { get; set; } = new Dictionary<string, DayOfWeek> {
            { "sun", DayOfWeek.Sunday },
            { "sunday", DayOfWeek.Sunday },
            { "mon", DayOfWeek.Monday },
            { "monday", DayOfWeek.Monday },
            { "tue", DayOfWeek.Tuesday },
            { "tuesday", DayOfWeek.Tuesday },
            { "wen", DayOfWeek.Wednesday },
            { "wensday", DayOfWeek.Wednesday },
            { "thur", DayOfWeek.Thursday },
            { "thursday", DayOfWeek.Thursday },
            { "fri", DayOfWeek.Friday },
            { "friday", DayOfWeek.Friday },
            { "sat", DayOfWeek.Saturday },
            { "saturday", DayOfWeek.Saturday }
        };

        public Dictionary<string, DateTime> specialDayTextFormat { get; set; } = new Dictionary<string, DateTime> {
            { "yesterday", DateTime.Today.AddDays(-1)},
            { "tomorrow", DateTime.Today.AddDays(1)},
            { "today", DateTime.Today}
        };

        public DateFormats() { }
    }
}
