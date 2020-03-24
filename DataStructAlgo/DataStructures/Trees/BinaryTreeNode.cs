using System;

namespace DataStructAlgo.DataStructures.Trees
{
    class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
            private set;
        }

        public BinaryTreeNode<T> Left
        {
            get;
            set;
        }

        public BinaryTreeNode<T> Right
        {
            get;
            set;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public int CompareNode(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
