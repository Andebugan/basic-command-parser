using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    public interface IDateTimeParser {
        public DateTime Parse(ref IList<string> input);

        public IList<DateTime> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig);

        public DateTimeRange ParseRange(ref IList<string> input);

        public IList<DateTimeRange> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig);
    }
}
