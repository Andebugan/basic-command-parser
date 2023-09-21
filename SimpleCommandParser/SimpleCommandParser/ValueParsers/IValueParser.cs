using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParser {
    internal interface IValueParser {
        public bool TryParse(IEnumerable<string> values);

        public bool TryParseList(IEnumerable<string> values);
    }
}
