using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers {
    internal class ValueParsingConfig {
        public string ListTerminator { get; set; } = "|.";

        public string ListSeparator { get; set; } = "|";
    }
}
