using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dynamic
{
    [TestFixture]
    public class Coins
    {
        [Test]
        [TestCase(6, new[] { 25, 10, 5, 1 }, Result = 2)]
        [TestCase(12, new[] { 25, 10, 5, 1 }, Result = 4)]
        public int FindTest(int n, int[] types)
        {
            var r = AllCombine(n, types);

            return r.Count;
        }

        public List<int[]> AllCombine(int n, int[] types)
        {
            return Find(types, 0, n);
        }

        private List<int[]> Find(int[] types, int index, int n)
        {
            var list = new List<int[]>();
            if (index == types.Length)
                return list;
            if (types[index] > n)
                return Find(types, index + 1, n);

            for (var i = 0; i <= n/types[index]; i++)
            {
                if (n - types[index]*i == 0)
                {
                    var item = new int[types.Length];
                    item[index] = i;
                    list.Add(item);
                }
                else
                {
                    var items = Find(types, index + 1, n - types[index]*i);
                    items.ForEach(s =>
                    {
                        s[index] = i;
                        list.Add(s);
                    });
                }
            }
            return list;
        }
    }
}
