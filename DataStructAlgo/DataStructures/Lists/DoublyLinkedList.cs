using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.DataStructures.Lists
{
    class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
            set;
        }

        public DoublyLinkedListNode<T> Next
        {
            get;
            set;
        }

        public DoublyLinkedListNode<T> Previous
        {
            get;
            set;
        }
    }
}
