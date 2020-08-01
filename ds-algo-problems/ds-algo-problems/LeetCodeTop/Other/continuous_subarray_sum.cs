using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    public class continuous_subarray_sum
    {
        /*
            Given a list of non-negative numbers and a target integer k, 
            write a function to check if the array has a continuous subarray of size at least 2 that sums up to a multiple of k, 
            that is, sums up to n*k where n is also an integer.

            Example 1:

            Input: [23, 2, 4, 6, 7],  k=6
            Output: True
            Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
            Example 2:

            Input: [23, 2, 6, 4, 7],  k=6
            Output: True
            Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.    
            
            https://leetcode.com/problems/continuous-subarray-sum/

         */

        /*
        
        Approach 1 : FInd all sub array and check if sum is multiple of k
        Time : O (N2)
        Space : O(n) or O(1) depending on how you implement

        */


        // Approach 2
        //Time:  O (N)
        // Space : O(K)
        /*
         * Array : [23, 2, 1, 6, 7], K = 9
         * Running Sum: [23, 25, 26, 32, 39]
         * running sume mod k : [5, 7, 8, 5, 3]
         * 
         * so when we see repeat 5 at index 0 and index 3 means sum of element at 1 to 3 is multiple of 9
         */
        public bool CheckSubarraySum1(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            dict.Add(0, -1);

            int runningSum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                runningSum = runningSum + nums[i];
                if (k != 0)
                    runningSum = runningSum % k;

                if(dict.ContainsKey(runningSum))
                {
                    if (i - dict[runningSum] > 1)
                        return true;
                }
                else
                {
                    dict.Add(runningSum, i);
                }
            }

            return false;
        }



      

        public void test()
        {
            //var arr = new int[] { 23, 2, 6, 4, 7 };

            var arr = new int[] { 5, 0, 0 };

            var res = CheckSubarraySum1(arr, 0);
        }
    }
}
