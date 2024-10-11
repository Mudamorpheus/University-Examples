using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СomputerEngineeringLab2.Figure;

namespace СomputerEngineeringLab2.Commands
{
    class BorderColorCommand : Command
    {
        //resiver
        //Graphics graphics;
        System.Drawing.Color borderColor;
        System.Drawing.Graphics graphics;
        System.Drawing.Point startPoint;

        Figures figure;
        public BorderColorCommand(Figures figure, System.Drawing.Graphics graphics, System.Drawing.Color borderColor, System.Drawing.Point startPoint)
        {
            this.figure = figure;
            this.graphics = graphics;
            this.borderColor = borderColor;
            this.startPoint = startPoint;
        }
        public override void Execute()
        {
            figure.SetBorderColor(borderColor);
            figure.Draw(graphics, startPoint);
        }

    }
}
