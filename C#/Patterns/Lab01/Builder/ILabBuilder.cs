using System;
using System.Collections.Generic;
using System.Text;
using Lab01.Bridge;

namespace Lab01.Builder
{
    interface ILabBuilder
    {
        public void BuildLab1(Lab1 part);
        public void BuildLab2(Lab2 part);
        public void BuildLab3(Lab3 part);
        public void BuildLab4(Lab4 part);
        public void BuildLab5(Lab5 part);
        public void Construct();
    }
}
