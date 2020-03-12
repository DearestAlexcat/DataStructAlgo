using System;


namespace DataStructAlgo
{
    class Program
    {

        static void MargeSort(int[] list)
        {
            if(list.Length <= 1)
            {
                return;
            }

            int sizeL = list.Length / 2;
            int sizeR = list.Length - sizeL;

            int[] left = new int[sizeL];
            int[] right = new int[sizeR];

            Array.Copy(list, 0, left, 0, sizeL);
            Array.Copy(list, sizeL, right, 0, sizeR);

            MargeSort(left);
            MargeSort(right);
            Marge(list, left, right);
        }

        static void Marge(int[] list, int[] left, int[] right)
        {

            int leftIdx = 0, rightIdx = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if(leftIdx > left.Length - 1)
                {
                    list[i] = right[rightIdx++];
                }
                else if (rightIdx > right.Length - 1)
                {
                    list[i] = left[leftIdx++];
                }
                else if(left[leftIdx] < right[rightIdx])
                {
                    list[i] = left[leftIdx++];
                }
                else
                {
                    list[i] = right[rightIdx++];
                }
            }
        }


        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 1, 5, 4, 3, 2, 1 };

            DataStructAlgo.Algorithms.Sorting.MargeSorter.MargeSort(arr,2,1);

            //MargeSort(arr);

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
