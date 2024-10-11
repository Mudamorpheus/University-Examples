using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modify
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulatorWF.Graphic.Figures
{
    abstract class Figure
    {
        //================================================
        //Поля
        //================================================

        protected double _x;
        public double X { get { return _x; } set { _x = value; } }
        protected double _y;
        public double Y { get { return _y; } set { _y = value; } }
        protected double _size;
        public double Size { get { return _size; } set { _size = value; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой
        public Figure()
        {

        }
        //Конструктор вершин
        public Figure(double x, double y, double size) : base()
        {
            _x = x;
            _y = y;
            _size = size;
        }

        //================================================
        //Методы
        //================================================

        public virtual void Draw(Graphics graphic) { }
        public virtual void DrawColoredBrush(Graphics graphic, Brush brush) { }
        public virtual void DrawColoredPen(Graphics graphic, Pen pen) { }
    }
}
