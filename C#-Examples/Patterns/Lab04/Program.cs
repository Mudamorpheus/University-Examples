using System;

using Lab04.Builder;
using Lab04.Chain;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainDirector director = new ChainDirector(new ValidatorBuilder());

            //Главный валидатор
            //Если подстрока начиная с 2 символа больше 5
            Selector selectorMain = (object input) => { return input.ToString().Substring(2); };
            Predicator predicatorMain = (object selector) => { return selector.ToString().Length > 5; };
            //
            ValidatorHandler validatorMain = director.SetNewValidator(selectorMain, predicatorMain);

            //Следующий валидатор
            //Если строка меньше 10
            Selector selectorA = (object input) => { return input.ToString(); };
            Predicator predicatorA = (object selector) => { return selector.ToString().Length < 10; };
            //
            ValidatorHandler validatorA = director.SetNextValidator(validatorMain, selectorA, predicatorA);

            //Результат
            string textA = "ABCDF";
            try
            { 
                validatorMain.Handle(textA);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string textB = "12345678";
            try
            {
                validatorMain.Handle(textB);
                Console.WriteLine("Валидация прошла успешно.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
