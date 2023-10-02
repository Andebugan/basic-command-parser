using SimpleCommandParser.ValueParsers.FloatParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.IntParsing {
    public class IntParser {
        public string ValueTypeName { get; } = "int";
        public int Parse(ref IList<string> input) {
            if (input.Count() == 0)
                throw new Exception("can't parse integer value: no value detected");

            int result;
            if (!int.TryParse(input.First(), out result))
                throw new Exception($"can't parse integer value due to incorrect format: {input.First()}");

            input.RemoveAt(0);
            return result;
        }

        public IList<int> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<int>();

            var result = new List<int>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(Parse(ref input));
            }

            return result;
        }

        public IntRange ParseRange(ref IList<string> input) {
            int start;
            int end;

            // try parse > or <
            if (input.First()[0] == '<') {
                input[0] = input[0].Replace("<", "");
                end = Parse(ref input);
                return new IntRange(int.MinValue, end);
            } else if (input.First()[0] == '>') {
                input[0] = input[0].Replace(">", "");
                start = Parse(ref input);
                return new IntRange(start, int.MaxValue);
            }

            if (input.Count() < 2) {
                throw new Exception("incorrect float range format");
            }

            start = Parse(ref input);
            end = Parse(ref input);

            return new IntRange(start, end);
        }

        public IList<IntRange> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<IntRange>();

            var result = new List<IntRange>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(ParseRange(ref input));
            }

            return result;
        }
    }
}
