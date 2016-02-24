using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinaryTrees
{
    [TestFixture]
    public class CreateBalancedTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public Node<int> CreateTest(int[] a)
            => Create(a);

        public IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(new int[0]).Returns(null).SetName("Empty");
                yield return new TestCaseData(new[] { 1 }).Returns(new Node<int>(1, null, null)).SetName("One");
                yield return new TestCaseData(new[] { 1, 2 })
                    .Returns(new Node<int>(2, new Node<int>(1, null, null), null))
                    .SetName("Two");
                yield return new TestCaseData(new[] { 1, 2, 3 })
                    .Returns(new Node<int>(2, new Node<int>(1, null, null), new Node<int>(3, null, null)))
                    .SetName("Three");
                yield return new TestCaseData(new[] { 1, 2, 3, 4 })
                    .Returns(new Node<int>(3, new Node<int>(2, new Node<int>(1, null, null), null), new Node<int>(4, null, null)))
                    .SetName("Four");
                yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6, 7 })
                    .Returns(new Node<int>(4, 
                        new Node<int>(2, new Node<int>(1, null, null), new Node<int>(3, null, null)),
                        new Node<int>(6, new Node<int>(5, null, null), new Node<int>(7, null, null))))
                    .SetName("Seven");
            }
        } 

        public static Node<int> Create(int[] a)
        {
            if (a.Length == 0)
                return null;
            return Create(a, 0, a.Length);
        }

        public static Node<int> Create(int[] a, int s, int l)
        {
            if (s >= a.Length || l == 0)
                return null;
            return new Node<int>(
                a[s + l/2],
                Create(a, s, l/2),
                Create(a, s + l/2 + 1, (l-1)/2));
        } 
    }
}
