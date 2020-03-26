using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.Lists
{
    class LinkedList<T> : IEnumerable<T>
    {
        LinkedListNode<T> _head;
        LinkedListNode<T> _tail;

        public int Count
        {
            get;
            private set;
        }

        public void Add(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
 
            }

            _tail = node;
            Count++;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> current = _head;
            LinkedListNode<T> prevoius = null;

            while (current != null)
            {
                if(current.Value.Equals(value))
                {
                    if (prevoius == null)
                    {
                        _head = _head.Next;

                        if(_head == null)
                        {
                            _tail = null;
                        }
                    }
                    else
                    {
                        prevoius.Next = current.Next;

                        if(prevoius.Next == null)
                        {
                            _tail = prevoius;
                        }                      
                    }

                    Count--;
                    return true;
                }

                prevoius = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
            
        public void CopyTo(T[] array, int index)
        {
            LinkedListNode<T> current = _head;

            while(current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }
    }
}
