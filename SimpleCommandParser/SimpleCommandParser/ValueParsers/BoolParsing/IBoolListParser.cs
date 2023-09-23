using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.ValueParsers.BoolParsing {
    public interface IBoolListParser {
        IList<bool> Parse(ref IList<string> input, int cnt = -1);
    }
}
