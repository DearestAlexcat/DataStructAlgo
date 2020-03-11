using System;
using System.Collections.Generic;

namespace DataStructAlgo.Algorithms.Sorting
{
    static class QuickSorter
    {
        public static void QuickSort<T>(this IList<T> list, SortOrder order = SortOrder.ascending)
        {
            QuickSort<T>(list, 0, list.Count, order);
        }

        public static void BubbleSortDescending<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            BubbleSortDescending<T>(list, Comparer<T>.Create(comparison));
        }

        public static void QuickSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            QuickSort<T>(list, Comparer<T>.Create(comparison));
        }

        public static void BubbleSortDescending<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            QuickSort<T>(list, 0, list.Count, SortOrder.descending, comparer);
        }

        public static void QuickSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            QuickSort<T>(list, 0, list.Count, SortOrder.ascending, comparer);
        }


        public static void QuickSort<T>(this IList<T> list,int index, int count, SortOrder order = SortOrder.ascending, IComparer<T> comparer = null)
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

            T temp;
            int lastIndex = index + count - 1;
            int pivot = (lastIndex + index) / 2;
            int i = index;
            int j = count - 1;
            
            do
            {
                while (i < lastIndex && comparison(list[pivot], list[i])) i++;
                while (j > index && comparison(list[j], list[pivot]))  j--;

                if (i <= j)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }

            } while (i <= j);

            if (i < lastIndex)  QuickSort(list, i,     lastIndex,  order, comparer);
            if (j > index)      QuickSort(list, index, j,          order, comparer);

        }
    }
}
