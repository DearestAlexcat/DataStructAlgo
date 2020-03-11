using System;
using System.Collections.Generic;

namespace DataStructAlgo.Algorithms.Sorting
{
    static class BubbleSorter
    {
        public static void BubbleSort<T>(this IList<T> list, SortOrder order = SortOrder.ascending)
        {
            BubbleSort<T>(list, 0, list.Count, order); 
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

        public static void BubbleSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            BubbleSort<T>(list, Comparer<T>.Create(comparison));
        }

        public static void BubbleSortDescending<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            BubbleSort<T>(list, 0, list.Count, SortOrder.descending, comparer);
        }

        public static void BubbleSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            BubbleSort<T>(list, 0, list.Count, SortOrder.ascending, comparer);
        }

        public static void BubbleSort<T>(this IList<T> list, int index, int count, SortOrder order = SortOrder.ascending, IComparer<T> comparer = null)
        {
            if (list.Count == 0)
            {
                return;
            }

            if(index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if(count < 0 || index + count > list.Count)
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
                :  comparison = (T x, T y) => { return comparer.Compare(x, y) > 0; };

            T temp;
            int i, j, lastIndex = index + count - 1;

            for (i = index; i < lastIndex; i++)
            {
                for (j = lastIndex; j > i; j--)
                {
                    if (comparison(list[i], list[j]))
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
