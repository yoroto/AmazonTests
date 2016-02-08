using System;

namespace ClassLibrary4
{
    public class OneKCoordinates2
    {
        private Node<Tuple<int, int, int, double>> _head;

        private readonly int _max;

        public int Count { get; private set; }

        public OneKCoordinates2(int max)
        {
            _max = max;
            Count = 0;
        }

        public void TryAdd(int x, int y, int z)
        {
            var l = Math.Sqrt(x * x + y * y + z * z);

            if (_head == null)
            {
                _head = new Node<Tuple<int, int, int, double>>(new Tuple<int, int, int, double>(x, y, z, l));
                Count = 1;
                return;
            }
            
            if (Count < _max || l < _head.Value.Item4)
            {
                var node = new Node<Tuple<int, int, int, double>>(new Tuple<int, int, int, double>(x, y, z, l));

                if (l >= _head.Value.Item4)
                {
                    node.Next = _head;
                    _head = node;
                    Count++;
                    return;
                }

                var c = _head;
                var added = false;
                while(c.Next != null)
                {
                    if(l >= c.Next.Value.Item4)
                    {
                        node.Next = c.Next;
                        c.Next = node;
                        Count++;
                        added = true;
                        break;
                    }

                    c = c.Next;
                }

                if(!added)
                {
                    c.Next = node;
                    Count++;
                }

                if (Count > _max)
                {
                    _head = _head.Next;
                    Count--;
                }
            }
        }
    }
}
