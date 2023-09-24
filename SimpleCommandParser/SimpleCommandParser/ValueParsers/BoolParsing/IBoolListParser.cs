using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.BoolParsing {
    public interface IBoolListParser {
        public IList<bool> Parse(ref IList<string> input, IBoolParser boolParser, int cnt = -1);
    }
}
