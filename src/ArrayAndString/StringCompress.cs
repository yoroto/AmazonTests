using System.Text;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class StringCompress
    {
        [Test]
        [TestCase("", Result = "", TestName = "Empty")]
        [TestCase("aa", Result = "aa", TestName = "TwoChars")]
        [TestCase("aaa", Result = "a3", TestName = "ThreeChars")]
        [TestCase("aab", Result = "aab", TestName = "ThreeChars")]
        [TestCase("aabcccccaaa", Result = "a2b1c5a3", TestName = "Example")]
        [TestCase("aabbccddee", Result = "aabbccddee", TestName = "SameLength")]
        [TestCase("abcd", Result = "abcd", TestName = "TooBad")]
        [TestCase("aabbccdddee", Result = "a2b2c2d3e2", TestName = "OneCharGain")]
        [TestCase("aabbccddee", Result = "aabbccddee", TestName = "SameLength")]
        public string CompressTest(string str)
            => Compress(str);

        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 3)
                return input;
            var sb = new StringBuilder(input.Length);
            var c = input[0];
            var count = 1;
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    count++;
                }

                if (input[i] != c)
                {
                    if (sb.Length + 2 >= sb.Capacity)
                        return input;
                    sb.Append(c);
                    sb.Append(count);
                    c = input[i];
                    count = 1;
                }
            }

            if (sb.Length + 2 >= sb.Capacity)
                return input;
            sb.Append(c);
            sb.Append(count);

            return sb.ToString();
        }
    }
}
