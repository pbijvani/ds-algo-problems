using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Bit
{
    public class num_bit_flip_a_to_b
    {
        /*
         * write a function to determine the number of bits you would need to flip to convert int A to B
         */

        public int BitFlipRequired(int a, int b)
        {
            var count = 0;
            int c = a ^ b;
            while(c != 0)
            {
                count = count + c & 1; // increment count if c ends with a 1
                c = c >> 1;
            }

            return count;
        }
    }
}
