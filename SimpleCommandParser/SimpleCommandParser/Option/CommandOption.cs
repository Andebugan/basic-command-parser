using SimpleCommandParser.ValueParsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class CommandOption : ICommandOption {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Used { get; set; } = false;
        public IList<IValueParser> ValueParsers { get; set; }

        public IList<ICommandOption> Suboptions { get; set; }

        public CommandOption(string name = "", string description = "", bool mandatory = false,
            IList<ICommandOption>? suboptions = null, IList<IValueParser>? valueParsers = null) {
            Name = name;
            Description = description;
            Mandatory = mandatory;
            ValueParsers = valueParsers == null ? new List<IValueParser>() : valueParsers;
            Suboptions = suboptions == null ? new List<ICommandOption>() : suboptions;
        }

        public void Clear() {
            Used = false;
            foreach (var suboption in Suboptions) {
                suboption.Clear();
            }
        }

        public string Parse(string input) {
            Used = true;

            input = input.Remove(0, input.IndexOf(Name) + Name.Length);

            var subparse = input.Trim().Split(SpecialSymbolsConfig.SuboptionDelimeter).ToList();
            
            if (!subparse.Any()) {
                // if option is use only
                if (ValueParsers.Count() == 0) {
                    return input;
                } else
                    throw new Exception($"incorrect option arguments: {Name}");
            }

            // no suboptions detected
            if (subparse.Count() == 1) {
                var parsedString = subparse.First();
                foreach (var valueParser in ValueParsers) {
                    parsedString = valueParser.Parse(parsedString);
                }
                return parsedString;
            }

            // process suboption
            if (subparse.Count() > 1) {
                var subopt = Suboptions.Where(x => x.Name == subparse.First());
                if (subopt.Count() == 0)
                    throw new Exception($"suboption {subparse.First()} doesn't exits for option: {Name}");
                return subopt.First().Parse(input);
            }

            return input;
        }

        public void Execute() {
            foreach (var suboption in Suboptions.Where(x => x.Used)) {
                suboption.Execute();
            }
        }
    }
}
