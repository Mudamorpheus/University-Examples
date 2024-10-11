using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    public class HeapSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            int size = NumbersToSort.Count;
            for (int i = size / 2 - 1; i >= 0; i--)
                heap(NumbersToSort, size, i, comClass);
            for (int i = size - 1; i >= 0; i--)
            {
                var temp = NumbersToSort[0];
                NumbersToSort[0] = NumbersToSort[i];
                NumbersToSort[i] = temp;
                heap(NumbersToSort, i, 0, comClass);
            }
            return NumbersToSort;
        }
        public List<T> RevSortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            NumbersToSort = SortNum(NumbersToSort, comClass);
            NumbersToSort.Reverse();
            return NumbersToSort;
        }
        private void heap(List<T> NumbersToSort, int heapSize, int i, IComparer<T> comClass)
        {
            int bigger = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < heapSize && comClass.Compare(NumbersToSort[left], NumbersToSort[bigger]) > 0)
                bigger = left;
            if (right < heapSize && comClass.Compare(NumbersToSort[right], NumbersToSort[bigger]) > 0)
                bigger = right;
            if (bigger != i)
            {
                T swap = NumbersToSort[i];
                NumbersToSort[i] = NumbersToSort[bigger];
                NumbersToSort[bigger] = swap;

                heap(NumbersToSort, heapSize, bigger, comClass);
            }
        }
    }
}