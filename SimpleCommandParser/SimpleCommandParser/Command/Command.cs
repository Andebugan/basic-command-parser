using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Command : ICommand {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ICommandOption> Options { get; set; }

        public Command(string name, string description, IEnumerable<ICommandOption> options) {
            Name = name;
            Description = description;
            Options = options;
        }

        public void Clear() {
            foreach (var option in Options) {
                option.Clear();
            }
        }

        public void Parse(string input) {
            input = input.Remove(0, input.IndexOf(Name) + Name.Length);

            var paramTrimmed = input.Trim();
            if (paramTrimmed.Length == 0 && (Options.Where(x => x.Mandatory == true)).Count() == 0) {
                throw new Exception("command parameters are empty");
            }

            var options = paramTrimmed.Split(SpecialSymbolsConfig.OptionDelimeter).ToList();

            while (options.Count() > 0) {
                string optionName = options.First().Split().First();
                optionName = optionName.Split(SpecialSymbolsConfig.SuboptionDelimeter).First();

                var op = Options.Where(x => x.Name == optionName);

                if (op.Count() == 0)
                    throw new Exception("unknown option");

                var option = op.First();

                option.Parse(input);

                options.RemoveAt(0);
            }

            // check if any unused mandatory options exist, if yes => throw exception
            var unusedMandatory = Options.Where(x => x.Used == false && x.Mandatory == true);
            if (unusedMandatory.Count() > 0) {
                throw new Exception($"can't execute command because unused mandatory parameter was not used: {unusedMandatory.First().Name}");
            }
        }

        public void Execute() {
            foreach (var op in Options.Where(x => x.Used)) {
                op.Execute();
            }
        }

        public string Help(bool showOptions = false, IList<string>? optionNames = null) { return ""; }
    }
}
