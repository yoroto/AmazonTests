namespace ClassLibrary4
{
    public class Partition
    {
        public static Node<int> Do(Node<int> head, int n)
        {
            var nh = head;
            var c = head;

            if (c?.Next == null)
                return head;

            while (c?.Next != null)
            {
                if (c.Next.Value < n)
                {
                    var t = c.Next;
                    c.Next = c.Next.Next;
                    t.Next = nh;
                    nh = t;
                }

                c = c.Next;
            }

            return nh;
        } 
    }
}
