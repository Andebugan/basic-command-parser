using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal interface IDateTimeRangeParser {
        public IDateTimeRange Parse(ref IList<string> value);
    }
}
