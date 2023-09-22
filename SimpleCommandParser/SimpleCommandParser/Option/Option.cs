using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Option : IOption {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Used { get; set; } = false;
        public IList<IOption> SubOptions { get; set; }

        public Option(string name = "", string description = "", bool mandatory = false, IList<IOption>? subOptions = null) {
            Name = name;
            Description = description;
            Mandatory = mandatory;
            if (subOptions != null)
                SubOptions = subOptions;
            else
                SubOptions = new List<IOption>();
        }

        public void Clear() {
            Used = false;
        }

        public string Help() {
            throw new NotImplementedException();
        }

        public void Parse(string input) {
            var subparse = input.Trim().Split(SpecialSymbolsConfig.SuboptionDelimeter);
            if (subparse.Length == 0) {
                throw new Exception("");
            }
        }

        public string TryParse(string input, ref bool success) {
            throw new NotImplementedException();
        }
    }
}
