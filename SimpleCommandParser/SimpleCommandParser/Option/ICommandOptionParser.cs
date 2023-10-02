using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    public interface ICommandOptionParser {

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Used { get; set; }

        public string Parse(string input, out IOption option);
        public IOption ParseOption(string input);
        public void Clear();

        public string[] GetUsage(bool colored = false);

        public string[] GetFormats(bool colored = false);
    }
}
