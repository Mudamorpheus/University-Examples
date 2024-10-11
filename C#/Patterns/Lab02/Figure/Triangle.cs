using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace СomputerEngineeringLab2.Figure
{
    public class Triangle : Figures
    {
        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint, int size,
            System.Drawing.Color fillColor, System.Drawing.Color borderColor, int borderSize)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
            var shape = new PointF[3];
            for (int a = 0; a < 3; a++)
            {
                shape[a] = new PointF(
                    startPoint.X + size * (float)Math.Cos(a * 120 * Math.PI / 180f),
                    startPoint.Y + size * (float)Math.Sin(a * 120 * Math.PI / 180f));
            }
            graphics.DrawPolygon(pen, shape);
        }

        public override void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);
            var shape = new PointF[3];
            for (int a = 0; a < 3; a++)
            {
                shape[a] = new PointF(
                    startPoint.X + size * (float)Math.Cos(a * 120 * Math.PI / 180f),
                    startPoint.Y + size * (float)Math.Sin(a * 120 * Math.PI / 180f));
            }
            graphics.FillPolygon(brush, shape);
            graphics.DrawPolygon(pen, shape);
        }
    }
}
