using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Int
{
    /*
     * check if given number is pow of 2
     */
    public class pow_of_two
    {
        public bool IsPowOfTwo(int num)
        {
            if (num == 1) return true;
            while(num % 2 == 0 && num > 1)
            {
                num = num / 2;
            }

            return num == 1;
        }

        public bool IsPowOf2(int num)
        {
            return (num & (num - 1)) == 0;
        }
    }
}
