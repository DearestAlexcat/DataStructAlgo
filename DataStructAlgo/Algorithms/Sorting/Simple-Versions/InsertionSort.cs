using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    static class InsertionSorter
    {
        public static void InsertionSort<T>(T[] array)
        {
            int i, j;
            T temp;

            for (i = 0; i < array.Length - 1; i++)
            {
                temp = array[i + 1];
                for (j = i; j >= 0 && Comparer<T>.Default.Compare(array[j], temp) > 0; j--) // //array[j] > temp
                {
                    array[j + 1] = array[j];
                }
                array[j + 1] = temp;
            }
        }

    }
}
