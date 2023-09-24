using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal interface IDateTimeRange {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
