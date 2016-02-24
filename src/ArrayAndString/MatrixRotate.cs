using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class MatrixRotate
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[,] RotateTest(int[,] m)
            => Rotate(m);

        public IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(new[,] { { 1, 2 }, { 3, 4 } })
                    .Returns(new[,] { { 3, 1 }, { 4, 2 } }).SetName("SizeTwo");
                yield return new TestCaseData(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } })
                    .Returns(new[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } }).SetName("SizeThree");
                yield return new TestCaseData(new[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } })
                    .Returns(new[,] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } }).SetName("SizeFour");
                yield return new TestCaseData(new[,] { { 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3 }, { 4, 4, 4, 4, 4 }, { 5, 5, 5, 5, 5 } })
                    .Returns(new[,] { { 5, 4, 3, 2, 1 }, { 5, 4, 3, 2, 1 }, { 5, 4, 3, 2, 1 }, { 5, 4, 3, 2, 1 }, { 5, 4, 3, 2, 1 } }).SetName("SizeFive");
                yield return new TestCaseData(new[,] { { 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3, 3 }, { 4, 4, 4, 4, 4, 4 }, { 5, 5, 5, 5, 5, 5 }, { 6, 6, 6, 6, 6, 6 } })
                    .Returns(new[,] { { 6, 5, 4, 3, 2, 1 }, { 6, 5, 4, 3, 2, 1 }, { 6, 5, 4, 3, 2, 1 }, { 6, 5, 4, 3, 2, 1 }, { 6, 5, 4, 3, 2, 1 }, { 6, 5, 4, 3, 2, 1 } }).SetName("SizeSix");
            }
        } 

        public static int[,] Rotate(int[,] m)
        {
            var c = m.GetUpperBound(0);

            for (var i = 0; i < (c + 1)/2; i++)
            {
                for (var j = i; j < c - i; j++)
                {
                    var tmp = m[i,j];
                    m[i,j] = m[c - j,i];
                    m[c - j, i] = m[c - i, c - j];
                    m[c - i, c - j] = m[j, c - i];
                    m[j, c - i] = tmp;
                }
            }
            return m;
        }
    }
}
