using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class max_un_sorted_subarray
    {

        public int[] MaximumUnsortedSumarray(int[] input)
        {
            int left = 0;
            int right = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (left == 0 && input[i] > input[i + 1])
                {
                    left = i;
                    right = i + 1;
                }

                if (left != 0 && input[i] > input[i + 1])
                {
                    right = i + 1;
                }
            }

            return input.SubArray(left, right - left + 1);
        }
    }
}
