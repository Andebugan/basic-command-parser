using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Parser : IParser {

        public IEnumerable<ICommand> Commands { get; set; }

        public Parser(IEnumerable<ICommand> commands) {
            Commands = commands;
        }

        public void Parse(string input) {
            var cmd = input.Trim().Split();
            if (cmd is null || cmd.Length == 0)
                throw new Exception("no command detected");

            var cmds = Commands.Where(x => x.Name == cmd.First());

            if (cmds is null || cmds.Count() == 0)
                throw new Exception("command doesn't exist");

            cmds.First().Parse(input);
        }
    }
}
