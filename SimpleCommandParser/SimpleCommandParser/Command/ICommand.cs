using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal interface ICommand {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ICommandOption> Options { get; set; }

        public void Clear();
        public void Parse(string param);
        public void Execute();
    }
}
