using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    class SelectionSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            T t;
            int fixo, menor, i;

            for (fixo = 0; fixo < NumbersToSort.Count - 1; fixo++)
            {
                menor = fixo;

                for (i = menor + 1; i < NumbersToSort.Count; i++)
                    if (comClass.Compare(NumbersToSort[i], NumbersToSort[menor]) < 0)
                        menor = i;

                if (menor != fixo)
                {
                    t = NumbersToSort[fixo];
                    NumbersToSort[fixo] = NumbersToSort[menor];
                    NumbersToSort[menor] = t;
                }
            }
            return NumbersToSort;
        }
        public List<T> RevSortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            NumbersToSort = SortNum(NumbersToSort, comClass);
            NumbersToSort.Reverse();
            return NumbersToSort;
        }
    }
}