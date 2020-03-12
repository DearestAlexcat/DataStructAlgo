using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    static class SelectionSorter
    {

        public static void SelectionSort<T>(T[] array)
        {
            T min;
            int i, j, saveIndex = 0;
            bool flag;

            for (i = 0; i < array.Length; i++)
            {
                min = array[i];
                flag = false;

                for (j = i + 1; j < array.Length; j++)
                {
                    if (Comparer<T>.Default.Compare(array[i], array[j]) > 0)
                    {
                        array[i] = array[j];
                        saveIndex = j;
                        flag = true;
                    }
                }

                if (flag == true)
                {
                    array[saveIndex] = min;
                }
            }
        }


    }
}
