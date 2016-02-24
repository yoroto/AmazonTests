using System.Collections;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class ZeroMatrix
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public int[,] ZerofyTest(int[,] m)
            => Zerofy(m);

        public IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(new[,] {{0, 1}, {1, 1}}).Returns(new[,] {{0, 0}, {0, 1}}).SetName("TwoTwo");
                yield return new TestCaseData(new[,] {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}}).Returns(new[,] {{1, 0, 1}, {0, 0, 0}, {1, 0, 1}}).SetName("ThreeThree");
                yield return new TestCaseData(new[,] { { 0, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 0 } })
                    .Returns(new[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } }).SetName("FourFour");
                yield return new TestCaseData(new[,] { { 1, 0, 1, 1, 0 }, { 1, 0, 1, 0, 1}, { 1, 1, 0, 1, 1 }, { 1, 1, 1, 1, 1 } })
                    .Returns(new[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 1, 0, 0, 0, 0 } }).SetName("FiveFour");
            }
        }

        public static int[,] Zerofy(int[,] m)
        {
            var x = -1;
            var y = -1;
            for (var i = 0; i <= m.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= m.GetUpperBound(1); j++)
                {
                    if (m[i, j] == 0)
                    {
                        if (x == -1)
                        {
                            x = i;
                            y = j;
                            break;
                        }
                        else
                        {
                            m[i, y] = 0;
                            m[x, j] = 0;
                        }
                    }
                }
            }

            if (x != -1)
            {
                for (var i = 0; i <= m.GetUpperBound(0); i++)
                {
                    if (m[i, y] == 0 && i != x)
                    {
                        for (var j = 0; j <= m.GetUpperBound(1); j++)
                            m[i, j] = 0;
                    }
                }

                for (var j = 0; j <= m.GetUpperBound(1); j++)
                {
                    if (m[x, j] == 0 && j != y)
                    {
                        for (var i = 0; i <= m.GetUpperBound(0); i++)
                            m[i, j] = 0;
                    }
                }

                for (var j = 0; j <= m.GetUpperBound(1); j++)
                    m[x, j] = 0;

                for (var i = 0; i <= m.GetUpperBound(0); i++)
                    m[i, y] = 0;
            }

            return m;
        }
    }
}
