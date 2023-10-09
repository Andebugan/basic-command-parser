using SimpleCommandParser.Option;
using SimpleCommandParser.ValueParsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    public abstract class CommandOptionParser : ICommandOptionParser {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        public bool Used { get; set; } = false;

        public IList<ICommandOptionParser> Suboptions { get; set; }

        public CommandOptionParser() {
            Name = "";
            Description = "";
            Mandatory = false;
            Suboptions = new List<ICommandOptionParser>();
        }

        public CommandOptionParser(string name = "", string description = "", bool mandatory = false,
            IList<ICommandOptionParser>? suboptions = null) {
            Name = name;
            Description = description;
            Mandatory = mandatory;
            Suboptions = suboptions == null ? new List<ICommandOptionParser>() : suboptions;
        }

        public void Clear() {
            Used = false;
            foreach (var suboption in Suboptions) {
                suboption.Clear();
            }
        }

        public string Parse(string input, out IOption option) {
            Used = true;

            input = input.Remove(0, input.IndexOf(Name) + Name.Length);

            var subparse = input.Trim().Split(SpecialSymbolsConfig.SuboptionDelimeter, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (subparse.Count() == 1)
                option = ParseOption(subparse.First());
            else if (subparse.Count() > 1) {
                var subopt = Suboptions.Where(x => x.Name == subparse.First());
                if (subopt.Count() == 0)
                    throw new Exception($"suboption {subparse.First()} doesn't exits for option: {Name}");
                return subopt.First().Parse(input, out option);
            }
            option = ParseOption("");

            return input;
        }

        public abstract IOption ParseOption(string input);


        public abstract string[] GetUsage(bool colored);

        public abstract string[] GetFormats(bool colored);
    }
}
