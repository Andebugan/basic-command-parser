using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.IntParsing {
    public interface IIntParser: IValueParser {
        public int Parse(ref IList<string> input);

        public IList<int> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig);

        public IntRange ParseRange(ref IList<string> input);

        public IList<IList> ParseRange(ref IList<string> input, ValueParsingConfig valueParsingConfig);
    }
}
