using System;
using System.Collections;
using System.Linq;

namespace DataStructAlgo.DataStructures.HashTable
{
    class HashTableArray<TKey, TValue> : IEnumerable
    {
        HashTableArrayNode<TKey, TValue>[] _array = null;

        public int Capacity
        {
            get => _array.Length;
        }

        public HashTableArray(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException($"{nameof(capacity)} must be greater than zero");
            }

            _array = new HashTableArrayNode<TKey, TValue>[capacity];
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);

            HashTableArrayNode<TKey, TValue> nodes = _array[index];

            if (nodes == null)
            {
                nodes = new HashTableArrayNode<TKey, TValue>();
                _array[index] = nodes;
            }

            nodes.Add(key, value);
        }

        public void Update(TKey key, TValue value)
        {
            HashTableArrayNode<TKey, TValue> node = _array[GetIndex(key)];

            if (node == null)
            {
                throw new ArgumentException("There is no such key in the table", nameof(key));
            }

            node.Update(key, value);
        }

        public bool Remove(TKey key)
        {
            HashTableArrayNode<TKey, TValue> node = _array[GetIndex(key)];

            if (node != null)
            {
                return node.Remove(key);
            }

            return false;
        }

        public void Clear(TKey key)
        {
            HashTableArrayNode<TKey, TValue> node = _array[GetIndex(key)];

            if (node == null)
            {
                throw new ArgumentException("There is no such key in the table", nameof(key));
            }

            node.Clear();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            HashTableArrayNode<TKey, TValue> node = _array[GetIndex(key)];

            if (node != null)
            {
                return node.TryGetValue(key, out value);
            }

            value = default(TValue);
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (HashTableArrayNode<TKey, TValue> node in _array.Where(n => n != null))
            {
                foreach (HashTableNodePair<TKey, TValue> pair in node)
                {
                    yield return pair;
                }
            }
        }
    }
}
