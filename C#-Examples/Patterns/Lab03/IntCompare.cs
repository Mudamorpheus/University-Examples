using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CumputerEngeeneringLab3.Sort;

namespace CumputerEngeeneringLab3
{
    public class IntCompare : IComparer<int>, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int Compare(int x, int y)
        {
            if (x > y)
                return 1;
            else if (y > x)
                return -1;
            return 0;
        }

       
    }
}
