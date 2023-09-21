using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Option {
    internal interface IOption {
        public void Parse(string input);

        public void Clear();
        
        public void Parse(IEnumerable<string> input);

        public string Name { get; set; }
        public string Description { get; set; }

        public bool Mandatory { get; set; }
    }
}
