using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СomputerEngineeringLab2.Figure;

namespace СomputerEngineeringLab2.Commands
{
    class SizeCommand : Command
    {
        //resiver
        //Graphics graphics;
        int size;
        System.Drawing.Graphics graphics;
        System.Drawing.Point startPoint;

        Figures figure;
        public SizeCommand(Figures figure, System.Drawing.Graphics graphics, int size, System.Drawing.Point startPoint)
        {
            this.figure = figure;
            this.graphics = graphics;
            this.size = size;
            this.startPoint = startPoint;
        }
        public override void Execute()
        {
            figure.SetSize(size);
            figure.Draw(graphics, startPoint);
        }
    }
}
