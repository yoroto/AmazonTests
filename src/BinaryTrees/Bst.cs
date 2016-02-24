using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Bst
    {
        public Node<int> Root { get; private set; }

        public void Insert(Node<int> n)
        {
            if (Root == null)
                Root = n;
            else
                Insert(Root, n);
        }

        private void Insert(Node<int> current, Node<int> n)
        {
            if (n.Value <= current.Value)
            {
                if (current.Left == null)
                    current.Left = n;
                else
                    Insert(current.Left, n);
            }
            else
            {
                if (current.Right == null)
                    current.Right = n;
                else
                    Insert(current.Right, n);
            }
        }

        public void Delete(Node<int> n)
        {
            if (n.Equals(Root))
                DeleteRoot();
            else
                FindParentAndDelete(Root, n);
        }

        public void DeleteRoot()
        {
            Node<int> newNode = null;

            if (Root.Left != null)
            {
                newNode = FindNewNodeInLeft(Root.Left);
                newNode.Right = Root.Right;
                Root.Left = null;
                Root.Right = null;
            }
            else if (Root.Right != null)
            {
                newNode = FindNewNodeInRight(Root.Right);
                Root.Right = null;
            }

            Root = newNode;
        }

        private void FindParentAndDelete(Node<int> root, Node<int> n)
        {
            if (n.Value < root.Value)
            {
                if (root.Left.Equals(n))
                {
                    root.Left = DeleteThis(root.Left);
                    return;
                }
                FindParentAndDelete(root.Left, n);
            }
            else
            {
                if (root.Right.Equals(n))
                {
                    root.Right = DeleteThis(root.Right);
                    return;
                }
                FindParentAndDelete(root.Right, n);
            }
        }

        private Node<int> DeleteThis(Node<int> n)
        {
            Node<int> newNode = null;

            if (n.Left != null)
            {
                newNode = FindNewNodeInLeft(n.Left);
                newNode.Right = n.Right;
                n.Left = null;
                n.Right = null;
            }
            else if (n.Right != null)
            {
                newNode = FindNewNodeInRight(n.Right);
                n.Right = null;
            }

            return newNode;
        }

        private Node<int> FindNewNodeInRight(Node<int> right)
        {
            if (right.Left == null)
                return right;
            var newNode = FindMinInLeft(right.Left, right);
            newNode.Right = right;
            return newNode;
        }

        private Node<int> FindMinInLeft(Node<int> left, Node<int> parent)
        {
            if(left.Left != null)
                return FindMinInLeft(left.Left, left);

            parent.Left = left.Right != null ? FindNewNodeInRight(left.Right) : null;

            return left;
        }

        private Node<int> FindNewNodeInLeft(Node<int> left)
        {
            if (left.Right == null)
                return left;
            var newNode = FindMaxInRight(left.Right, left);
            newNode.Left = left;
            return newNode;
        }

        private Node<int> FindMaxInRight(Node<int> right, Node<int> parent)
        {
            if(right.Right != null)
                return FindMaxInRight(right.Right, right);

            parent.Right = right.Left != null ? FindNewNodeInLeft(right.Left) : null;

            return right;
        }
    }
}
