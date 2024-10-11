using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Custom
using TrafficSimulatorWF.Traffic;

namespace TrafficSimulatorWF.Objects.Elements
{
    class Vertex
    {
        //================================================
        //Поля
        //================================================

        //Координаты
        private double _x;
        public double X { get { return _x; } set { _x = value; } }
        private double _y;
        public double Y { get { return _y; } set { _y = value; } }

        //Логистические параметры
        private TrafficVertexParams _params;
        public TrafficVertexParams Params { get { return _params; } set { _params = value; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой
        public Vertex()
        {
            _params = new TrafficVertexParams();
        }
        //Конструктор координат
        public Vertex(double x, double y) : this()
        {
            _x = x;
            _y = y;
        }
    }
}
