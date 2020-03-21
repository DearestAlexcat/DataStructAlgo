using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructAlgo.DataStructures.Trees
{
    class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        BinaryTreeNode<T> _root = null;
        
        public int Count
        {
            get;
            private set;
        }

        #region Recursion Add

        private void AddTo(T value, BinaryTreeNode<T> root)
        {
            if (root != null)
            {
                if(root.CompareTo(value) > 0)
                {
                    if(root.Left == null)
                    {
                        root.Left = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddTo(value, root.Left);
                    }
                }
                else
                {
                    if (root.Right == null)
                    {
                        root.Right = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddTo(value, root.Right);
                    }
                }
            }
            else
            {
                _root = new BinaryTreeNode<T>(value);
            }
        }

        public void Add(T value)
        {
            AddTo(value, _root);
            Count++;
        }

        #endregion

        #region Iteration Add

        public void IterAdd(T value)
        {
            BinaryTreeNode<T> current = _root;

            if (_root != null)
            {
                while (true)
                {
                    if (current.CompareTo(value) > 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new BinaryTreeNode<T>(value);
                            break;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new BinaryTreeNode<T>(value);
                            break;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }
            }
            else
            {
                _root = new BinaryTreeNode<T>(value);
            }

        }

        #endregion

        public void Remove()
        {

        }

        #region Recursion search

        private BinaryTreeNode<T> Search(T value, BinaryTreeNode<T> root)
        {
            BinaryTreeNode<T> node = null;

            if (root != null)
            {
                int result = value.CompareTo(root.Value);

                if (result == 0)
                {
                    node = root;
                }
                else if (result < 0) // left
                {
                    node = Search(value, root.Left);
                }
                else
                {
                    node = Search(value, root.Right);
                }
            }

            return node;
        }
        public BinaryTreeNode<T> RecursionSearch(T value)
        {
            return Search(value, _root);
        }

        #endregion

        #region Iteration Search

        public BinaryTreeNode<T> IterSearch(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> currentRoot = _root;
            parent = null;

            int result;

            while (true)
            {
                result = currentRoot.CompareTo(value);

                if(result > 0)
                {
                    parent = currentRoot;
                    currentRoot = _root.Left;
                }
                else if(result < 0)
                {
                    parent = currentRoot;
                    currentRoot = _root.Right;
                }
                else
                {
                    break;
                }
            }

            return currentRoot;
        }

        #endregion
    
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
