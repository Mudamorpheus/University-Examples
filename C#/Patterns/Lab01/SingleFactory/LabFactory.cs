using System;
using System.Collections.Generic;
using System.Text;

using Lab01.Bridge;
using Lab01.Builder;

namespace Lab01.SingleFactory
{
    abstract class LabFactory
    {
        private LabDirector _director;
        public LabDirector Director { get { return _director; } set { _director = value; } }
        abstract public SoftwareEngineering CreateSoftwareEngineering();
    }
}
