using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace СomputerEngineeringLab2.Figure
{
    public class Square : Figures
    {
        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint, int size,
            System.Drawing.Color fillColor, System.Drawing.Color borderColor, int borderSize)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
            var shape = new PointF[4];
            graphics.DrawRectangle(pen, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
        }

        public override void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
            var shape = new PointF[4];
            graphics.FillRectangle(brush, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
            graphics.DrawRectangle(pen, startPoint.X - size, startPoint.Y - size, 2 * size, 2 * size);
        }
    }
}
