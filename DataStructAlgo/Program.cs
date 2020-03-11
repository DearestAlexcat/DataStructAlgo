using System;


namespace DataStructAlgo
{
    class Program
    {

        static void InsertionSort(int[] list)
        {
            int temp, i, j;

            for (i = 0; i < list.Length - 1; i++)
            {
                temp = list[i + 1];
                for (j = i; j >= 0 && temp < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = temp;
            }
        }

        static void Main(string[] args)
        {


            int[] arr = new int[] { 2, 1, 5, 4, 3, 2, 1 };

             DataStructAlgo.Algorithms.Sorting.InsertionSorter.InsertionSort(arr, 2, 3);

             //InsertionSort(arr);

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
