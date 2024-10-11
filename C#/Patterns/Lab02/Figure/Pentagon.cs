using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace СomputerEngineeringLab2.Figure
{
    public class Pentagon : Figures
    {
        public void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint, int size,
               System.Drawing.Color fillColor, System.Drawing.Color borderColor, int borderSize)
        {
            var shape = new PointF[5];
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);

            for (int a = 0; a < 5; a++)
            {
                shape[a] = new PointF(
                    startPoint.X + size * (float)Math.Cos(a * 72 * Math.PI / 180f),
                    startPoint.Y + size * (float)Math.Sin(a * 72 * Math.PI / 180f));
            }

            graphics.DrawPolygon(pen, shape);
        }

        public override void Draw(System.Drawing.Graphics graphics, System.Drawing.Point startPoint)
        {
            var shape = new PointF[5];
            SolidBrush brush = new SolidBrush(fillColor);
            Pen pen = new Pen(borderColor, borderSize);

            for (int a = 0; a < 5; a++)
            {
                shape[a] = new PointF(
                    startPoint.X + size * (float)Math.Cos(a * 72 * Math.PI / 180f),
                    startPoint.Y + size * (float)Math.Sin(a * 72 * Math.PI / 180f));
            }
            graphics.FillPolygon(brush, shape);
            graphics.DrawPolygon(pen, shape);
        }

    }
}
