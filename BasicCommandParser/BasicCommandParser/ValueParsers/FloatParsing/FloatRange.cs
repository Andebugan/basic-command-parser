using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.ValueParsers.FloatParsing {
    public struct FloatRange {
        public float Start;
        public float End;

        public FloatRange(float start, float end) {
            Start = start;
            End = end;
        }
    }
}
