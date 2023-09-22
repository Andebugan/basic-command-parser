using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Command : ICommand {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IOption> Options { get; set; }

        public Command(string name, string description, IEnumerable<IOption> options) {
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

            // phase one - parse all explicitly stated options

            var options = paramTrimmed.Split(SpecialSymbolsConfig.OptionDelimeter).ToList();

            while (options.Count() > 0) {
                string optionName = options.First().Split().First();
                optionName = optionName.Split(SpecialSymbolsConfig.SuboptionDelimeter).First();

                var op = Options.Where(x => x.Name == optionName);

                if (op.Count() == 0 && options.Count() > 1)
                    throw new Exception("unknown option");

                op.First().Parse(input);

                options.RemoveAt(0);
            }

            // phase two - parse all other unused options, mandatory first, then others in the order they appear in the options list
            bool found;
            if (options.Count() > 0) {
                while (input.Length > 0) {
                    found = false;
                    var unusedMandatoryOptions = Options.Where(x => x.Used == false && x.Mandatory == true);
                    if (unusedMandatoryOptions.Count() > 0) {
                        foreach (var option in unusedMandatoryOptions) {
                            input = option.TryParse(input, ref found);
                            if (found) { break; }
                        }
                    }
                    else {
                        var unusedOptions = Options.Where(x => x.Used == false && x.Mandatory == false);
                        foreach (var option in unusedMandatoryOptions) {
                            input = option.TryParse(input, ref found);
                            if (found) { break; }
                        }
                    }
                }
            }

            // check if any unused mandatory options exist, if yes => throw exception
            var unusedMandatory = Options.Where(x => x.Used == false && x.Mandatory == true);
            if (unusedMandatory.Count() > 0) {
                throw new Exception($"can't execute command because unused mandatory parameter was not used: {unusedMandatory.First().Name}");
            }

            Execute();
        }

        public void Execute() { }

        public string Help(bool showOptions = false, IList<string>? optionNames = null) { return ""; }
    }
}
