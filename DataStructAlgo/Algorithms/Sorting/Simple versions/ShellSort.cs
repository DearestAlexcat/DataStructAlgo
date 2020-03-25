using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    class ShellSorter
    {
        public static void ShellSort<T>(T[] array)
        {
            T temp;
            int i, j, step = array.Length;

            do
            {
                step >>= 1;

                for (i = 0; i < array.Length - step; i++)
                {
                    temp = array[i + step];
                    for (j = i; j >= 0 && Comparer<T>.Default.Compare(temp, array[j]) < 0; j -= step)
                    {
                        array[j + step] = array[j];
                    }
                    array[j + step] = temp;
                }
            } while (step > 1);

        }
    }
}
