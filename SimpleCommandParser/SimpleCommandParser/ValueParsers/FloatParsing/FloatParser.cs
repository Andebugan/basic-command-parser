using SimpleCommandParser.ValueParsers.DateTimeParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.FloatParsing {
    internal class FloatParser : IFloatParser {

        public float Parse(ref IList<string> input) {
            if (input.Count() == 0)
                throw new Exception("can't parse float value: no value detected");

            float result;
            if (!float.TryParse(input.First(), out result))
                throw new Exception($"can't parse float value due to incorrect format: {input.First()}");

            input.RemoveAt(0);
            return result;
        }

        public IList<float> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<float>();

            var result = new List<float>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(Parse(ref input));
                input.RemoveAt(0);
            }

            return result;
        }

        public FloatRange ParseRange(ref IList<string> input) {
            float start;
            float end;

            // try parse > or <
            if (input.First()[0] == '<') {
                input[0] = input[0].Remove('<');
                end = Parse(ref input);
                return new FloatRange(float.NegativeInfinity, end);
            } else if (input.First()[0] == '>') {
                input[0] = input[0].Remove('>');
                start = Parse(ref input);
                return new FloatRange(start, float.PositiveInfinity);
            }

            if (input.Count() < 2) {
                throw new Exception("incorrect float range format");
            }

            start = Parse(ref input);
            end = Parse(ref input);

            return new FloatRange(start, end);
        }

        public IList<FloatRange> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig) {
            if (input.Count() == 0)
                return new List<FloatRange>();

            var result = new List<FloatRange>();

            while (input.Count() > 0) {
                if (input.First() == valueParsingConfig.ListTerminator) {
                    input.RemoveAt(0);
                    return result;
                }

                result.Add(ParseRange(ref input));
                input.RemoveAt(0);
            }

            return result;
        }
    }
}
