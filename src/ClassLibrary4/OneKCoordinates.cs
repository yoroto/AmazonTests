using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class OneKCoordinates
    {
        private readonly int _max;
        public readonly LinkedList<Tuple<int, int, int, double>> Items;

        public OneKCoordinates(int max)
        {
            Items = new LinkedList<Tuple<int, int, int, double>>();
            _max = max;
        }

        public void TryAdd(int x, int y, int z)
        {
            Insert(x, y, z);
            if (Items.Count > _max)
                Items.RemoveFirst();
        }

        internal void Insert(int x, int y, int z)
        {
            var l = Math.Sqrt(x * x + y * y + z * z);

            if (Items.Count == 0)
            {
                Items.AddFirst(new Tuple<int, int, int, double>(x, y, z, l));
                return;
            }

            if (Items.Count < _max || l < Items.First.Value.Item4)
            {
                var c = Items.First;
                while(c != null)
                {
                    if (c.Value.Item4 <= l)
                    {
                        Items.AddBefore(c, new Tuple<int, int, int, double>(x, y, z, l));
                        return;
                    }
                    c = c.Next;
                }
                Items.AddLast(new Tuple<int, int, int, double>(x, y, z, l));
            }
        }
    }
}
