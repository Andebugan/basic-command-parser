using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal interface ICommandOption {

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Used { get; set; }

        public string Parse(string input);
        public void Execute();
        public void Clear();
    }
}
