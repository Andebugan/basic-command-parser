using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.BoolParsing {
    public class BoolListParser: IBoolListParser {
        public string ListTerminator { get; set; } = "|.";

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

        public IList<bool> Parse(ref IList<string> input, int cnt = -1) {
            if (input.Count() == 0)
                return new List<bool>();

            var list = new List<bool>();

            while (input.Count() > 0) {
                if (input.First() == ListTerminator) {
                    input.RemoveAt(0);
                    return list;
                }

                if (!boolFormats.ContainsKey(input.First()))
                    throw new Exception($"unknown value while parser bool list: {input.First()}");

                list.Add(boolFormats[input.First()]);
                input.RemoveAt(0);
            }

            return list;
        }
    }
}
