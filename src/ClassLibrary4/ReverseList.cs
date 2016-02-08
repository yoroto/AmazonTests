using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class ReverseList<T>
    {
        public static Node<T> Reverse(Node<T> head)
        {
            if (head == null)
                return null;

            Node<T> r = null;
            var c = head;
            while(c != null)
            {
                var t = c;
                c = c.Next;

                t.Next = r;
                r = t;
            }

            return r;
        }
    }
}
