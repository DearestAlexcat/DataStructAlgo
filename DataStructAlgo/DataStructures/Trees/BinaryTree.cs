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

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(value, _root);
            }
           
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

            Count++;
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
        public  BinaryTreeNode<T> Search(T value)
        {
            return Search(value, _root);
        }

        #endregion

        #region Iteration Search

        public BinaryTreeNode<T> Search(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;

            if (_root == null)
                return null;

            BinaryTreeNode<T> current = _root;
            int result;

            while (current != null)
            {
                result = current.CompareTo(value);

                if(result > 0)
                {
                    parent = current;
                    current = _root.Left;
                }
                else if(result < 0)
                {
                    parent = current;
                    current = _root.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        #endregion
    
        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;
            BinaryTreeNode<T> current = Search(value, out parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            // Удаляемый узел не имеет правого потомка
            if (current.Right == null)
            {
                if (parent == null)
                {
                    _root = _root.Left;
                }
                else
                {
                    if(current.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = current.Left;
                    }
                    else
                    {
                        parent.Left = current.Left;
                    }
                }
            }

            // Удаляемый узел имеет правого потомка, у которого нет левого потомка
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _root = _root.Right;
                }
                else
                {
                    if(current.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = current.Right;
                    }
                    else
                    {
                        parent.Left = current.Right;
                    }                
                }
            }

            // Удаляемый узел имеет правого потомка, у которого есть левый потомок
            else
            {
                BinaryTreeNode<T> parentLeftmost = null;
                BinaryTreeNode<T> leftmost = current.Right;
                
                // Поиск крайнего левого узла в правой ветке
                while (leftmost.Left != null)
                {
                    parentLeftmost = leftmost;
                    leftmost = leftmost.Left;
                }

                parentLeftmost.Left = leftmost.Right;     // Случай, когда у крайнего левого узла есть правый потомок
                leftmost.Right = current.Right;
                leftmost.Left  = current.Left;

                if (parent == null)
                {
                    _root = leftmost;                   
                }
                else
                {
                    if (current.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = leftmost;
                    }
                    else
                    {
                        parent.Left = leftmost;
                    }
                }

            }

            return true;
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        #region Recursion order 

        private void PreOrder(BinaryTreeNode<T> root, List<T> list)
        {
            list.Add(root.Value);

            if (root.Left != null)
            {
                PreOrder(root.Left, list);
            }

            if (root.Right != null)
            {
                PreOrder(root.Right, list);
            }
        }

        public T[] PreOrder()
        {
            List<T> result = new List<T>();
            PreOrder(_root, result);
            return result.ToArray();
        }

        private void PostOrder(Stack<T> stack, BinaryTreeNode<T> root)
        {
            stack.Push(root.Value);

            if (root.Right != null)
            {
                PostOrder(stack, root.Right);
            }

            if (root.Left != null)
            {
                PostOrder(stack, root.Left);
            }
        }

        public T[] PostOrder()
        {
            Stack<T> stack = new Stack<T>();
            PostOrder(stack, _root);
            return stack.ToArray();
        }

        private void InOrder(Queue<T> queue, BinaryTreeNode<T> root)
        {
            if (root.Left != null)
            {
                InOrder(queue, root.Left);
                queue.Enqueue(root.Value);    //adds parent
            }
            else
            {
                queue.Enqueue(root.Value); //adds left or right
            }

            if (root.Right != null)
            {
                InOrder(queue, root.Right);
            }
        }

        public T[] InOrder()
        {
            Queue<T> queue = new Queue<T>();

            InOrder(queue, _root);

            return queue.ToArray();
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
