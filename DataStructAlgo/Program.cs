using DataStructAlgo.DataStructures.Trees;
using System;

namespace DataStructAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.IterAdd(5);
            binaryTree.IterAdd(3);
            binaryTree.IterAdd(8);

            Console.ReadLine();
        }
    }
}
