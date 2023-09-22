using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCommandParser {
    internal interface IParser {
        public IEnumerable<ICommand> Commands { get; set; }

        public void Parse(string input);
    }
}
