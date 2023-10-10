using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.ValueParsers.StringParsing {
    public interface IStringParser: IValueParser {
        public string Parse(ref IList<string> input);
        public IList<string> Parse(ref IList<string> input, ValueParsingConfig valueParsingConfig);
    }
}
