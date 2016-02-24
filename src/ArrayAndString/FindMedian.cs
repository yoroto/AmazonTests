using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class FindMedian
    {
        internal static decimal Median(int[] a, int start, int length)
        {
            return length%2 == 0
                ? (a[start + length/2 - 1] + a[start + length/2])/2
                : a[start + (length - 1)/2];
        }

        internal static decimal Median(params int[] numbers) 
            => numbers.Length % 2 == 1
                ? numbers.OrderBy(e => e).ElementAt((numbers.Length - 1)/2)
                : ((decimal) numbers.OrderBy(e => e).Where((n, index) => index == numbers.Length/2 || index == numbers.Length/2 - 1).Sum())/2;

        public static decimal Find(int[] a1, int[] a2)
            => a1.Length > a2.Length
                ? Find(a1, 0, a1.Length, a2, 0, a2.Length)
                : Find(a2, 0, a2.Length, a1, 0, a1.Length);
        
        public static decimal Find(int[] a1, int s1, int l1, int[] a2, int s2, int l2)
        {
            if (l2 == 0)
                return Median(a1, s1, l1);

            if (l2 == 1)
            {
                if (l1 == 1)
                    return ((decimal)(a1[s1] + a2[s2]))/2;
                if (l1%2 == 0)
                    return Median(a2[s2], a1[s1 + l1/2 - 1], a1[s1 + l1/2]);
                else
                    return Median(a2[s2], a1[s1 + (l1 - 1)/2 - 1], a1[s1 + (l1 - 1)/2], a1[s1 + (l1 - 1)/2 + 1]);
            }

            if (l2 == 2)
            {
                if (l1 == 2)
                    return Median(a2[s2], a2[s2 + 1], a1[s1], a1[s1 + 1]);
                if (l1%2 == 0)
                    return Median(a2[s2], a2[s2 + 1], a1[s1 + l1/2 - 2], a1[s1 + l1/2 - 1], a1[s1 + l1/2], a1[s1 + l1/2 + 1]);
                else
                    return Median(a2[s2], a2[s2 + 1], a1[s1 + (l1 - 1)/2 - 1], a1[s1 + (l1 - 1)/2], a1[s1 + (l1 - 1)/2 + 1]);
            }

            if (Median(a1, s1, l1) >= Median(a2, s2, l2))
            {
                var k = l2%2 == 0 ? l2/2 - 1 : l2/2;
                return Find(a1, s1, l1 - k, a2, s2 + k, l2 - k);
            }
            else
            {
                int k = (l2 - 1)/2;
                return Find(a1, s1 + k, l1 - k, a2, s2, l2 - k);
            }
        }

        [Test]
        [TestCase(new[] { 1, 12, 15, 26, 38 }, new[] { 2, 13, 17, 30, 45 }, Result = 16, TestName = "Even1")]
        [TestCase(new[] { 1, 6, 14, 26}, new[] { 13, 17, 30, 45 }, Result = 15.5, TestName = "Even2")]
        [TestCase(new[] { 1, 12, 15, 26, 38 }, new[] { 2, 13, 17, 30 }, Result = 15, TestName = "Odd")]
        public decimal FindTest(int[] a1, int[] a2)
            => Find(a1, a2);
    }
}
