using BasicCommandParser.ValueParsers.IntParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.ValueParsers.StringParsing {
    public class StringParser {
        public string ValueTypeName { get; } = "string";

        public string Parse(ref IList<string> input) {
            if (input.Count() == 0)
                return "";

            var result = input.First();
            input.RemoveAt(0);
            return result;
        }

        public IList<string> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<string>();

            var result = new List<string>();

            var tmp = new StringBuilder();

            var str = "";

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    str = str.Remove(str.Length - 1);
                    result.Add(str);
                    return result;
                }

                if (input.First() == valueParsingConfig.ListSeparator) {
                    str = tmp.ToString();
                    str = str.Remove(str.Length - 1);
                    result.Add(str);
                    tmp.Clear();
                }
                else {
                    tmp.Append(input.First() + " ");
                }

                input.RemoveAt(0);
            }


            str = tmp.ToString();
            str = str.Remove(str.Length - 1);
            result.Add(str);

            return result;
        }
    }
}
