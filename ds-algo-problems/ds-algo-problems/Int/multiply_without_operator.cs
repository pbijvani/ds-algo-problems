using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Int
{
    class multiply_without_operator
    {
        public int TestMultiply(int a, int b)
        {
            var res = multiply(a, b);
            return res;
        }
        public static int multiply(int a, int b)
        {
            int smaller = a < b ? a : b;
            int bigger = a < b ? b : a;

            if (smaller == 0)
            {
                return 0;
            }
            else if (smaller == 1)
            {
                return bigger;
            }

            int s = smaller >> 1;
            int halfProd = multiply(s, bigger);

            if (smaller % 2 == 0)
            {
                return halfProd + halfProd;
            }
            else
            {
                return halfProd + halfProd + bigger;
            }
        }

    }
}
