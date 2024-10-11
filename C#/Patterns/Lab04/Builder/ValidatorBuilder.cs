using System;
using System.Collections.Generic;
using System.Text;

using Lab04.Chain;

namespace Lab04.Builder
{
    //Интерфейс строителя
    interface IValidatorBuilder
    {
        //Установка валидатора
        public void SetSelector(Selector SelectorFunction);
        public void SetPredicator(Predicator PredicatorFunction);
        //Сборка
        public void Construct();
        //Получить собранный объект
        public IHandler GetProduct();
    }

    //Строитель валидаторов
    class ValidatorBuilder : IValidatorBuilder
    {
        //===Интерфейс===
        //=Методы=
        //Установка валидатора
        public void SetSelector(Selector SelectorFunction)
        {
            _validatorhandler.SelectorFunction = SelectorFunction;
        }
        public void SetPredicator(Predicator PredicatorFunction)
        {
            _validatorhandler.PredicatorFunction = PredicatorFunction;
        }

        //Переход на сборку нового объекта
        public void Construct()
        {
            _validatorhandler = new ValidatorHandler();
        }

        //===Класс===
        //=Поля=
        //Объект валидатора
        ValidatorHandler _validatorhandler;

        //=Конструкторы=
        //Пустой конструктор
        public ValidatorBuilder()
        {
            Construct();
        }

        //=Методы=
        //Получить собранный объект
        public IHandler GetProduct()
        {
            return _validatorhandler;
        }
    }
}
