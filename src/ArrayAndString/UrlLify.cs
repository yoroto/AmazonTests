using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class UrlLify
    {
        [Test]
        [TestCase("      ", 2, Result = "%20%20", TestName = "UrlLify_TwoWhitespaces")]
        [TestCase("this is a story.      ", 16, Result = "this%20is%20a%20story.", TestName = "UrlLify_sentence")]
        public string UrlLifyTest(string str, int length)
            => Do(str, length);

        public static string Do(string str, int length)
        {
            var input = str.ToCharArray();
            var count = 0;
            for (var i = 0; i < length; i++)
            {
                if (input[i] == ' ')
                    count++;
            }

            var c = length - 1 + count*2;
            for (var i = length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    input[c] = '0';
                    input[c - 1] = '2';
                    input[c - 2] = '%';
                    c = c - 3;
                }
                else
                {
                    input[c] = input[i];
                    c--;
                }
            }

            return new string(input);
        }
    }
}
