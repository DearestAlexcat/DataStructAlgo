using System;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.Queues
{
    class Queue<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Enqueue(T value)
        {
            _items.AddLast(value);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T result = _items.First.Value;

            _items.RemoveFirst();

            return result;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items.First.Value;
        }
    }
}
