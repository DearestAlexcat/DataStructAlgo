using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    static class BubbleSorter
    {
        public static void BubbleSort<T>(T[] array)
        {
            int i, j;
            T temp;

            for (i = 0; i < array.Length - 1; i++)
            {
                for (j = array.Length - 1; j > i; j--)
                {
                    if (Comparer<T>.Default.Compare(array[i], array[j]) > 0) // array[i] > array[j]
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
