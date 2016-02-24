using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class SumPair
    {
        public static IEnumerable<int[]> Find(int[] input, int target)
        {
            HashSet<int> toFind = new HashSet<int>();

            foreach (var i in input)
            {
                if (toFind.Contains(i))
                    yield return new[] {target - i, i};
                toFind.Add(target - i);
            }
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int[][] FindSumTest(int[] input, int target)
            => Find(input, target).ToArray();

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new[] {3, 132, 15, 55, 13, 17, 45, 1}, 18).Returns(new[] {new[] {3, 15}, new [] {17, 1}});
                yield return new TestCaseData(new[] {45, 123, 46, 14, 5, 66, 45, 14}, 91).Returns(new[] {new[] {45, 46}, new[] {46, 45}});
            }
        }
    }
}
