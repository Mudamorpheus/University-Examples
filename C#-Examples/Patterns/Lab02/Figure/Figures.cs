using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using СomputerEngineeringLab2.Memento;
using СomputerEngineeringLab2.Proxy;
using System.Windows.Forms;

namespace СomputerEngineeringLab2.Figure
{
    public class Figures : ICloneable, ISubject
    {
        //круг, правильный треугольник, квадрат, правильный пятиугольник, правильный шестиугольник
        public int size = 5; //5-100

        public System.Drawing.Color fillColor = System.Drawing.Color.White; //Белый

        public System.Drawing.Color borderColor = System.Drawing.Color.Black; //Чёрный

        public int borderSize = 1; //1-30

        public Object Clone()
        {
            return MemberwiseClone();
        }

        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint, int size,
            System.Drawing.Color fillColor, System.Drawing.Color borderColor, int borderSize)
        {
        }

        public virtual void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public void SetBorderSize(int borderSize)
        {
            this.borderSize = borderSize;
        }

        public void SetBorderColor(System.Drawing.Color borderColor)
        {
            this.borderColor = borderColor;
        }

        public void SetFillColor(System.Drawing.Color fillColor)
        {
            this.fillColor = fillColor;
        }

        

        public void Request(ListBox listBoxHistory)
        {
            listBoxHistory.Items.Add($"size : {size}, fillColor : {fillColor}, borderColor : {borderColor}, " +
                $"borderSize : {borderSize}");
        }
    }
}
