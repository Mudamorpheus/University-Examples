using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Custom
using TrafficSimulatorWF.Traffic;

namespace TrafficSimulatorWF.Objects.Elements
{
    class Edge
    {
        //================================================
        //Поля
        //================================================

        //Координаты
        private int _start;
        public int Start { get { return _start; } set { _start = value; } }
        private int _end;
        public int End { get { return _end; } set { _end = value; } }
        private int _weight;
        //Вес
        public int Weight { get { return _weight; } set { _weight = value; } }

        //Логистические параметры
        private TrafficEdgeParams _params;
        public TrafficEdgeParams Params { get { return _params; } set { _params = value; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой
        public Edge()
        {
            _params = new TrafficEdgeParams();
        }
        //Конструктор вершин
        public Edge(int start, int end) : this()
        {
            _start = start;
            _end = end;
        }
        //Конструктор пути
        public Edge(int start, int end, double length) : this(start, end)
        {
            _params.Length = length;
        }
    }
}
