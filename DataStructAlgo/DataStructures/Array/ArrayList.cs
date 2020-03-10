using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructAlgo.DataStructures.Array
{
    class ArrayList<T> : IEnumerable<T>
    {

        T[] _items = null;

        public int Count
        {
            get;
            internal set;
        }

        public ArrayList() : this(0) { }

        public ArrayList(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentException();
            }

            _items = new T[capacity];
        }

        public ArrayList(ICollection<T> collection)
        {
            _items = new T[collection.Count];

            int index = 0;

            foreach (T item in collection)
            {
                _items[index++] = item;
                Count++;
            }
        }

        private void GrowArray()
        {
            int newLength = (_items.Length == 0) ? 4 : _items.Length << 1;
            T[] newArray = new T[newLength];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }

        public void Add(T value)
        {
            if(Count == _items.Length)
            {
                GrowArray();
            }

            _items[Count++] = value;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            int shiftIndex = index + 1;

            if(shiftIndex < Count)
            {
                System.Array.Copy(_items, shiftIndex, _items, index, Count - shiftIndex);
            }

            Count--;
        }

        public bool Remove(T value)
        {

            for (int i = 0; i < Count; i++)
            {
                if(_items[i].Equals(value))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T value, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
           
            if(Count == _items.Length)
            {
                GrowArray();
            }

            System.Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = value;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
