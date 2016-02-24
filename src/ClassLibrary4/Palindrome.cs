using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class Palindrome
    {
        public static bool GetReverse(Node<int> head)
        {
            var r = ReverseList<int>.Reverse(head);
            var c = head;
            while(c != null && r != null)
            {
                if (c.Value != r.Value)
                    return false;
                c = c.Next;
                r = r.Next;
            }

            return true;
        }
    }
}
