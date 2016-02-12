using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class NthFromTheEndInList<T>
    {
        public static T Get(Node<T> head, int n)
        {
            var c = head;
            Node<T> r = null;
            var count = 0;

            while(c != null)
            {
                count++;
                if (n == count)
                    r = head;
                else if (n < count)
                    r = r.Next;
                c = c.Next;
            }

            if(r == null)
                throw new IndexOutOfRangeException($"Cannot get {n}th ");

            return r.Value;
        }
    }
}
