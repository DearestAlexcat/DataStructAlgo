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
            Map map = new Map(40, 20);

            map.SetMap(300);     
            //map.FillFor(20, 10);
            //map.FillQueue(20, 10);       
            //map.FillStack(20, 10);

            map.FillDepth(20, 10);
            Console.ReadKey();
        }
    }
}
