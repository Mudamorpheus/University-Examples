using System;
using System.Collections.Generic;
using System.Text;
using СomputerEngineeringLab2.Figure;


namespace СomputerEngineeringLab2.Memento
{
    //Выполняет только функцию хранения объекта Memento, в то же время у него нет полного доступа
    //к хранителю и никаких других операций над хранителем, кроме собственно сохранения, он не производит
    public class Originator
    {
        public Figures Figure = new Figures();

        public FigureMemento SaveState()
        {
            return new FigureMemento((Figures) Figure.Clone());
        }
        public void RestoreState(FigureMemento memento)
        {
            this.Figure = memento.Figure;
        }
    }
}
