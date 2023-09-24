using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal class DateTimeListRangeParser : IDateTimeListRangeParser {
        public string ListTerminator { get; set; } = "|.";

        public IList<DateTimeRange> Parse(ref IList<string> input, IDateTimeRangeParser dateTimeRangeParser, IDateTimeParser dateTimeParser) {
            if (input.Count() == 0)
                return new List<DateTimeRange>();

            var result = new List<DateTimeRange>();

            while (input.Count() > 0) {
                if (input.First() == ListTerminator)
                    return result;

                result.Add(dateTimeRangeParser.Parse(ref input, dateTimeParser));
                input.RemoveAt(0);
            }

            return result;
        }
    }
}
