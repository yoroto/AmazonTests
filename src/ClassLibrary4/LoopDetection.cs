using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class LoopDetection
    {
        public static bool HasLoop<T>(Node<T> root)
        {
            var fast = root;
            var slow = root;
            while (fast.Next?.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                    return true;
            }

            return false;
        }

        public static Node<T> FindStart<T>(Node<T> root)
        {
            var fast = root;
            var slow = root;
            while (fast.Next?.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow)
                {
                    fast = root;
                    while (fast != slow)
                    {
                        fast = fast.Next;
                        slow = slow.Next;
                    }
                    return fast;
                }
            }
            return null;
        }

        public static int GetCircleLength<T>(Node<T> root)
        {
            var c = root;
            var count = 0;
            while (c.Next != root)
            {
                count++;
                c = c.Next;
            }
            return count;
        }
    }
}
