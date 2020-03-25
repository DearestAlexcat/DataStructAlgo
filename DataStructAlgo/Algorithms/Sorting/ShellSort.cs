using System;
using System.Collections.Generic;

namespace DataStructAlgo.Algorithms.Sorting
{
    static class ShellSorter
    {
        public static void ShellSort<T>(this IList<T> list, SortOrder order = SortOrder.ascending)
        {
            ShellSort<T>(list, 0, list.Count, order);
        }

        public static void ShellSortDescending<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            ShellSortDescending<T>(list, Comparer<T>.Create(comparison));
        }

        public static void ShellSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            ShellSort<T>(list, Comparer<T>.Create(comparison));
        }

        public static void ShellSortDescending<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            ShellSort<T>(list, 0, list.Count, SortOrder.descending, comparer);
        }

        public static void ShellSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            ShellSort<T>(list, 0, list.Count, SortOrder.ascending, comparer);
        }

        public static void ShellSort<T>(this IList<T> list, int index, int count, SortOrder order = SortOrder.ascending, IComparer<T> comparer = null)
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
            int i, j, step = list.Count;

            do
            {
                step >>= 1;

                for (i = 0; i < list.Count - step; i++)
                {
                    temp = list[i + step];

                    for (j = i; j >= 0 && comparison(list[j], temp); j -= step)
                    {
                        list[j + step] = list[j];
                    }

                    list[j + step] = temp;
                }
            } while (step > 1);
        }
    }
}
