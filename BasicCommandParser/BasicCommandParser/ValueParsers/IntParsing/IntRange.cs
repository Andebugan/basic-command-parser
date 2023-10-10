using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.ValueParsers.IntParsing {
    public struct IntRange {
        public int Start;
        public int End;

        public IntRange(int start, int end) {
            this.Start = start;
            this.End = end;
        }
    }
}
