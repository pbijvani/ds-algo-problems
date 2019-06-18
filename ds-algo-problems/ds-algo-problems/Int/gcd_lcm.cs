using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Int
{
    class gcd_lcm
    {
        public int GCD(int a, int b)
        {
            var res = GCDRecursive(a, b);

            return res;
        }

        // Gretest Common DIvisor
        public int GCDRecursive(int a, int b)
        {
            if (b == 0) return a;

            var gcd = GCDRecursive(b, a % b);

            return gcd;
        }
        // Least common multiplier
        public int LCM(int a, int b)
        {
            return (a * b) / GCDRecursive(a, b);
        }
    }
}
