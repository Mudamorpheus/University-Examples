using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Bridge
{
    abstract class Lab
    {
        protected List<ILab> _labs;
        public List<ILab> Labs { get {return _labs;} set { _labs = value;} }

        public Lab() => _labs = new List<ILab>();
        public Lab(List<ILab> Parts) => _labs = Parts;
    }
}
