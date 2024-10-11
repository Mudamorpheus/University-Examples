using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    public class SortContext<T> 
    {
        public List<T> NumbersToSort { get; set; }

        public ISort<T> SortAlgorithm { set; get; }

        public void SetSort(ISort<T> sort)
        {
            SortAlgorithm = sort;
        }

        public List<T> GetSortedNumbers(IComparer<T> comClass)
        {
            SortContext<T> temp = this.DeepCopy();
            return SortAlgorithm.SortNum(temp.NumbersToSort, comClass);
        }

        public SortContext<T> DeepCopy() 
        {
            SortContext<T> res = new SortContext<T>();
            res.NumbersToSort = new List<T>();
            for (int i = 0; i < NumbersToSort.Count; i++)
            {
                res.NumbersToSort.Add(NumbersToSort[i]);
            }
            return res;
        }
    }
}
