using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndString
{
    public class Parlindrome
    {
        public static bool IsParlindrome(string str)
        {
            var s = 0;
            var e = str.Length - 1;
            while (e > s)
            {
                if (str[s++] != str[e--])
                    return false;
            }
            return true;
        }

        public static bool IsParlindromePermuation(string str)
        {
            return true;
        }
    }
}
