using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class SumLists
    {
        internal static int GetNumberReverse(Node<int> head)
        {
            var c = head;
            var b = 1;
            var s = 0;
            while(c != null)
            {
                s += c.Value * b;
                b *= 10;
                c = c.Next;
            }
            return s;
        }

        internal static int GetNumber(Node<int> n, out int e)
        {
            if(n.Next == null)
            {
                e = 10;
                return n.Value;
            }
            else
            {
                int oe;
                var b = GetNumber(n.Next, out oe);
                e = oe * 10;
                return b + n.Value * oe;
            }
        }

        public static int SumListReverse(Node<int> l1, Node<int> l2)
            => GetNumberReverse(l1) + GetNumberReverse(l2);

        public static int SumList(Node<int> l1, Node<int> l2)
        {
            int o1, o2;
            return GetNumber(l1, out o1) + GetNumber(l2, out o2);
        }
    }
}
