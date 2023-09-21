using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Option {
    internal interface IOption {
        public void Parse(string input);

        public void Parse(IEnumerable<string> input);

        public string name { get; set; }
        public string description { get; set; }
    }
}
