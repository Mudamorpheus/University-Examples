using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    class InsertionSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            int i, j;
            T aux;

            for (j = 1; j < NumbersToSort.Count; j++)
            {
                aux = NumbersToSort[j];
                for (i = j - 1; i >= 0 && comClass.Compare(NumbersToSort[i], aux) > 0; i--)
                    NumbersToSort[i + 1] = NumbersToSort[i];
                NumbersToSort[i + 1] = aux;
            }
            return NumbersToSort;
        }
    }
}