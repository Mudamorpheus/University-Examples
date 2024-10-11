using System;
using System.Collections.Generic;
using System.Text;

using Lab01.Bridge;

namespace Lab01.Builder
{
    abstract class LabDirector
    {
        private ILabBuilder _builder;
        public ILabBuilder Builder { get {return _builder;} set {_builder = value;} }

        public LabDirector() {}
        public LabDirector(ILabBuilder Builder) => _builder = Builder;
    }
}
