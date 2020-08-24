using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.recursion
{
    /*
        Implement pow(x, n), which calculates x raised to the power n (i.e. xn).

        Example 1:

        Input: x = 2.00000, n = 10
        Output: 1024.00000
        Example 2:

        Input: x = 2.10000, n = 3
        Output: 9.26100
        Example 3:

        Input: x = 2.00000, n = -2
        Output: 0.25000
        Explanation: 2-2 = 1/22 = 1/4 = 0.25     
     */
    public class powx_n
    {
        // O(N) solution
        public double MyPow(double x, int n)
        {
            if (x == 0) return 1;
            if (n < 0)
            {                
                n = n * -1;
                x = 1 / x;
            }

            double res = 1;
            for (int i = 1; i <= n; i++)
            {
                res = res * x;
            }
            return res;
        }

        // O(log N) solution
        public double MyPow1(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0)
            {
                n = n * -1;
                x = 1 / x;
            }
            if (n == 1) return x;

            var y = MyPow(x, n / 2);

            if (n % 2 == 0)
            {
                return y * y;
            }
            else
            {
                return x * y * y;
            }
        }

    }
}
