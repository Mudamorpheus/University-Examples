using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СomputerEngineeringLab2.Memento
{
    //Caretaker
    public class ChangeHistory
    {
        public Stack<FigureMemento> History { get; private set; }
        public ChangeHistory()
        {
            History = new Stack<FigureMemento>();
        }
    }
}
