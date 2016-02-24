using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Avl
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
                {
                    current.Left = n;
                    current.Height = Math.Max(1, current.Height);
                }
                else
                {
                    Insert(current.Left, n);
                    UpdateHeightAndBalance(current);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = n;
                    current.Height = Math.Max(1, current.Height);
                }
                else
                {
                    Insert(current.Right, n);
                    UpdateHeightAndBalance(current);
                }
            }
        }

        public void UpdateHeightAndBalance(Node<int> current)
        {
            var diff = current.HeightDiff();
            if (diff == 2)
            {
                if (current.Left.HeightDiff() == 1)
                {
                    Rotate_LL(current);
                }
                else
                {
                    Rotate_LR(current);
                    Rotate_LL(current);
                }
            }
            else if(diff == -2)
            {
                if (current.Right.HeightDiff() == -1)
                {
                    Rotate_RR(current);
                }
                else
                {
                    Rotate_RL(current);
                    Rotate_RR(current);
                }
            }

            current.Left.UpdateHeight();
            current.Right.UpdateHeight();
            current.UpdateHeight();
        }

        public void Rotate_LR(Node<int> current)
        {
            var t = current.Left;
            current.Left = t.Right;
            t.Right = current.Left.Left;
            current.Left.Left = t;
        }

        public void Rotate_LL(Node<int> current)
        {
            var t = new Node<int>(current);
            t.Left = current.Left.Right;
            current.Left.Right = t;
            current.Replace(current.Left);
        }

        public void Rotate_RL(Node<int> current)
        {
            var t = current.Right;
            current.Right = t.Left;
            t.Left = current.Right.Right;
            current.Right.Right = t;
        }

        public void Rotate_RR(Node<int> current)
        {
            var t = new Node<int>(current);
            t.Right = current.Right.Left;
            current.Right.Left = t;
            current.Replace(current.Right);
        }

        public void Delete(Node<int> n)
        {
            FindAndDelete(Root, n);
        }

        private void FindAndDelete(Node<int> root, Node<int> n)
        {
            if(root.Equals(n))
            {
                root.Replace(DeleteThis(root));
            }
            else if (n.Value < root.Value)
            {
                FindAndDelete(root.Left, n);
            }
            else
            {
                FindAndDelete(root.Right, n);
            }
        }

        private Node<int> DeleteThis(Node<int> n)
        {
            Node<int> newNode = null;

            if (n.Left != null)
            {
                newNode = FindNewNodeInLeft(n.Left);
                newNode.Right = n.Right;
            }
            else if (n.Right != null)
            {
                newNode = FindNewNodeInRight(n.Right);
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
