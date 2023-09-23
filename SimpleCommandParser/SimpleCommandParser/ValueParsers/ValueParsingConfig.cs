using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers {
    internal class ValueParsingConfig {
        public string ListTerminator { get; set; } = "|.";

        public string ListSeparator { get; set; } = "|";

        public List<string> datetimeFormats { get; set; } = new List<string> {
            "yyyy",
            "d.M.yyyy",
            "dd.MM.yyyy",
            "h:m",
            "h:m d",
            "h:m d.M",
            "h:m d.MM.yyyy",
            "h:m d.M.yyyy"
        };
    }
}
