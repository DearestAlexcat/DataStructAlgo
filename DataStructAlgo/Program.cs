using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStructAlgo.DataStructures.Queues.QueueArray<int> queue = 
                new DataStructures.Queues.QueueArray<int>();


            for (int i = 1; i <= 5; i++)
            {
                queue.EnqueueLast(i);
                queue.EnqueueFirst(i * -1);
            }



            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(queue.DequeueLast());
            }



            Console.ReadLine();

        }
    }
}
