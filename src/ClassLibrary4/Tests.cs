using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ClassLibrary4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FizzBuzzTest()
        {
            FizzBuzz.Boom();
        }

        [Test]
        [TestCase(new[] { "James", "Tony", "Jack" }, new[] { "Letu", "James", "Chet", "Paul" }, Result = new[] { "James" })]
        [TestCase(new[] { "James", "Tony", "Jack" }, new[] { "Letu", "Chet", "Paul" }, Result = new string[] { })]
        public IEnumerable<string> CommonNamesTest(string[] a, string[] b)
            => CommonNames.Get(a, b);
        
        [Test]
        public void OneKCoordinatesTest()
        {
            var items = new OneKCoordinates(4);
            Assert.That(items.Items.Count, Is.EqualTo(0));
            items.TryAdd(2, 3, 4);
            Assert.That(items.Items.Count, Is.EqualTo(1));
            items.TryAdd(2, 1, 4);
            Assert.That(items.Items.Count, Is.EqualTo(2));
            items.TryAdd(3, 3, 4);
            Assert.That(items.Items.Count, Is.EqualTo(3));
            items.TryAdd(4, 3, 1);
            Assert.That(items.Items.Count, Is.EqualTo(4));
            items.TryAdd(4, 3, 2);
            Assert.That(items.Items.Count, Is.EqualTo(4));
            Assert.That(items.Items.Where(i => i.Item3 == 2).Count, Is.EqualTo(1));
            items.TryAdd(1, 1, 2);
            Assert.That(items.Items.Count, Is.EqualTo(4));
            Assert.That(items.Items.Where(i => i.Item1 == 3).Count, Is.EqualTo(0));
        }

        [Test]
        public void OneKCoordinates2Test()
        {
            var items = new OneKCoordinates2(4);
            Assert.That(items.Count, Is.EqualTo(0));
            items.TryAdd(2, 3, 4);
            Assert.That(items.Count, Is.EqualTo(1));
            items.TryAdd(2, 1, 4);
            Assert.That(items.Count, Is.EqualTo(2));
            items.TryAdd(3, 3, 4);
            Assert.That(items.Count, Is.EqualTo(3));
            items.TryAdd(4, 3, 1);
            Assert.That(items.Count, Is.EqualTo(4));
            items.TryAdd(4, 3, 2);
            Assert.That(items.Count, Is.EqualTo(4));
            items.TryAdd(1, 1, 2);
            Assert.That(items.Count, Is.EqualTo(4));
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4 }, Result = new[] { 4, 3, 2, 1 }, TestName = "Test1")]
        [TestCase(new int[] {}, Result = new int[] {}, TestName = "Empty")]
        public int[] ReverseLinkedListTest(int[] input)
            => GetArrayFromList<int>(ReverseList<int>.Reverse(CreateList(input)));
        

        [Test]
        [TestCase(new[] { 4, 8, 1, 9, 14, 7 }, 3, Result = 9)]
        public int NthFromEndTest(int[] input, int n)
            => NthFromTheEndInList<int>.Get(CreateList(input), n);

        [Test]
        [TestCase(new[] { 5, 91, 1, 12, 5, 2, 12 }, Result = new[] { 5, 91, 1, 12, 2 })]
        public int[] RemoveDuplicate1Test(int[] head)
            => GetArrayFromList(RemoveDuplicate.RemoveDuplicate1(CreateList(head)));

        [Test]
        [TestCase(new int[] { }, Result = new int[] { }, TestName = "DeleteMiddle_Empty")]
        [TestCase(new[] { 1 }, Result = new[] { 1 }, TestName = "DeleteMiddle_One")]
        [TestCase(new[] { 1, 2 }, Result = new[] { 1, 2 }, TestName = "DeleteMiddle_Two")]
        [TestCase(new[] { 1, 2, 3 }, Result = new[] { 1, 3 }, TestName = "DeleteMiddle_Three")]
        [TestCase(new[] { 1, 2, 3, 4 }, Result = new[] { 1, 3, 4 }, TestName = "DeleteMiddle_Four")]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, Result = new[] { 1, 2, 4, 5 }, TestName = "DeleteMiddle_Five")]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, Result = new[] { 1, 2, 4, 5, 6 }, TestName = "DeleteMiddle_Six")]
        public int[] DeleteMiddleTest(int[] head)
            => GetArrayFromList(DeleteMiddle.Delete(CreateList(head)));

        [Test]
        [TestCase(new int[] { }, 5, Result = new int[] { }, TestName = "Partition_Empty")]
        [TestCase(new int[] { 3 }, 5, Result = new int[] { 3 }, TestName = "Partition_One")]
        [TestCase(new int[] { 8, 3 }, 5, Result = new int[] { 3, 8 }, TestName = "Partition_Two1")]
        [TestCase(new int[] { 3, 8 }, 5, Result = new int[] { 3, 8 }, TestName = "Partition_Two2")]
        public int[] PartitionTest(int[] head, int n)
            => GetArrayFromList(Partition.Do(CreateList(head), n));

        [Test]
        [TestCase(new[] { 6, 1, 7 }, new[] { 2, 9, 5 }, Result = 912, TestName = "SumListExample")]
        [TestCase(new[] { 6, 1, 0, 3 }, new[] { 2, 9, 5 }, Result = 6398, TestName = "SumListNotSameLength")]
        [TestCase(new[] { 0 }, new[] { 1, 0, 0 }, Result = 100, TestName = "SumListZeroAndHundred")]
        [TestCase(new[] { 9, 7, 8 }, new[] { 6, 8, 5 }, Result = 1663, TestName = "SumListWhy")]
        public int SumListTest(int[] l1, int[] l2)
            => SumLists.SumList(CreateList(l1), CreateList(l2));

        [Test]
        [TestCase(new[] { 7, 1, 6 }, new[] { 5, 9, 2 }, Result = 912, TestName = "SubListReverseExample")]
        public int SubReverseListTest(int[] l1, int[] l2)
            => SumLists.SumListReverse(CreateList(l1), CreateList(l2));

        [Test]
        [TestCase(new[] { 2, 3, 9, 12, 38 }, new[] { 1, 4, 27 }, Result = new[] { 1, 2, 3, 4, 9, 12, 27, 38 }, TestName = "MergeT1")]
        [TestCase(new[] { 1, 4, 27 }, new[] { 2, 3, 9, 12, 38 }, Result = new[] { 1, 2, 3, 4, 9, 12, 27, 38 }, TestName = "MergeT2")]
        [TestCase(new[] { 2, 2, 2 }, new[] { 2, 2, 2, 2 }, Result = new[] { 2, 2, 2, 2, 2, 2, 2 }, TestName = "MergeT3")]
        [TestCase(new int[] { }, new int[] { }, Result = new int[] { }, TestName = "MergeT4")]
        public int[] MergeTest(int[] l1, int[] l2)
            => GetArrayFromList(MergeTwoSortedList.Merge(CreateList(l1), CreateList(l2)));

        [Test]
        [TestCase(new[] { 2, 3, 9, 12, 38 }, new[] { 1, 4, 27 }, Result = new[] { 1, 2, 3, 4, 9, 12, 27, 38 }, TestName = "Merge2T1")]
        [TestCase(new[] { 1, 4, 27 }, new[] { 2, 3, 9, 12, 38 }, Result = new[] { 1, 2, 3, 4, 9, 12, 27, 38 }, TestName = "Merge2T2")]
        [TestCase(new[] { 2, 2, 2 }, new[] { 2, 2, 2, 2 }, Result = new[] { 2, 2, 2, 2, 2, 2, 2 }, TestName = "Merge2T3")]
        [TestCase(new int[] { }, new int[] { }, Result = new int[] { }, TestName = "Merge2T4")]
        public int[] Merge2Test(int[] l1, int[] l2)
            => GetArrayFromList(MergeTwoSortedList.Merge2(CreateList(l1), CreateList(l2)));
        
        [Test]
        [TestCase(new[] { 1, 0 }, 1, Result = true, TestName = "TwoNodeCircle")]
        [TestCase(new[] { 1 }, 1, Result = true, TestName = "OneNodeCircle")]
        [TestCase(new[] { 0, 0, 0, 1 }, 1, Result = true, TestName = "ToOneNodeCircle")]
        [TestCase(new[] { 0, 0, 0, 1, 0, 0, 0 }, 1, Result = true, TestName = "HasCircle")]
        [TestCase(new[] { 0, 0, 0, 0, 0, 0, 0 }, 1, Result = false, TestName = "NoCircle")]
        public bool IsLoopTest(int[] head, int special)
            => LoopDetection.HasLoop(CreateLoopList(head, special));

        [Test]
        [TestCase(new[] { 1, 0 }, 1, TestName = "FindTwoNodesCircle")]
        [TestCase(new[] { 1 }, 1, TestName = "FindOneNodeCircle")]
        [TestCase(new[] { 0, 0, 0, 0, 1 }, 1, TestName = "FindListToOneNodeCircle")]
        [TestCase(new[] { 0, 0, 0, 0, 0, 0, 1, 0, 0 }, 1, TestName = "FindCircle1")]
        public void FindStart(int[] head, int special)
        {
            Assert.That(LoopDetection.FindStart(CreateLoopList(head, special)).Value, Is.EqualTo(special));
        }

        

        private static Node<T> CreateLoopList<T>(T[] input, T special)
        {
            Node<T> head = null;
            Node<T> c = null;
            Node<T> start = null;
            foreach (var i in input)
            {
                if (head == null)
                {
                    head = new Node<T>(i);
                    c = head;
                }
                else
                {
                    c.Next = new Node<T>(i);
                    c = c.Next;
                }
                if (i.Equals(special))
                    start = c;
            }
            if (c != null)
                c.Next = start;
            return head;
        } 

        private static Node<T> CreateList<T>(T[] input)
        {
            Node<T> head = null;
            Node<T> c = null;
            foreach (var i in input)
            {
                if (head == null)
                {
                    head = new Node<T>(i);
                    c = head;
                }
                else
                {
                    c.Next = new Node<T>(i);
                    c = c.Next;
                }
            }
            return head;
        }

        private static T[] GetArrayFromList<T>(Node<T> head)
        {
            var r = head;
            var result = new List<T>();
            while (r != null)
            {
                result.Add(r.Value);
                r = r.Next;
            }

            return result.ToArray();
        }
    }
}
