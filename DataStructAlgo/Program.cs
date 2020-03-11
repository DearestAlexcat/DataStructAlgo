using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo
{
    class Program
    {

        static void Display(DataStructAlgo.DataStructures.Sets.Set<int> set)
        {
            Console.WriteLine();
            foreach (int item in set)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            int[] set11 = new int[4] { 1, 2, 3, 4 };
            int[] set22 = new int[2] { 3, 4 };

            DataStructAlgo.DataStructures.Sets.Set<int> set1 = new DataStructures.Sets.Set<int>(set11);
            DataStructAlgo.DataStructures.Sets.Set<int> set2 = new DataStructures.Sets.Set<int>(set22);

            DataStructAlgo.DataStructures.Sets.Set<int> set3 = set1.Difference(set2);
            Display(set3);

            set3 = set1.Intersection(set2);
            Display(set3);

            set3 = set1.Difference(set2);
            Display(set3);

            set3 = set1.Union(set2);
            Display(set3);

            set3 = set1.SymmetricDifference1(set2);
            Display(set3);

            set3 = set1.SymmetricDifference2(set2);
            Display(set3);


            Console.WriteLine(set1.IsSubSet(set2) + " ");

            Console.ReadLine();
        }
    }
}
