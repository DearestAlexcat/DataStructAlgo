using System.Collections;

namespace DataStructAlgo.DataStructures.HashTable
{
    class HashTable<TKey, TValue> : IEnumerable
    {
        int _count = 0;
        int _maxInCurrentSize;

        float _fillFactor = 0.75f;

        HashTableArray<TKey, TValue> hashTable;

        public HashTable() : this(1000) { }

        public HashTable(int capacity)
        {
            hashTable = new HashTableArray<TKey, TValue>(capacity);
            _maxInCurrentSize = (int)(capacity * _fillFactor) + 1;
        }

        public void Add(TKey key, TValue value)
        {
            if (_count > _maxInCurrentSize)
            {
                HashTableArray<TKey, TValue> newHashTable = new HashTableArray<TKey, TValue>(hashTable.Capacity << 1);

                foreach (HashTableNodePair<TKey, TValue> item in hashTable)
                {
                    newHashTable.Add(item.Key, item.Value);
                }

                hashTable = newHashTable;
                _maxInCurrentSize = (int)(hashTable.Capacity * _fillFactor) + 1;
            }

            hashTable.Add(key, value);
            _count++;
        }

        public void Update(TKey key, TValue value)
        {
            hashTable.Update(key, value);
        }

        public bool Remove(TKey key)
        {
            return hashTable.Remove(key);
        }

        public void Clear(TKey key)
        {
            hashTable.Clear(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return hashTable.TryGetValue(key, out value);
        }

        public IEnumerator GetEnumerator()
        {
            return hashTable.GetEnumerator();
        }
    }
}
