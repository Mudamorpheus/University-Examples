using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    class QuickSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            int i = 0, f = NumbersToSort.Count - 1;
            responsivenessQuickSort(NumbersToSort, i, f, comClass);
            return NumbersToSort;
        }
        public List<T> RevSortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            NumbersToSort = SortNum(NumbersToSort, comClass);
            NumbersToSort.Reverse();
            return NumbersToSort;
        }
        public static void responsivenessQuickSort(List<T> NumbersToSort, int i, int f, IComparer<T> comClass)
        {

            int left = i;
            int right = f;
            T pivot = NumbersToSort[(left + right) / 2];
            T change;

            while (left <= right)
            {

                while (comClass.Compare(NumbersToSort[left], pivot) < 0)
                    left = left + 1;
                
                while (comClass.Compare(NumbersToSort[right], pivot) > 0)
                    right = right - 1;

                if (left <= right)
                {
                    change = NumbersToSort[left];
                    NumbersToSort[left] = NumbersToSort[right];
                    NumbersToSort[right] = change;
                    left = left + 1;
                    right = right - 1;
                }
            }

            if (right > i)
                responsivenessQuickSort(NumbersToSort, i, right, comClass);

            if (left < f)
                responsivenessQuickSort(NumbersToSort, left, f, comClass);
        }
    }
}