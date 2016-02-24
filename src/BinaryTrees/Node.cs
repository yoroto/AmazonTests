using System;

namespace BinaryTrees
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }
        
        public Node<T> Right { get; set; }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
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
