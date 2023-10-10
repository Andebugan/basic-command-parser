using BasicCommandParser.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCommandParser {
    public interface IParser {
        public IList<ICommandParser> CommandParsers { get; set; }

        public ICommand Parse(string input);
    }
}
