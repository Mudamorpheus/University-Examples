using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    class MergeSort<T> : ISort<T>
    {
        public List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            int i = 0, f = NumbersToSort.Count - 1;
            Sort(NumbersToSort, i, f, comClass);
            return NumbersToSort;
        }
        public List<T> RevSortNum(List<T> NumbersToSort, IComparer<T> comClass)
        {
            NumbersToSort = SortNum(NumbersToSort, comClass);
            NumbersToSort.Reverse();
            return NumbersToSort;
        }
        public void Sort(List<T> NumbersToSort, int l, int r, IComparer<T> comClass)
        {
            if (l < r)
            {
                int m = (l + r) / 2;

                Sort(NumbersToSort, l, m, comClass);
                Sort(NumbersToSort, m + 1, r, comClass);

                Merge(NumbersToSort, l, m, r, comClass);
            }
        }
        public void Merge(List<T> NumbersToSort, int l, int m, int r, IComparer<T> comClass)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            List<T> L = new List<T>();
            List<T> R = new List<T>();

            for (int z = 0; z < n1; ++z)
                L.Add(NumbersToSort[l + z]);
            for (int z = 0; z < n2; ++z)
                R.Add(NumbersToSort[m + 1 + z]);

            int i = 0, j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (comClass.Compare(L[i], R[j]) <= 0)
                {
                    NumbersToSort[k] = L[i];
                    i++;
                }
                else
                {
                    NumbersToSort[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                NumbersToSort[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                NumbersToSort[k] = R[j];
                j++;
                k++;
            }
        }
    }
}