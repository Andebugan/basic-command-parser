using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.BoolParsing {
    internal class BoolParser : IBoolParser {
        public Dictionary<string, bool> boolFormats { get; set; } = new Dictionary<string, bool> {
            {"t", true},
            {"true", true},
            {"y", true},
            {"yes", true},
            {"f", false},
            {"false", false},
            {"n", false},
            {"no", false}
        };

        public bool Parse(ref IList<string> input) {
            if (input.Count() == 0) {
                return true;
            }

            var parsedVal = input.First();

            if (!boolFormats.Keys.Contains(parsedVal)) {
                throw new Exception($"unknown value while parser bool option: {parsedVal}");
            }

            input.RemoveAt(0);

            return boolFormats[parsedVal];
        }
    }
}
