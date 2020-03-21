using System.Collections;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.Lists
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyLinkedListNode<T> _head = null;

        DoublyLinkedListNode<T> _tail = null;

        public int Count
        {
            get;
            private set;
        }

        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value);

            if (_head == null)
            {
                _tail = node;
            }
            else
            {
                _head.Previous = node;
                node.Next = _head;
            }

            _head = node;
            Count++;
        }

        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value);

            if (_tail == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                return;

            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }
            else
            {
                _head.Previous = null;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                _tail = _tail.Previous;

                if (_tail == null)
                {
                    _head = null;
                }
                else
                {
                    _tail.Next = null;
                }

                Count--;
            }
        }

        public bool Remove(T value)
        {
            DoublyLinkedListNode<T> current = _head;
            DoublyLinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else // Removing from the middle or from the end
                    {

                        previous.Next = current.Next;

                        if (previous.Next == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = _head;

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

        public void Clear()
        {
            _head = _tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int index)
        {
            DoublyLinkedListNode<T> current = _head;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        public bool Contains(T value)
        {
            DoublyLinkedListNode<T> current = _head;

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
    }
}
