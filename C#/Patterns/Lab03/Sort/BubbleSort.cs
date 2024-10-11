using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    public class BubbleSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            T temp;
            for (int topIndex = 1; topIndex <= NumbersToSort.Count; topIndex++)
                for (int bottomIndex = 0; bottomIndex < NumbersToSort.Count - topIndex; bottomIndex++)
                    if (comClass.Compare(NumbersToSort[bottomIndex], NumbersToSort[bottomIndex + 1]) > 0)
                    {
                        temp = NumbersToSort[bottomIndex];
                        NumbersToSort[bottomIndex] = NumbersToSort[bottomIndex + 1];
                        NumbersToSort[bottomIndex + 1] = temp;
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
