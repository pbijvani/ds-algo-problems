using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Int
{
    public class max_of_two_number_without_if_else
    {
        public int flip(int num)
        {
            return num ^ 1;
        }
        public int getSign(int num)
        {
            // if diff is +ve return 1, else 0
            return flip((num >> 31) & 1);
        }
        public int GetMax(int a, int b)
        {
            // get sign
            var diff = a - b;
            int k = getSign(diff);
            int j = flip(k);

            return a * k + b * j;
        }
    }
}
