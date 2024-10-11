using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace СomputerEngineeringLab2.Figure
{
    public class Circle : Figures
    {

        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint, int size,
            System.Drawing.Color fillColor, System.Drawing.Color borderColor, int borderSize)
        {
            Pen pen = new Pen(borderColor, borderSize);
            graphics.DrawEllipse(pen, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
        }

        public override void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
            graphics.FillEllipse(brush, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
            graphics.DrawEllipse(pen, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
        }

    }
}
