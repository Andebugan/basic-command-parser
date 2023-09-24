using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal interface IDateTimeListParser {
        public IList<DateTime> Parse(ref IList<string> input, IDateTimeParser dateTimeParser);
    }
}
