using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal class DateTimeRangeParser : IDateTimeRangeParser {
        DateFormats dateFormats;

        public DateTimeRangeParser(DateFormats dateFormats) {
            this.dateFormats = dateFormats;
        }

        public DateTimeRange Parse(ref IList<string> value, IDateTimeParser datetimeParser) {
            if (value.Count() == 0) {
                throw new Exception("cannot parse datetime range, no value detected");
            }

            DateTime? start = null;
            DateTime? end = null;

            // try parse > or <
            if (value.First()[0] == '<') {
                value[0] = value[0].Remove('<');
                end = datetimeParser.Parse(ref value);
                return new DateTimeRange(null, end);
            } else if (value.First()[0] == '>') {
                value[0] = value[0].Remove('>');
                start = datetimeParser.Parse(ref value);
                return new DateTimeRange(start, null);
            }

            if (value.Count() < 2) {
                throw new Exception("incorrect datetime range format");
            }

            start = datetimeParser.Parse(ref value);
            end = datetimeParser.Parse(ref value);

            return new DateTimeRange(start, end);
        }
    }
}
