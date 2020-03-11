using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.DataStructures.Queues
{
    class Deque<T>
    {
        T[] _array = new T[0];

        int _head;
        int _tail;

        public int Count
        {
            get;
            private set;
        }

        public Deque() : this(0) { }

        public Deque(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentException("Capacity must be positive");
            }

            _array = new T[capacity];
        }

        private void GrowArray()
        {
            int newLength = (_array.Length == 0) ? 4 : _array.Length << 1;

            T[] newArray = new T[newLength];

            if(Count > 0)
            {
                int index = 0;
                int i;

                if(_tail < _head)
                {
                    for (i = _head; i < _array.Length; i++)
                    {
                        newArray[index++] = _array[i];
                    }

                    for (i = 0; i <= _tail; i++)
                    {
                        newArray[index++] = _array[i];
                    }
                }
                else
                {
                    for (i = _head; i < _tail; i++)
                    {
                        newArray[index++] = _array[i];
                    }
                }

                _head = 0;
                _tail = index - 1;
            }
            else
            {
                _head = 0;
                _tail = -1;
            }

            _array = newArray;
        }

        public void EnqueueFirst(T value)
        {
            if(Count == _array.Length)
            {
                GrowArray();
            }

            if(_head == 0)
            {
                _head = _array.Length - 1;
            }
            else
            {
                _head--;
            }

            _array[_head] = value;

            Count++;
        }

        public void EnqueueLast(T value)
        {
            if (Count == _array.Length)
            {
                GrowArray();
            }

            if (_tail == _array.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _array[_tail] = value;

            Count++;
        }

        public T DequeueFirst()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            if(_head == _array.Length)
            {
                _head = 0;
            }

            Count--;

            return _array[_head++];
        }

        public T DequeueLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            if (_tail < 0)
            {
                _tail = _array.Length - 1;
            }

            Count--;

            return _array[_tail--];
        }

        public T PeekFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return _array[_head];
        }

        public T PeekLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            return _array[_tail];
        }      
    }
}
