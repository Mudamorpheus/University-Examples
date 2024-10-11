using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СomputerEngineeringLab2.Figure;
using System.Windows.Forms;
using СomputerEngineeringLab2.Commands;

namespace СomputerEngineeringLab2.Proxy
{
    public class FigureProxy : ISubject
    {
        Figures realSubject;

        public FigureProxy(Figures realSubject)
        {
            this.realSubject = realSubject;
        }

        public void Request(ListBox listBoxHistory)
        {
            if (realSubject == null)
                realSubject = new Figures();
            realSubject.Request(listBoxHistory);
            //listBoxHistory.Items.Add();
        }
    }
}
