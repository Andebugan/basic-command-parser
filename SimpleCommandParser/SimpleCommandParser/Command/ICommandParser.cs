using SimpleCommandParser.Command;
using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    public interface ICommandParser {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ICommandOptionParser> Options { get; set; }
        public ICommand Command { get; set; }

        public void Clear();
        public ICommand Parse(string input);

        public string GetUsage(bool colored = false);
    }
}
