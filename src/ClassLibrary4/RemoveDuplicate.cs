using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class RemoveDuplicate
    {
        public static Node<T> RemoveDuplicate1<T>(Node<T> head)
        {
            var c = head;
            Node<T> p = head;
            var set = new HashSet<T>();
            while (c != null)
            {
                if (set.Contains(c.Value))
                {
                    p.Next = c.Next;
                }
                else
                {
                    set.Add(c.Value);
                }
                p = c;
                c = c.Next;
            }

            return head;
        }

        public static Node<T> RemoveDuplicate2<T>(Node<T> head)
        {
            var c = head;
            while (c != null)
            {
                
                c = c.Next;
            }

            return head;
        }
    }
}
