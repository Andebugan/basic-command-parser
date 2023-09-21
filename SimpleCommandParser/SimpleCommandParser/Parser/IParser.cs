using SimpleCommandParser.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCommandParser.Parser {
    internal interface IParser {
        public ICommand Parse(string input);

        public ICommand Parse(IEnumerable<string> input);

        public string commandDelimeter { get; }
        public string optionDelimeter { get; }
    }
}
