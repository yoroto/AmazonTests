using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinaryTrees
{
    [TestFixture]
    public class FindFirstCommon
    {
        [Test]
        [TestCaseSource(nameof(TestCase))]
        public int FindTest(Node<int> root, Node<int> t1, Node<int> t2)
            => FindCommon(root, t1, t2).Value;

        public static IEnumerable TestCase
        {
            get
            {
//                              12
//                 5                             17
//           3           10              14               21
//       1       4     9    11       13      15       20      23
//        2     6 7     8                      16       19   22
//                                                            24
//                                                           26
//                                                            27
                var root1 = new Node<int>(
                    12,
                    new Node<int>(
                        5,
                        new Node<int>(
                            3,
                            new Node<int>(
                                1,
                                null,
                                new Node<int>(2, null, null)
                            ),
                            new Node<int>(
                                4,
                                new Node<int>(6, null, null),
                                new Node<int>(7, null, null)
                            )
                        ),
                        new Node<int>(
                            10,
                            new Node<int>(
                                9,
                                null,
                                new Node<int>(8, null, null)
                            ),
                            new Node<int>(11, null, null)
                        )
                    ),
                    new Node<int>(
                        17,
                        new Node<int>(
                            14,
                            new Node<int>(13, null, null),
                            new Node<int>(
                                15,
                                null,
                                new Node<int>(16, null, null)
                            )
                        ),
                        new Node<int>(
                            21,
                            new Node<int>(
                                20,
                                null,
                                new Node<int>(19, null, null)
                            ),
                            new Node<int>(
                                23,
                                new Node<int>(
                                    22,
                                    null,
                                    new Node<int>(
                                        24,
                                        new Node<int>(
                                            26,
                                            null,
                                            new Node<int>(27, null, null)
                                        ),
                                        null
                                    )
                                ),
                                null
                            )
                        )
                    )
                );
                yield return new TestCaseData(root1, root1.Left.Left.Right.Left, root1.Left.Left.Right.Right).Returns(4).SetName("Sibling1");
                yield return new TestCaseData(root1, root1.Left.Left.Right.Right, root1.Left.Left.Right.Left).Returns(4).SetName("Sibling2");
                yield return new TestCaseData(root1, root1.Left.Left.Right.Left, root1.Left.Left.Right.Left).Returns(4).SetName("Same");
                yield return new TestCaseData(root1, root1.Left.Right, root1.Left.Right.Left.Right).Returns(5).SetName("Child");
                yield return new TestCaseData(root1, root1.Left.Right.Left.Right, root1.Left.Right).Returns(5).SetName("Parent");
                yield return new TestCaseData(root1, root1.Left.Right.Left.Right, root1.Right.Right.Left).Returns(12).SetName("Root");
            }
        }

        public static Node<T> FindCommon<T>(Node<T> root, Node<T> t1, Node<T> t2)
        {
            Node<T> last = null;
            foreach (var n in FindPath(root, t1))
            {
                if (n.Left == t2 || n.Right == t2
                    || (last == null || n.Left != last) && FindPath(n.Left, t2) != null
                    || (last == null || n.Right != last) && FindPath(n.Right, t2) != null)
                    return n;
                last = n;
            }

            return null;
        }

        public static IList<Node<T>> FindPath<T>(Node<T> root, Node<T> toFind)
        {
            if (root == null)
                return null;
            if (root == toFind)
                return new List<Node<T>>(){};
            var left = FindPath<T>(root.Left, toFind);
            if (left != null)
            {
                left.Add(root);
                return left;
            }
            var right = FindPath<T>(root.Right, toFind);
            if (right != null)
            {
                right.Add(root);
                return right;
            }
            return null;
        }
    }
}
