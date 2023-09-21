using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Command {
    internal class Command : ICommand {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IOption> Options { get; set; }

        public Command(string name, string description, IEnumerable<IOption> options) {
            this.Name = name;
            this.Description = description;
            this.Options = options;
        }

        public void Clear() {
            foreach (var option in Options) {
                option.Clear();
            }
        }

        public void Parse(string param) {
            var cmdParams = param.Trim();
            if (cmdParams.Length == 0 && (this.Options.Where(x => x.Mandatory == true)).Count() == 0) {
                throw new Exception("command parameters are empty");
            }


        }

        public void Execute() { }
    }
}
