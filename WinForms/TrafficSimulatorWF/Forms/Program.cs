using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Modify
using System.Windows.Forms;

namespace TrafficSimulatorWF
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrafficSimulatorForm());
        }
    }
}
