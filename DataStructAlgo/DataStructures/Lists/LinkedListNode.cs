using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.DataStructures.Lists
{
    class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
            set;
        }

        public LinkedListNode<T> Next
        {
            get;
            set;
        }
    }
}
