﻿using SimpleCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandParser.Command {
    internal interface ICommand {
        public ICommand ApplyOptions(IList<IOption> options);
    }
}
