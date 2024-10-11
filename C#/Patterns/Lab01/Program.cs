using System;

using Lab01.Bridge;
using Lab01.SingleFactory;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftwareEngineeringSingleFactory mainfactory = SoftwareEngineeringSingleFactory.getInstance();
            SoftwareEngineering A = mainfactory.CreateSoftwareEngineering();
            Console.WriteLine("Лабораторные: ");
            foreach (var lab in A.Labs)
            {
                Console.WriteLine(" Лабораторная " + lab.Id + "     Сложность: " + lab.Difficility + "    Патерны: ( " + String.Join(", ", lab.Paterns) + " )");
            }
            Console.WriteLine();
        }
    }
}
