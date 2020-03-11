using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.DataStructures.Queues
{
    class DequeLinkedList<T>
    {

        LinkedList<T> _items = new LinkedList<T>();

        public int Count
        {
            get => _items.Count;
        }

        public void EnqueueFirst(T value)
        {
            _items.AddFirst(value);
        }

        public void EnqueueLast(T value)
        {
            _items.AddFirst(value);
        }

        public T EnqueueFirst()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T result = _items.First.Value;

            _items.RemoveFirst();

            return result;
        }

        public T EnqueueLast()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T result = _items.Last.Value;

            _items.RemoveLast();

            return result;
        }

        public T PeekFirst()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return _items.First.Value;
        }

        public T PeekLast()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return _items.Last.Value;
        }

    }
}
