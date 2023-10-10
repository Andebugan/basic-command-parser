using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser {
    static class SpecialSymbolsConfig {
        public static string OptionDelimeter { get; set; } = "--";

        public static string SuboptionDelimeter { get; set; } = "-";
    }
}
