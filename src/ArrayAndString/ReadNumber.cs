using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ArrayAndString
{
    [TestFixture]
    public class ReadNumberIntoString
    {
        [Test]
        [TestCase(0, Result = "zero", TestName = "Zero")]
        [TestCase(4, Result = "four", TestName = "Four")]
        [TestCase(12, Result = "twelve", TestName = "Tweleve")]
        [TestCase(21, Result = "twenty one", TestName = "TwentyOne")]
        [TestCase(108, Result = "one hundred eight", TestName = "YaoLingBa")]
        [TestCase(1008, Result = "one thousand eight", TestName = "YaoQianBa")]
        [TestCase(15345, Result = "fifteen thousand three hundred fourty five", TestName = "15345")]
        [TestCase(1000000, Result = "one million", TestName = "OneMillion")]
        [TestCase(215310027, Result = "two hundred fifteen million three hundred ten thousand twenty seven", TestName = "Big")]
        [TestCase(-45211, Result = "minus fourty five thousand two hundred eleven", TestName = "Minus")]
        public string ReadNumberIntoStringTest(int num)
            => Read(num);

        public static string Read(int num)
        {
            if (num == 0)
                return "zero";

            var c = num;
            var b = 0;
            var sb = new StringBuilder();
            var minus = false;

            if (c < 0)
            {
                c = -c;
                minus = true;
            }

            var ra = new int[3];

            while (c > 0)
            {
                int r;
                c = Math.DivRem(c, 10, out r);

                var cb = b%3;
                ra[cb] = r;

                if (cb == 2 || c == 0)
                {
                    if (!ra.All(m => m == 0))
                    {
                        sb.Insert(0, ReadBase(b/3));
                    }

                    if (ra[1] == 1)
                    {
                        sb.Insert(0, ReadTeen(ra[0]));
                    }
                    else
                    {
                        sb.Insert(0, ReadNumber(ra[0]) + " ");
                        sb.Insert(0, ReadTy(ra[1]));
                    }

                    if (ra[2] != 0)
                    {
                        sb.Insert(0, ReadNumber(ra[2]) + " hundred ");
                    }

                    Array.Clear(ra, 0, 3);
                }

                b++;
            }

            if (minus)
                sb.Insert(0, "minus ");

            return sb.ToString().Trim();
        }

        internal static string ReadTeen(int c)
        {
            switch (c)
            {
                case 0:
                    return "ten ";
                case 1:
                    return "eleven ";
                case 2:
                    return "twelve ";
                case 3:
                    return "thirteen ";
                case 4:
                    return "fourteen ";
                case 5:
                    return "fifteen ";
                case 6:
                    return "sixteen ";
                case 7:
                    return "seventeen ";
                case 8:
                    return "eighteen ";
                case 9:
                    return "nineteen ";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static string ReadTy(int c)
        {
            switch (c)
            {
                case 0:
                    return string.Empty;
                case 2:
                    return "twenty ";
                case 3:
                    return "thirty ";
                case 4:
                    return "fourty ";
                case 5:
                    return "fifty ";
                case 6:
                    return "sixty ";
                case 7:
                    return "seventy ";
                case 8:
                    return "eighty ";
                case 9:
                    return "ninety ";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static string ReadNumber(int num)
        {
            switch (num)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return string.Empty;
            }
        }

        internal static string ReadBase(int b)
        {
            switch (b)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return "thousand ";
                case 2:
                    return "million ";
                case 3:
                    return "billion ";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
