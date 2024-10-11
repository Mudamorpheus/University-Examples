using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CumputerEngeeneringLab3.Sort;


namespace CumputerEngeeneringLab3
{
    public delegate int Operation(int o1, int o2);
    class Program
    {
        
        static void Main(string[] args)
        {
            //Operation intCompare = Comparer<int>.Compare;
            //Operation intCompareRev = Comparer<int>.IntCompareRev;

            SortContext<int> MasterSorter = new SortContext<int>();
            MasterSorter.SortAlgorithm = new BubbleSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            IComparer<int> obj = new IntCompare();
            IComparer<int> objRev = new IntCompareRev();
            ICloneable objClone = new IntCompare();
            List<int> SortedFromBubble = MasterSorter.GetSortedNumbers(obj);
            //SortContext<int> MasterClone = new SortContext<int>();
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Bubble");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromBubble)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevBubble = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevBubble)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            MasterSorter.SortAlgorithm = new HeapSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            List<int> SortedFromHeap = MasterSorter.GetSortedNumbers(obj);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Heap");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromHeap)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevHeap = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevHeap)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            MasterSorter.SortAlgorithm = new InsertionSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            List<int> SortedFromInsertion = MasterSorter.GetSortedNumbers(obj);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Insertion");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromInsertion)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevInsertion = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevInsertion)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            MasterSorter.SortAlgorithm = new MergeSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            List<int> SortedFromMerge = MasterSorter.GetSortedNumbers(obj);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Merge");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromMerge)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevMerge = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevMerge)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            MasterSorter.SortAlgorithm = new QuickSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            List<int> SortedFromQuick = MasterSorter.GetSortedNumbers(obj);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Quick");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromQuick)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevQuick = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevQuick)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            MasterSorter.SortAlgorithm = new SelectionSort<int>();
            MasterSorter.NumbersToSort = new List<int> { 43, 434, 23, 99, 33, 23, 323 };
            List<int> SortedFromSelection = MasterSorter.GetSortedNumbers(obj);
            Console.WriteLine("==============================================");
            Console.WriteLine("Sort Context");
            Console.WriteLine("----------------------------------------------");
            foreach (int number in SortedFromSelection)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            List<int> SortedFromRevSelection = MasterSorter.GetSortedNumbers(objRev);
            foreach (int number in SortedFromRevSelection)
            {
                Console.Write(string.Format("{0}, ", number));
            }
            Console.WriteLine();
            Console.WriteLine("==============================================");





            Console.ReadLine();

        }



        //public static int IntCompare(int o1,int o2)
        //{
        //    if (o1 > o2)
        //        return 1;
        //    else if (o2 > o1)
        //        return -1;
        //    return 0;
        //}

        //public static int IntCompareRev(int o1, int o2)
        //{
        //    if (o1 > o2)
        //        return -1;
        //    else if (o2 > o1)
        //        return 1;
        //    return 0;
        //}
    }
}
