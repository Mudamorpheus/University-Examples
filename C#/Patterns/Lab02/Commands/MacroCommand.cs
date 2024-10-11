using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СomputerEngineeringLab2.Commands
{
    class MacroCommand : Command
    {
        List<Command> commands;

        public MacroCommand(List<Command> coms)
        {
            this.commands = coms;
        }
        public override void Execute()
        {
            foreach (Command c in commands)
                c.Execute();
        }
    }
}
