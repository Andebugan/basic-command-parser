using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.BoolParsing {
    public class BoolListParser: IBoolListParser {
        public string ListTerminator { get; set; } = "|.";

        public IList<bool> Parse(ref IList<string> input, IBoolParser boolParser, int cnt = -1) {
            if (input.Count() == 0)
                return new List<bool>();

            var list = new List<bool>();

            while (input.Count() > 0) {
                if (input.First() == ListTerminator) {
                    input.RemoveAt(0);
                    return list;
                }

                list.Add(boolParser.Parse(ref input));
            }

            return list;
        }
    }
}
