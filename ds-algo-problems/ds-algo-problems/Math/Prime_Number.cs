using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Math
{
    class Prime_Number
    {
        public int CountPrimes(int n)
        {
            var isNotPrime = new bool[n];

            for (var i = 2; i < n; i++)
            {
                if (isNotPrime[i]) continue;
                var start = i + i;
                while (start < n)
                {
                    isNotPrime[start] = true;
                    start += i;
                }
            }
            // remove 0 and 1
            return isNotPrime.Skip(2).Count(x => x == false);
        }

        public bool IsPrime(int n)
        {
            if (n < 2) return false;

            int sqrt = (int)System.Math.Sqrt(n);

            for (int i = 2; i <= sqrt; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
