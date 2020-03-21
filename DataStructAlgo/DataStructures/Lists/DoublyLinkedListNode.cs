namespace DataStructAlgo.DataStructures.Lists
{
    class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
            set;
        }

        public DoublyLinkedListNode<T> Next
        {
            get;
            set;
        }

        public DoublyLinkedListNode<T> Previous
        {
            get;
            set;
        }
    }
}
