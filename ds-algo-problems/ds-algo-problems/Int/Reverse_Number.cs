using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Int
{
    public class Reverse_Number
    {
        public long reversDigits(long num)
        {
            long rev_num = 0;
            while (num > 0)
            {
                rev_num = rev_num * 10 + num % 10;
                num = num / 10;
            }
            return rev_num;

        }
    }
}
