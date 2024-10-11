using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using СomputerEngineeringLab2.Figure;

namespace СomputerEngineeringLab2.Commands
{
    class FillCommand : Command
    {
        //resiver
        //Graphics graphics;
        System.Drawing.Color fillColor;
        System.Drawing.Graphics graphics;
        System.Drawing.Point startPoint;

        Figures figure;
        public FillCommand(Figures figure, System.Drawing.Graphics graphics, System.Drawing.Color fillColor, System.Drawing.Point startPoint)
        {
            this.figure = figure;
            this.graphics = graphics;
            this.fillColor = fillColor;
            this.startPoint = startPoint;
        }
        public override void Execute()
        {
            //graphics.FillRectangle(brush, rectangle);
            figure.SetFillColor(fillColor);
            figure.Draw(graphics, startPoint);
        }
    }
}
