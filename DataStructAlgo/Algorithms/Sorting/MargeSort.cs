using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting
{
    static class MargeSorter
    {
        public static void MargeSort<T>(this IList<T> list, SortOrder order = SortOrder.ascending)
        {
            MargeSort<T>(list, 0, list.Count, order);
        }

        public static void MargeSortDescending<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            MargeSortDescending<T>(list, Comparer<T>.Create(comparison));
        }

        public static void MargeSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            MargeSort<T>(list, Comparer<T>.Create(comparison));
        }

        public static void MargeSortDescending<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            MargeSort<T>(list, 0, list.Count, SortOrder.descending, comparer);
        }

        public static void MargeSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            MargeSort<T>(list, 0, list.Count, SortOrder.ascending, comparer);
        }

        public static void MargeSort<T>(this IList<T> list, int index, int count, SortOrder order = SortOrder.ascending, IComparer<T> comparer = null)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (count < 0 || index + count > list.Count)
            {
                throw new InvalidOperationException(nameof(count));
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            Predicate<T> comparison = null;

            comparison = (order == SortOrder.descending)
                ? (T x, T y) => { return comparer.Compare(x, y) < 0; }
            : comparison = (T x, T y) => { return comparer.Compare(x, y) > 0; };


            MargeSort(list, index, count, comparison);
        }


        static void MargeSort<T>(this IList<T> list, int index, int count, Predicate<T> comparison)
        {
            if (list.Count <= 1)
            {
                return;
            }

            int sizeL = count / 2;
            int sizeR = count - sizeL;

            T[] left = new T[sizeL];
            T[] right = new T[sizeR];

            Array.Copy(list.ToArray<T>(), index, left, 0, sizeL);
            Array.Copy(list.ToArray<T>(), index + sizeL, right, 0, sizeR);

            MargeSort(left,  0, sizeL, comparison);
            MargeSort(right, 0, sizeR, comparison);
            Marge(list, left, right, index, comparison);
        }

        static void Marge<T>(IList<T> list, T[] left, T[] right, int index, Predicate<T> comparison)
        {
            int leftIdx = 0,
                rightIdx = 0,
                count = left.Length + right.Length;

            for (int i = 0; i < count; i++)
            {
                if (leftIdx > left.Length - 1)
                {
                    list[index++] = right[rightIdx++];
                }
                else if (rightIdx > right.Length - 1)
                {
                    list[index++] = left[leftIdx++];
                }
                else if (comparison(right[rightIdx], left[leftIdx]))
                {
                    list[index++] = left[leftIdx++];
                }
                else
                {
                    list[index++] = right[rightIdx++];
                }
            }
        }


    }
}
