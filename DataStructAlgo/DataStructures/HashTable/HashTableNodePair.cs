namespace DataStructAlgo.DataStructures.HashTable
{
    class HashTableNodePair<TKey, TValue>
    {
        public TKey Key
        {
            get;
            private set;
        }

        public TValue Value
        {
            get;
            set;
        }

        public HashTableNodePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
