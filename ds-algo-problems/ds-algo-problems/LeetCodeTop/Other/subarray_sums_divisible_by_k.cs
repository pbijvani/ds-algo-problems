using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    public class subarray_sums_divisible_by_k
    {
        /*
            Given an array A of integers, return the number of (contiguous, non-empty) subarrays that have a sum divisible by K.

 

            Example 1:

            Input: A = [4,5,0,-2,-3,1], K = 5
            Output: 7
            Explanation: There are 7 subarrays with a sum divisible by K = 5:
            [4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]         
         */

        public int SubarraysDivByK(int[] A, int K)
        {
            var dict = new Dictionary<int, int>();
            var runningSum = 0;
            var count = 0;

            dict.Add(runningSum, 1);

            foreach(var num in A)
            {
                runningSum = runningSum + num;

                var mod = runningSum % K;
                // If you have -ve in running sum then convert it to +ve using below
                // var mod = ((runningSum % K) + K) % K;

                if(dict.ContainsKey(mod))
                {
                    count = count + dict[mod];
                    dict[mod] = dict[mod] + 1;
                }
                else
                {
                    dict.Add(mod, 1);
                }
                
            }
            return count;
        }

        public void test()
        {
            //var arr = new int[] { 4, 5, 0, -2, -3, 1 };
            var arr = new int[] { -1, 2, 9 };

            var res = SubarraysDivByK(arr, 2);
        }
    }
}
