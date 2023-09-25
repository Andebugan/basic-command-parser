using SimpleCommandParser.ValueParsers.IntParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.StringParsing {
    public class StringParser {
        public string Parse(ref IList<string> input) {
            if (input.Count() == 0)
                return "";

            var result = input.First();
            input.RemoveAt(0);
            return result;
        }

        public IList<string> Parse(IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<string>();

            var result = new List<string>();

            var tmp = new StringBuilder();

            while (input.Count() > 0) {

                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    result.Add(tmp.ToString());
                    return result;
                }

                if (input.First() == valueParsingConfig.ListSeparator) {
                    result.Add(tmp.ToString());
                    tmp.Clear();
                }
                else {
                    tmp.Append(input.First() + " ");
                }

                input.RemoveAt(0);
            }

            return result;
        }
    }
}
