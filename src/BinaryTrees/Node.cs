using System;

namespace BinaryTrees
{
    public class Node<T>
    {
        public T Value { get; set; }

        public int Height { get; set; }

        public Node<T> Left { get; set; }
        
        public Node<T> Right { get; set; }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            Height = 0;
        }

        public Node(Node<T> old)
        {
            Value = old.Value;
            Left = old.Left;
            Right = old.Right;
            Height = old.Height;
        }

        public void Replace(Node<T> n)
        {
            Value = n.Value;
            Left = n.Left;
            Right = n.Right;
            Height = n.Height;
        }

        public int HeightDiff()
        {
            if (Left == null && Right == null)
                return 0;
            if (Left == null)
                return -Right.Height;
            if (Right == null)
                return Left.Height;
            return Left.Height - Right.Height;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(Left == null ? 0 : Left.Height + 1, Right == null ? 0 : Right.Height + 1);
        }

        public override bool Equals(object obj)
        {
            var n = obj as Node<T>;
            if (n == null)
                return false;
            return Value.Equals(n.Value)
                   && (Left == null && n.Left == null || Left.Equals(n.Left))
                   && (Right == null && n.Right == null || Right.Equals(n.Right));
        }

        public static bool Equals(Node<T> t1, Node<T> t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;
            return t1.Value.Equals(t2.Value)
                   && Equals(t1.Left, t2.Left)
                   && Equals(t1.Right, t2.Right);
        }
    }
}
