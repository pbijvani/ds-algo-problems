using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.HashMap
{
    public class subarray_sum_equals_k
    {
        /*
            Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

            Example 1:

            Input:nums = [1,1,1], k = 2
            Output: 2
         
            https://leetcode.com/problems/subarray-sum-equals-k/
         */

        // Time O(N2)
        // Space O(1)
        public int SubarraySum1(int[] nums, int k)
        {
            var sum = 0;
            var count = 0;
            var len = nums.Length;
            for(int i = 0; i < len; i++)
            {
                sum = 0;
                for(int j = i; j< len; j++)
                {
                    sum = sum + nums[j];

                    if(sum == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }


        /*
            Time complexity : O(n)O(n). The entire numsnums array is traversed only once.

            Space complexity : O(n)O(n). Hashmap mapmap can contain upto nn distinct entries in the worst case.         
         */
        public int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;

            var map = new Dictionary<int, int>();

            map.Add(0, 1);

            for(int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];

                if(map.ContainsKey(sum - k))
                {
                    count = count + map[sum - k];
                }

                if(!map.ContainsKey(sum))
                {
                    map.Add(sum, 1);
                }
                else
                {
                    map[sum] = map[sum] + 1;
                }
            }

            return count;
        }

        public void test()
        {
            var arr = new int[] { 3, 4, 7, 2, -3, 1, 4, 2 };
            var k = 7;

            var res = SubarraySum1(arr, k);
        }
    }
}
