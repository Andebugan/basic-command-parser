using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.DateTimeParsing {
    internal class DateTimeListParser : IDateTimeListParser {
        public string ListTerminator { get; set; } = "|.";

        public IList<DateTime> Parse(ref IList<string> input, IDateTimeParser dateTimeParser) {
            if (input.Count() == 0)
                return new List<DateTime>();

            var result = new List<DateTime>();

            while (input.Count() > 0) {
                if (input.First() == ListTerminator)
                    return result;

                result.Add(dateTimeParser.Parse(ref input));
                input.RemoveAt(0);
            }

            return result;
        }
    }
}
