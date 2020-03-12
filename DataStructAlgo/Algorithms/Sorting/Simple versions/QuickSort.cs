using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    static class QuickSorter
    {
        public static void QuickSort<T>(T[] array, int left, int right)
        {
            T temp;

            int pivot = (right + left) / 2;
            int i = left;
            int j = right;

            do
            {
                while (i < right && Comparer<T>.Default.Compare(array[pivot], array[i]) > 0) i++;
                while (j > left  && Comparer<T>.Default.Compare(array[j], array[pivot]) > 0) j--;

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }

            } while (i <= j);

            if (i < right) QuickSort(array, i, right);
            if (j > left) QuickSort(array, left, j);
        }
    }
}


