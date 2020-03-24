using DataStructAlgo.DataStructures.Trees;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructAlgo
{

    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(8);

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(6);
            tree.Add(5);
            tree.Add(7);

            tree.Add(12);
            tree.Add(10);
            tree.Add(9);
            tree.Add(11);
            tree.Add(14);
            tree.Add(13);
            tree.Add(15);

            tree.PreOrder2();


            Console.ReadKey();
        }
    }
}
