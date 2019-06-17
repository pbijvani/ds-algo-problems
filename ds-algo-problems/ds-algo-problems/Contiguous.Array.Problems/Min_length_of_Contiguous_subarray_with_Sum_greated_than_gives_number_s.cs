using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Contiguous.Array.Problems
{
    class Min_length_of_Contiguous_subarray_with_Sum_greated_than_gives_number_s
    {
        /// <summary>
        /// Minimum Size Subarray Sum
        /// Given an array of n positive integers and a positive integer s, 
        /// find the minimal length of a contiguous subarray of which the sum ≥ s. 
        /// If there isn't one, return 0 instead
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int s, int[] nums)
        {
            var minLength = int.MaxValue;
            var total = 0;
            for (int start = 0, end = 0; end < nums.Count(); end++)
            {
                total += nums[end];
                while (total >= s && start <= end)
                {
                    minLength = System.Math.Min(minLength, end - start + 1);
                    total -= nums[start++];
                }
            }
            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
