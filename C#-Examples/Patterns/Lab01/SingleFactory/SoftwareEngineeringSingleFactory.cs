using Lab01.Bridge;
using Lab01.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.SingleFactory
{
    class SoftwareEngineeringSingleFactory : LabFactory
    {
        private static SoftwareEngineeringSingleFactory instance;
        public SoftwareEngineeringSingleFactory() { }
        public static SoftwareEngineeringSingleFactory getInstance()
        {
            if (instance == null)
            {
                instance = new SoftwareEngineeringSingleFactory();
            }
            return instance;
        }

        private SoftwareEngineeringDirector _director = new SoftwareEngineeringDirector();

        public override SoftwareEngineering CreateSoftwareEngineering()
        {
            SoftwareEngineeringBuilder builder = new SoftwareEngineeringBuilder();
            _director.Builder = builder;
            _director.BuildFullImplementations();
            SoftwareEngineering result = builder.GetProduct();
            return result;
        }
    }
}
