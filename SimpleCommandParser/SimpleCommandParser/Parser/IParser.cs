using SimpleCommandParser.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCommandParser.Parser {
    internal interface IParser {
        public string CommandDelimeter { get; set; }
        public IEnumerable<ICommand> Commands { get; set; }

        public void Parse(string input);
    }
}
