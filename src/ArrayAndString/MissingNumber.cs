using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class MissingNumber
    {
        public static int Find(int[] arr)
        {
            var upper = arr[arr.Length - 1];
            var lower = arr[0] - 1;
            return upper*(upper + 1)/2 - lower*(lower + 1)/2 - arr.Sum();
        }

        [Test]
        [TestCase(new[] {4, 5, 6, 7, 9, 10}, Result = 8)]
        public int FindTest(int[] input)
            => Find(input);
    }
}
