using SimpleCommandParser.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Parser : IParser {

        public IList<ICommandParser> CommandParsers { get; set; }

        public Parser(IList<ICommandParser> commandParsers) {
            CommandParsers = commandParsers;
        }

        public ICommand Parse(string input) {
            var cmd = input.Trim().Split();
            if (cmd is null || cmd.Length == 0)
                throw new Exception("no command detected");

            var parsers = CommandParsers.Where(x => x.Name == cmd.First());

            if (parsers.Count() == 0)
                throw new Exception("command doesn't exist");

            return parsers.First().Parse(input);
        }
    }
}
