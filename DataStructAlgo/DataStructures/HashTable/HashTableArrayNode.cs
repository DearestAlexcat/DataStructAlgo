using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.HashTable
{
    class HashTableArrayNode<TKey, TValue> : IEnumerable
    {
        LinkedList<HashTableNodePair<TKey, TValue>> _items = null;

        public void Add(TKey key, TValue value)
        {
            if (_items == null)
            {
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
            }
            else
            {
                foreach (HashTableNodePair<TKey, TValue> item in _items)
                {
                    if (item.Key.Equals(key))
                    {
                        throw new ArgumentException("Key already exists", nameof(key));
                    }
                }
            }

            _items.AddLast(new HashTableNodePair<TKey, TValue>(key, value));
        }

        public void Update(TKey key, TValue value)
        {
            bool updated = false;

            if (_items != null)
            {
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = _items.First;

                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        current.Value.Value = value;
                        updated = true;
                        break;
                    }

                    current = current.Next;
                }
            }

            if (!updated)
            {
                throw new InvalidOperationException("Failed to update");
            }
        }

        public void Clear()
        {
            if (_items != null)
            {
                _items.Clear();
            }
        }

        public bool Remove(TKey key)
        {
            if (_items != null)
            {
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = _items.First;

                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        _items.Remove(current);
                        return true;
                    }

                    current = current.Next;
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_items != null)
            {
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = _items.First;

                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        value = current.Value.Value;
                        return true;
                    }

                    current = current.Next;
                }
            }

            value = default(TValue);
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
