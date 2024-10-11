using Lab01.Bridge;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Builder
{
    class SoftwareEngineeringDirector : LabDirector
    {
        public SoftwareEngineeringDirector() : base() { }
        public SoftwareEngineeringDirector(ILabBuilder Builder) : base(Builder) { }
        public void BuildImplementationsForFour()
        {
            Builder.Construct();
            Builder.BuildLab1(LabsDatabase.LAB1);
            Builder.BuildLab2(LabsDatabase.LAB2);
            Builder.BuildLab3(LabsDatabase.LAB3);
            Builder.BuildLab4(LabsDatabase.LAB4);
        }
        public void BuildFullImplementations()
        {
            Builder.Construct();
            Builder.BuildLab1(LabsDatabase.LAB1);
            Builder.BuildLab2(LabsDatabase.LAB2);
            Builder.BuildLab3(LabsDatabase.LAB3);
            Builder.BuildLab4(LabsDatabase.LAB4);
            Builder.BuildLab5(LabsDatabase.LAB5);
        }
    }
}
