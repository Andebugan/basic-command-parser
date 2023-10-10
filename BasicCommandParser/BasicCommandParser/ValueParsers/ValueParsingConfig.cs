using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.ValueParsers {
    public struct ValueParsingConfig {
        public string ListTerminator = "|.";

        public string ListSeparator = "|";

        public ValueParsingConfig() { }
    }
}
