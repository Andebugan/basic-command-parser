using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal interface IDateTimeListRangeParser {
        public IList<DateTimeRange> Parse(ref IList<string> input, IDateTimeRangeParser dateTimeRangeParser, IDateTimeParser dateTimeParser);
    }
}
