using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers {
    public interface IBoolParser: IValueParser {
        public bool Parse(ref IList<string> input);

        public IList<bool> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig);
    }
}
