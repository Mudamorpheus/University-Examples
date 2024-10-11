using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using СomputerEngineeringLab2.Figure;

namespace СomputerEngineeringLab2.Commands
{
    class BorderSizeCommand : Command
    {
        //resiver
        //Graphics graphics;
        int borderSize;
        System.Drawing.Graphics graphics;
        System.Drawing.Point startPoint;

        Figures figure;
        public BorderSizeCommand(Figures figure, System.Drawing.Graphics graphics, int borderSize, System.Drawing.Point startPoint)
        {
            this.figure = figure;
            this.graphics = graphics;
            this.borderSize = borderSize;
            this.startPoint = startPoint;
        }
        public override void Execute()
        {
            figure.SetBorderSize(borderSize);
            figure.Draw(graphics, startPoint);
        }
    }
}
