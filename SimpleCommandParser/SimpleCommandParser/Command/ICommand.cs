using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Command {
    internal interface ICommand {
        public void Execute(string param);
        public void Execute(IEnumerable<string> param);

        public string name { get; set; }
        public string description { get; set; }
        public IEnumerable<IOption> options { get; set; }
    }
}
