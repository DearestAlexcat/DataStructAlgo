using System;
using System.Collections;
using System.Collections.Generic;
 

namespace DataStructAlgo.DataStructures.Sets
{
    class Set<T> : IEnumerable<T>
    {

        List<T> _items = new List<T>();

        public int Count
        {
            get => _items.Count;
        }

        public Set() { }

        public Set(ICollection<T> collection)
        {
            AddRange(collection);
        }

        public void Add(T value)
        {
            if(_items.Contains(value))
            {
                throw new ArgumentException("The element is contained in the set");
            }

            _items.Add(value);
        }

        public bool Contains(T value)
        {
            return _items.Contains(value);
        }

        public void AddRange(ICollection<T> collection)
        {
            foreach (T item in collection)
            {
                if (!_items.Contains(item)) // Filter
                {
                    _items.Add(item);
                }
            }
        }

        public bool Remove(T value)
        {
            return _items.Remove(value);
        }

        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);

            foreach (T item in other._items)
            {
                result.Remove(item);
            }

            return result;
        }

        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();

            foreach (T item in other._items)
            {
                if(_items.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);

            foreach (T item in other._items)
            {
                if(!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        // Version 1
        public Set<T> SymmetricDifference1(Set<T> other)
        {
            Set<T> union = Union(other);
            Set<T> intersection = Intersection(other);
            return union.Difference(intersection);

            //return Union(other).Difference(Intersection(other));
        }

        // Version 2
        public Set<T> SymmetricDifference2(Set<T> other)
        {
            Set<T> result = new Set<T>(_items);

            foreach (T item in other._items)
            {
                if(!result.Remove(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public bool IsSubSet(Set<T> other)
        {
            Set<T> result = new Set<T>(other._items);

            foreach (var item in _items)
            {
                result.Remove(item);
            }

            return result.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
