using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinaryTrees
{
    [TestFixture]
    public class BinarySearchTree
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public bool BstTest(Node<int> root)
        {
            int max, min;
            return IsBst(root, out max, out min);
        }

        [Test]
        [TestCaseSource(nameof(TestData2))]
        public bool BstLoopTest(Node<int> root)
            => IsBst(root);

        public IEnumerable TestData2 => (from TestCaseData t in TestData select t.SetName(t.TestName + "Loop"));

        public IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(new Node<int>(
                    14,
                    new Node<int>(
                        6,
                        new Node<int>(
                            3, 
                            null,
                            new Node<int>(5, null, null)
                        ),
                        new Node<int>(
                            9,
                            new Node<int>(7, null, null),
                            new Node<int>(11, null, null)
                        )
                    ),
                    new Node<int>(
                        17,
                        new Node<int>(
                            15,
                            null,
                            new Node<int>(16, null, null)
                        ),
                        new Node<int>(21, null, null)
                    )
                    )).Returns(true).SetName("IsBST");
                yield return new TestCaseData(new Node<int>(
                    14,
                    new Node<int>(
                        6,
                        new Node<int>(
                            3,
                            null,
                            new Node<int>(5, null, null)
                        ),
                        new Node<int>(
                            9,
                            new Node<int>(5, null, null),
                            new Node<int>(11, null, null)
                        )
                    ),
                    new Node<int>(
                        17,
                        new Node<int>(
                            15,
                            null,
                            new Node<int>(17, null, null) // <--
                        ),
                        new Node<int>(21, null, null)
                    )
                    )).Returns(false).SetName("IsNotBST1");
                yield return new TestCaseData(new Node<int>(
                    14,
                    new Node<int>(
                        6,
                        new Node<int>(
                            3,
                            null,
                            new Node<int>(5, null, null)
                        ),
                        new Node<int>(
                            9,
                            new Node<int>(7, null, null),
                            new Node<int>(15, null, null) // <--
                        )
                    ),
                    new Node<int>(
                        17,
                        new Node<int>(
                            15,
                            null,
                            new Node<int>(17, null, null)
                        ),
                        new Node<int>(21, null, null)
                    )
                    )).Returns(false).SetName("IsNotBST2");
            }
        } 

        public static bool IsBst(Node<int> root, out int max, out int min)
        {
            int leftmax, rightmin;
            if (root.Left == null)
            {
                min = root.Value;
            }
            else if (!IsBst(root.Left, out leftmax, out min) || leftmax > root.Value)
            {
                max = 0;
                return false;
            }

            if (root.Right == null)
            {
                max = root.Value;
            }
            else if (!IsBst(root.Right, out max, out rightmin) || root.Value > rightmin)
            {
                min = 0;
                return false;
            }

            return true;
        }

        public static bool IsBst(Node<int> root)
        {
            var stack  = new Stack<Node<int>>();
            var c = root;
            var last = Int32.MinValue;

            while (c != null || stack.Count != 0)
            {
                if (c == null)
                {
                    c = stack.Pop();
                    if (c.Value < last)
                        return false;
                    last = c.Value;
                    c = c.Right;
                }
                else
                {
                    stack.Push(c);
                    c = c.Left;
                }
            }

            return true;
        }
    }
}
