using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser {
    internal class Program {
        static void Main(string[] args) {
            DateTime time;
            DateTime.TryParseExact("5.10", "yy", System.Globalization.CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.AssumeLocal, out time);
            Console.WriteLine(time);
        }
    }
}
