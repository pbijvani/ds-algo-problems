using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Int
{
    public class factorial_count_trailing_zero
    {
        public int CountTrailingZero(int n)
        {
            int count = 0;
            for(int i = 0; i < n; i++)
            {                
                if(i % 5 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountTrailingZero1(int n)
        {
            int count = 0;
            for(int i = 5; n / i > 0; i *= 5)
            {
                count += n / i;
            }
            return count;
        }
    }
}
