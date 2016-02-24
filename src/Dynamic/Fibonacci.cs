using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    public class Fibonacci
    {
        public int fibo1(int n)
        {
            switch(n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return fibo1(n - 1) + fibo1(n - 2);
            }
        }

        public int fibo2(int n)
        {
            if (n == 0)
                return 0;
            var nm1 = 1;
            var nm2 = 0;
            for (var i = 2; i < n; i++)
            {
                var t = nm1 + nm2;
                nm2 = nm1;
                nm1 = t;
            }

            return nm1 + nm2;
        }
    }
}
