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
    class Round : Figure
    {
        //================================================
        //Перегрузка
        //================================================

        public override void Draw(Graphics graphic)
        {
            DrawColoredBrush(graphic, Brushes.Black);
        }

        public override void DrawColoredBrush(Graphics graphic, Brush brush)
        {
            graphic.FillEllipse(brush, (float)(_x -_size), (float)(_y -_size), (float)(2 *_size), (float)(2 *_size));
        }

        //================================================
        //Конструкторы
        //================================================

        //Пустой конструктор
        public Round()
        {

        }

        //Конструктор координат
        public Round(double x, double y)
        {
            _x = x;
            _y = y;
        }

        //Конструктор координат и размера
        public Round(double x, double y, double size) : this(x, y)
        {
            _size = size;
        }
    }
}
