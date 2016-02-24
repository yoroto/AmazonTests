using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class SortedStack
    {
        public static Stack<int> Sort(Stack<int> s)
        {
            var r = new Stack<int>();

            while (s.Count != 0)
            {
                var t = s.Pop();
                while (r.Count != 0 && r.Peek() > t)
                    s.Push(r.Pop());
                r.Push(t);
            }
            return r;
        } 
    }
}
