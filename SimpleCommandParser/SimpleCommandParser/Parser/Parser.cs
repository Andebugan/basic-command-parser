using SimpleCommandParser.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Parser {
    internal class Parser : IParser {
        public string CommandDelimeter { get; set; } = "~";

        public IEnumerable<ICommand> Commands { get; set; }

        public Parser(IEnumerable<ICommand> commands) {
            this.Commands = commands;
        }

        public void Parse(string input) {
            // separate different commands
            var textCommands = input.Split(CommandDelimeter);
            // for each resulted string - check if command exists, if yes - process
            foreach (var textCommand in textCommands) {
                var cmd = textCommand.Trim().Split();
                if (cmd is null || cmd.Length == 0)
                    throw new Exception("no command detected");

                var cmds = Commands.Where(x => x.Name == cmd.First());

                if (cmds is null || cmds.Count() == 0)
                    throw new Exception("command doesn't exist");

                cmds.First().Execute(textCommand.Remove(0, cmd.First().Length));
            }
        }
    }
}
