using System;
using System.Collections.Generic;
using System.Text;

using Lab04.Chain;

namespace Lab04.Builder
{
    abstract class ValidatorDirector
    {
        //Объект интерфейса строителя
        private IValidatorBuilder _builder;
        //Метод доступа к строителю
        public IValidatorBuilder Builder { get { return _builder; } set { _builder = value; } }

        //Пустой конструктор
        public ValidatorDirector() { }
        //Конструктор строителя
        public ValidatorDirector(IValidatorBuilder Builder) => _builder = Builder;
    }

    class ChainDirector : ValidatorDirector
    {
        //Копируем пустой конструктор
        public ChainDirector() : base() {}
        //Копируем старый конструктор строителя
        public ChainDirector(ValidatorBuilder Builder) : base(Builder) {}

        //Создать начало цепочки
        public ValidatorHandler SetNewValidator(Selector SelectorFunction, Predicator PredicatorFunction)
        {
            Builder.Construct();
            Builder.SetSelector(SelectorFunction);
            Builder.SetPredicator(PredicatorFunction);
            ValidatorHandler created = (ValidatorHandler)Builder.GetProduct();

            return created;
        }

        //Добавить в цепочку валидатор
        public ValidatorHandler SetNextValidator(ValidatorHandler Validator, Selector SelectorFunction, Predicator PredicatorFunction)
        {
            Builder.Construct();
            Builder.SetSelector(SelectorFunction);
            Builder.SetPredicator(PredicatorFunction);
            ValidatorHandler created = (ValidatorHandler)Builder.GetProduct();

            if (Validator != null)
            {
                Validator.NextHandler = created;
            }

            return created;
        }

    }
}
