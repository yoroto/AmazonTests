namespace ClassLibrary4
{
    public class MergeTwoSortedList
    {
        public static Node<int> Merge(Node<int> l1, Node<int> l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }
            else if (l2 == null || (l1 != null && l1.Value < l2.Value))
            {
                var t = l1;
                t.Next = Merge(l1.Next, l2);
                return t;
            }
            else
            {
                var t = l2;
                t.Next = Merge(l1, l2.Next);
                return t;
            }
        }

        public static Node<int> Merge2(Node<int> l1, Node<int> l2)
        {
            var t1 = l1;
            var t2 = l2;
            Node<int> c = null;
            Node<int> head = null;

            while (t1 != null || t2 != null)
            {
                if (t2 == null || (t1 != null && t1.Value < t2.Value))
                {
                    if (c == null)
                    {
                        c = t1;
                        head = c;
                    }
                    else
                    {
                        c.Next = t1;
                        c = c.Next;
                    }
                    t1 = t1.Next;
                }
                else
                {
                    if (c == null)
                    {
                        c = t2;
                        head = c;
                    }
                    else
                    {
                        c.Next = t2;
                        c = c.Next;
                    }
                    t2 = t2.Next;
                }
            }

            return head;
        } 
    }
}
