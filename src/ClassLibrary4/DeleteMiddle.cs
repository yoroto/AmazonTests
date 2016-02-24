using System.Security.Cryptography;

namespace ClassLibrary4
{
    public class DeleteMiddle
    {
        public static Node<int> Delete(Node<int> head)
        {
            var e = head;
            var m = head;
            var pm = head;

            while (e?.Next?.Next != null)
            {
                e = e.Next.Next;
                pm = m;
                m = m.Next;
            }

            if (e != head)
            {
                var t = pm.Next.Next;
                pm.Next.Next = null;
                pm.Next = t;
            }

            return head;
        }
    }
}
