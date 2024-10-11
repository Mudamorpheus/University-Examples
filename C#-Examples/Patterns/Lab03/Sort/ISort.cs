using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerEngeeneringLab3.Sort
{
    public interface ISort<T> 
    {
        List<T> SortNum(List<T> NumbersToSort, IComparer<T> comClass);
    }
}
