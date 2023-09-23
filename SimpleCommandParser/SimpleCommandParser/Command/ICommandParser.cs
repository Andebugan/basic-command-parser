using SimpleCommandParser.Command;
using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal interface ICommandParser {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ICommandOptionParser> Options { get; set; }
        public ICommand Command { get; set; }

        public void Clear();
        public ICommand Parse(string input);
    }
}
