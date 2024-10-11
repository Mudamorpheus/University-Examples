using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Bridge
{
    static class LabsDatabase
    {
        static public Lab1 LAB1 = new Lab1(2, new List<string> { "Мост", "Абстрактной фабрика", "Одиночка", "Строитель", "Мост", "Директор" }, 1, "Student's help");
        static public Lab2 LAB2 = new Lab2(3, new List<string> { "Команда", "Хранитель", "Заместитель"}, 2, new List<string> { "Круг", "Правильный треугольник", "Квадрат", "Правильный пятиугольник", "Правильный шестиугольник"});
        static public Lab3 LAB3 = new Lab3(2, new List<string> { "Стратегия", "Прототип"}, 3, new List<string> { "BubbleSort", "InsertionSort", "SelectionSort", "MergeSort", "HeapSort", "QuickSort" });
        static public Lab4 LAB4 = new Lab4(2, new List<string> { "Цепочка обязанностей", "Строитель"}, 4);
        static public Lab5 LAB5 = new Lab5(5, new List<string> { "Компоновщик", "Абстрактной фабрика", "Легковес", "Одиночка", "Строитель", "Итератор", "Фасад", "Посредник", "Наблюдатель" }, 5, "Магазин манги");
    }
}
