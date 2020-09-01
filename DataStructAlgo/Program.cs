using System;
using System.Collections;
using System.Collections.Generic;
using DataStructAlgo.DataStructures.Trees;
using System.Linq;
using System.Threading;
using DataStructAlgo.Algorithms.Breadth_Depth_first;

namespace DataStructAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Map map = new Map(40, 20);
            //map.SetMap(300);     
            //map.FillFor(20, 10);
            //map.FillQueue(20, 10);       
            //map.FillStack(20, 10);

            //map.FillDepth(20, 10);

            BinaryTree<int> three = new BinaryTree<int>();

            three.Add(8);
            three.Add(4);
            three.Add(12);
            three.Add(2);
            three.Add(6);
            three.Add(1);
            three.Add(3);
            three.Add(5);
            three.Add(7);
            three.Add(10);
            three.Add(14);
            three.Add(9);
            three.Add(11);
            three.Add(13);
            three.Add(15);
          
            foreach (var item in three.PreOrder())
            {
                Console.Write(item + " " );
            }
            Console.WriteLine();
            foreach (var item in three.PostOrder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(); 
            foreach (var item in three.InOrder())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();





            Console.ReadKey();
        }
    }
}
