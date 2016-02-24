using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Graph
{
    [TestFixture]
    public class SearchRoute
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool SearchTest(Node<int> n1, Node<int> n2)
            => Search(n1, n2);
        
        public IEnumerable TestData
        {
            get
            {
                var a = new Node<int>(1);
                var b = new Node<int>(2);
                var c = new Node<int>(3);
                var d = new Node<int>(4);

                a.Children.Add(b);

                b.Children.Add(d);
                b.Children.Add(a);

                c.Children.Add(a);
                c.Children.Add(d);

                d.Children.Add(b);

                yield return new TestCaseData(a, a).Returns(true).SetName("AtoA");
                yield return new TestCaseData(a, d).Returns(true).SetName("AtoB");
                yield return new TestCaseData(d, a).Returns(true).SetName("BtoA");
                yield return new TestCaseData(b, c).Returns(false).SetName("BtoC");
                yield return new TestCaseData(c, b).Returns(true).SetName("CtoB");
                yield return new TestCaseData(a, c).Returns(false).SetName("AtoC");
                yield return new TestCaseData(c, a).Returns(true).SetName("CtoA");
            }
        }

        public bool Search<T>(Node<T> n1, Node<T> n2)
        {
            if (n1 == n2)
                return true;
            var q = new Queue<Node<T>>();
            n1.Status = 1;
            n1.Children.ForEach(n => q.Enqueue(n));

            while (q.Count != 0)
            {
                var t = q.Dequeue();
                t.Status = 1;
                if (t == n2)
                    return true;
                t.Children.Where(n => n.Status == 0).ToList().ForEach(n => q.Enqueue(n));
            }
            return false;
        } 
    }
}
