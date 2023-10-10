using BasicCommandParser.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCommandParser.Command {
    public interface ICommand {
        public ICommand ApplyOptions(IList<IOption> options);

        public void Execute();

        public void Undo();
    }
}
