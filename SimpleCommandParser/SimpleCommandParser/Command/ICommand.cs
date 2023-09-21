using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Command {
    internal interface ICommand {
        public void Clear();

        public void Parse(string param);

        public void Execute();

        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IOption> Options { get; set; }
    }
}
