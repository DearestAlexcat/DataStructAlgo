using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting.Simple_versions
{
    static class MargeSorter
    {
        public static void MargeSort<T>(T[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int sizeL = array.Length / 2;
            int sizeR = array.Length - sizeL;

            T[] left = new T[sizeL];
            T[] right = new T[sizeR];

            Array.Copy(array, 0, left, 0, sizeL);
            Array.Copy(array, sizeL, right, 0, sizeR);

            MargeSort(left);
            MargeSort(right);
            Marge(array, left, right);
        }

        static void Marge<T>(T[] array, T[] left, T[] right)
        {
            int leftIdx = 0,
                rightIdx = 0,
                count = left.Length + right.Length;

            for (int i = 0; i < count; i++)
            {
                if (leftIdx > left.Length - 1)
                {
                    array[i] = right[rightIdx++];
                }
                else if (rightIdx > right.Length - 1)
                {
                    array[i] = left[leftIdx++];
                }
                else if (Comparer<T>.Default.Compare(right[rightIdx], left[leftIdx]) > 0) //right[rightIdx] > left[leftIdx]
                    {
                    array[i] = left[leftIdx++];
                }
                else
                {
                    array[i] = right[rightIdx++];
                }
            }
        }
    }
}
