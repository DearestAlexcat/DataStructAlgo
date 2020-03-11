using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.Algorithms.Sorting
{
    static class SelectionSorter
    {
        public static void SelectionSort<T>(this IList<T> list, SortOrder order = SortOrder.ascending)
        {
            SelectionSort<T>(list, 0, list.Count, order);
        }

        public static void SelectionSortDescending<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            SelectionSortDescending<T>(list, Comparer<T>.Create(comparison));
        }

        public static void SelectionSort<T>(this IList<T> list, Comparison<T> comparison)
        {
            if (list.Count == 0)
            {
                return;
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            SelectionSort<T>(list, Comparer<T>.Create(comparison));
        }

        public static void SelectionSortDescending<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            SelectionSort<T>(list, 0, list.Count, SortOrder.descending, comparer);
        }

        public static void SelectionSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            if (list.Count == 0)
            {
                return;
            }

            SelectionSort<T>(list, 0, list.Count, SortOrder.ascending, comparer);
        }

        public static void SelectionSort<T>(this IList<T> list, int index, int count, SortOrder order = SortOrder.ascending, IComparer<T> comparer = null)
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

            T min;

            int i,
                j,
                saveIndex = 0,
                lastIndex = index + count - 1;

            bool flag;

            for (i = index; i < lastIndex; i++)
            {
                min = list[i];
                flag = false;

                for (j = i + 1; j < lastIndex; j++)
                {
                    if (comparison(list[i], list[j]))
                    {
                        list[i] = list[j];
                        saveIndex = j;
                        flag = true;
                    }
                }

                if (flag == true)
                {
                    list[saveIndex] = min;
                }
            }
        }
    }
}
