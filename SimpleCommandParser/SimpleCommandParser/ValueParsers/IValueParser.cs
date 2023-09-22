using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers {
    internal interface IValueParser {
        public string TryParse(string value, bool success);
    }
}
