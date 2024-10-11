using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Lab04.Chain
{
    //Интерфейс обработчика
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }

    //Абстрактный класс обработчика.
    abstract class AbstractHandler : IHandler
    {
        //Указатель на следующий обработчик
        private IHandler _nextHandler;
        //Метод доступа следующего обработчика
        public IHandler NextHandler { get { return _nextHandler; } set { _nextHandler = value; } }

        //Следующий по цепочке
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        //Обработчик
        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    //Делегат селектора
    delegate object Selector(object input);
    //Делегат предиката
    delegate bool Predicator(object selector);

    //Объект валидатора
    class ValidatorHandler : AbstractHandler
    {
        //Функция селектора
        private Selector _selector;
        //Метод доступа к функции валидатора
        public Selector SelectorFunction { get { return _selector; } set { _selector = value; } }

        //Функция предиката
        private Predicator _predicate;
        //Метод доступа к функции валидатора
        public Predicator PredicatorFunction { get { return _predicate; } set { _predicate = value; } }

        //Конструктор
        public ValidatorHandler() { }
        ValidatorHandler(Selector SelectorFunc, Predicator PredicatorFunc)
        {
            _selector = SelectorFunc;
            _predicate = PredicatorFunc;
        }

        //Обработчик
        public override object Handle(object request)
        {
            if (_predicate(_selector(request)))
            {
                if (NextHandler != null)
                {
                    return NextHandler.Handle(request);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new ValidationException();
            }
        }
    }
}
