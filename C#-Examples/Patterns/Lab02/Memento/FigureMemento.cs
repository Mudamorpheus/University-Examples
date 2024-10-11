using System;
using System.Collections.Generic;
using System.Text;
using СomputerEngineeringLab2.Figure;

namespace СomputerEngineeringLab2.Memento
{
    //Хранитель, который сохраняет состояние объекта Originator и предоставляет полный доступ только этому объекту Originator
    public class FigureMemento
    {
        public Figures Figure { get; private set; }

        public FigureMemento(Figures figure)
        {
            this.Figure = figure;
        }
    }
}
