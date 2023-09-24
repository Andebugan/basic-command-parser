﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal class DateFormats {
        public List<string> dateFormats { get; set; } = new List<string> {
            "yyyy",
            "d.M.yyyy",
            "dd.MM.yyyy",
            "d",
            "d.M",
            "d.MM",
        };

        public Dictionary<string, DayOfWeek> dayOfWeekTextFormat { get; set; } = new Dictionary<string, DayOfWeek> {
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
            { "saturday", DayOfWeek.Saturday },
            { "sun", DayOfWeek.Sunday },
            { "sunday", DayOfWeek.Sunday }
        };

        public Dictionary<string, DateTime> specialDayTextFormat { get; set; } = new Dictionary<string, DateTime> {
            { "yesterday", DateTime.Today.AddDays(-1)},
            { "tomorrow", DateTime.Today.AddDays(1)},
            { "today", DateTime.Today}
        };
    }
}
