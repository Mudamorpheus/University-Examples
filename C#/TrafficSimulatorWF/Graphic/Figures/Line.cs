using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Modify
using System.Drawing;

//Custom
using TrafficSimulatorWF.Graphic;

namespace TrafficSimulatorWF.Graphic.Figures
{
    class Line : Figure
    {
        //================================================
        //Перегрузка
        //================================================

        public override void Draw(Graphics graphic)
        {
            DrawColoredPen(graphic, Pens.Black);
        }

        public override void DrawColoredPen(Graphics graphic, Pen pen)
        {
            if(_x == _ex && _y == _ey)
            {
                graphic.DrawEllipse(pen, (float)(_x-_size), (float)(_y -_size), (float)(2 *_size), (float)(2 *_size));
            }
            else
            {
                graphic.DrawLine(pen, (float)(_x), (float)(_y), (float)(_ex), (float)(_ey));

                double distance = Math.Sqrt(Math.Pow(_ex-_x, 2)+Math.Pow(_y - _ey, 2));

                PointF[] array = new PointF[3];

                //Базовая точка
                array[0] = new PointF((float)_ex, (float)_ey);

                //Боковая точка
                double radian = Math.Atan2((_ey - _y), (_ex - _x));
                double shift = -20.00;

                double cosA = Math.Cos(radian+Math.PI/8);
                double sinA = Math.Sin(radian+Math.PI/8);
                array[1] = new PointF((float)(_ex + shift*cosA), (float)(_ey + shift*sinA));

                double cosB = Math.Cos(radian-Math.PI/8);
                double sinB = Math.Sin(radian-Math.PI/8);
                array[2] = new PointF((float)(_ex + shift*cosB), (float)(_ey + shift*sinB));

                graphic.DrawPolygon(pen, array);
            }
        }

        //================================================
        //Поля
        //================================================

        double _ex;
        public double EndX { get { return _ex; } set { _ex = value; } }
        double _ey;
        public double EndY { get { return _ey; } set { _ey = value; } }

        //================================================
        //Конструкторы
        //================================================

        //Пустой конструктор
        public Line()
        {

        }

        //Конструктор координат
        public Line(double x, double y)
        {
            _x = x;
            _y = y;
        }

        //Конструктор координат и размера
        public Line(double x, double y, double size) : this(x, y)
        {
            _size = size;
        }

        //Конструктор координат начало и конца и размера
        public Line(double x, double y, double ex, double ey, double size) : this(x, y, size)
        {
            _ex = ex;
            _ey = ey;
        }
    }
}
