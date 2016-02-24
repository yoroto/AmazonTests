using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Skyline
{
    [TestFixture]
    public class Test
    {
        [Test]
        [TestCaseSource("TestCases")]
        public int[][] Skyline1Test(int[,] input)
            => Skyline1.Skyline(input).ToArray();

        public static IEnumerable TestCases
        {
            get
            {
                yield return
                    new TestCaseData(new[,] {{1, 5, 11}, {2, 7, 6}})
                        .Returns(new[] {new[] {1, 11}, new[] {5, 6}, new [] {7, 0}})
                        .SetName("Simple");
                yield return
                    new TestCaseData(new[,]
                    {
                        {1, 5, 11}, {2, 7, 6}, {3, 9, 13}, {12, 16, 7}, {14, 25, 3}, {19, 22, 18}, {23, 29, 13},
                        {24, 28, 4}
                    })
                        .Returns(new[]
                        {
                            new[] {1, 11}, new[] {3, 13}, new[] {9, 0}, new[] {12, 7}, new[] {16, 3}, new[] {19, 18},
                            new[] {22, 3}, new[] {23, 13}, new[] {29, 0}
                        })
                        .SetName("Original");
                yield return
                    new TestCaseData(new[,] {{1, 5, 11}, {2, 160, 7}, {114, 223, 16}})
                        .Returns(new[] {new[] {1, 11}, new[] {5, 7}, new[] {114, 16}, new[] {223, 0}})
                        .SetName("Resize");
            }
        } 
    }
}
