using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dynamic
{
    [TestFixture]
    public class GenParens
    {
        [Test]
        [TestCase(1, TestName = "One", Result = 1)]
        [TestCase(2, TestName = "Two", Result = 2)]
        [TestCase(3, TestName = "Three", Result = 5)]
        [TestCase(4, TestName = "Four", Result = 14)]
        public int GenParensTest(int n)
        {
            var list = GetAll(n);
            return list.Count;
        }

        public List<string> GetAll(int n)
        {
            var list = new List<string>();

            GetAll("(", list, n - 1, n);

            return list;
        }

        public void GetAll(string c, List<string> list, int left, int right)
        {
            if (left == 0 && right == 0)
                list.Add(c);

            if (left > 0)
            {
                GetAll(c + '(', list, left - 1, right);
            }

            if (right > left)
            {
                GetAll(c + ')', list, left, right - 1);
            }
        }
    }
}
