using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class OneAway
    {
        [Test]
        [TestCase("pale", "ple", Result = true, TestName = "Example1")]
        [TestCase("ple", "pale", Result = true, TestName = "Example2")]
        [TestCase("bale", "pale", Result = true, TestName = "Replacement")]
        [TestCase("sados", "sodas", Result = false, TestName = "NegExample1")]
        [TestCase("s", "a", Result = true, TestName = "Example3")]
        [TestCase("s", "", Result = true, TestName = "Example4")]
        [TestCase("s", "sa", Result = true, TestName = "Example5")]
        [TestCase("sbbb", "sabbb", Result = true, TestName = "Example6")]
        [TestCase("sbbc", "sabbb", Result = false, TestName = "NegExample2")]
        [TestCase("sbbc", "sbbccc", Result = false, TestName = "NegExample3")]
        public bool CheckTest(string s1, string s2)
            => Check(s1, s2);

        public static bool Check(string s1, string s2)
        {
            switch (s1.Length - s2.Length)
            {
                case 1:
                    return OneMore(s1, s2);
                case 0:
                    return OneDiff(s1, s2);
                case -1:
                    return OneMore(s2, s1);
                default:
                    return false;
            }
        }

        public static bool OneMore(string s1, string s2)
        {
            var found = false;
            for (var i = 1; i < s2.Length; i++)
            {
                if (found && s1[i + 1] != s2[i])
                {
                    return false;
                }
                if (!found && s1[i] != s2[i])
                {
                    found = true;
                }
            }

            return true;
        }

        public static bool OneDiff(string s1, string s2)
        {
            var found = false;
            for (var i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (found)
                        return false;
                    found = true;
                }
            }

            return found;
        }
    }
}
