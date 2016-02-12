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
