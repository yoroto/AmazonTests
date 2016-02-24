using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinaryTrees
{
    [TestFixture]
    public class Depth
    {
        [Test]
        [TestCaseSource(nameof(DepthTestData))]
        public int DepthTest(Node<int> root)
            => GetDepth(root);

        public IEnumerable DepthTestData
        {
            get
            {
                yield return new TestCaseData(new Node<int>(1, null, null)).Returns(1).SetName("One");
                yield return new TestCaseData(new Node<int>(2, new Node<int>(1, null, null), null)).Returns(2).SetName("Two");
                yield return new TestCaseData(new Node<int>(2, new Node<int>(1, null, null), new Node<int>(3, null, null))).Returns(2).SetName("TwoComplete");
                yield return new TestCaseData(new Node<int>(2, new Node<int>(1, null, null), new Node<int>(3, new Node<int>(4, null, new Node<int>(5, null, null)), null))).Returns(4).SetName("Four");
            }
        }

        public static int GetDepth<T>(Node<T> root)
        {
            if (root == null)
                return 0;
            return Math.Max(GetDepth(root.Left), GetDepth<T>(root.Right)) + 1;
        }

        public static bool IsBalanced<T>(Node<T> root, out int max)
        {
            if (root == null)
            {
                max = 0;
                return true;
            }
            int leftmax, rightmax;
            var left = IsBalanced(root.Left, out leftmax);
            if (!left)
            {
                max = leftmax;
                return false;
            }
            var right = IsBalanced(root.Right, out rightmax);
            max = leftmax > rightmax ? leftmax : rightmax;
            return right && Math.Abs(rightmax - leftmax) <= 1;
        }
    }
}
