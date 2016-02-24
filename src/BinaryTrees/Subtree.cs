using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Subtree
    {
        public static bool Find<T>(Node<T> t1, Node<T> t2)
        {
            if (t1 == null)
                return false;
            var here = false;
            if (t1.Value.Equals(t2.Value))
                here = Compare(t1, t2);
            return here || Find<T>(t1.Left, t2) || Find<T>(t1.Right, t2);
        }

        private static bool Compare<T>(Node<T> t1, Node<T> t2)
        {
            return t1 == null
                   || t1.Value.Equals(t2.Value)
                   && Compare(t1.Left, t2.Left)
                   && Compare(t1.Right, t2.Right);
        }
    }
}
