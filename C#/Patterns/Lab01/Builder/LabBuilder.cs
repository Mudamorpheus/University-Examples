using System;
using System.Collections.Generic;
using System.Text;

using Lab01.Bridge;

namespace Lab01.Builder
{



    class SoftwareEngineeringBuilder : ILabBuilder
    {
        public void BuildLab1(Lab1 part)
        {
            _softwareEngineering.Labs.Add(part);
        }
        public void BuildLab2(Lab2 part)
        {
            _softwareEngineering.Labs.Add(part);
        }
        public void BuildLab3(Lab3 part)
        {
            _softwareEngineering.Labs.Add(part);
        }
        public void BuildLab4(Lab4 part)
        {
            _softwareEngineering.Labs.Add(part);
        }
        public void BuildLab5(Lab5 part)
        {
            _softwareEngineering.Labs.Add(part);
        }

        private SoftwareEngineering _softwareEngineering;

        public SoftwareEngineeringBuilder()
        {
            Construct();
        }

        public void Construct()
        {
            _softwareEngineering = new SoftwareEngineering();
        }

        public SoftwareEngineering GetProduct()
        {
            return _softwareEngineering;
        }
    }
}
