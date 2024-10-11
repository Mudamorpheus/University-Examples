using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Bridge
{
    class SoftwareEngineering : Lab
    {
        public SoftwareEngineering() : base() { }
        public SoftwareEngineering(List<ILab> Labs) : base(Labs) { }
    }

    class Engish : Lab
    {
        public Engish() : base() { }
        public Engish(List<ILab> Labs) : base(Labs) { }
    }

    class Physic : Lab
    {
        public Physic() : base() { }
        public Physic(List<ILab> Labs) : base(Labs) { }
    }

    class DataBase : Lab
    {
        public DataBase() : base() { }
        public DataBase(List<ILab> Labs) : base(Labs) { }
    }

    class ComputerNetworks : Lab
    {
        public ComputerNetworks() : base() { }
        public ComputerNetworks(List<ILab> Labs) : base(Labs) { }
    }
}
