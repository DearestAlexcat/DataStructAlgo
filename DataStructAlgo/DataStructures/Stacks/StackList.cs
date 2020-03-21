using System;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.Staks
{
    class Stack<T>
    {
        LinkedList<T> _items = new LinkedList<T>();
        
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Push(T value)
        {
            _items.AddLast(value);
        }

        public T Pop()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T result = _items.Last.Value;

            _items.RemoveLast();

            return result;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items.Last.Value;
        }

    }
}
