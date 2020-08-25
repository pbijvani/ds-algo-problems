using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.sliding_window
{
    /*
        Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

        Example: 

        Input: s = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: the subarray [4,3] has the minimal length under the problem constraint.
        Follow up:
        If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n).   

        https://leetcode.com/problems/minimum-size-subarray-sum/
     */


    /*
     * Slinding window approach
     * Time O(n)
     * SPace O(1)
     */
    public class minimum_size_subarray_sum
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums.Length == 0) return 0;
            var left = 0;
            var right = 0;
            var len = 0;
            var minLen = int.MaxValue;
            var sum = 0;

            while (left <= right && right <= nums.Length)
            {
                if (sum > s)
                {
                    sum = sum - nums[left];
                    left++;
                    len--;
                }
                else
                {
                    if (right < nums.Length)
                    {
                        sum = sum + nums[right];
                        len++;
                    }
                    right++;
                }

                if (sum >= s)
                {
                    minLen = System.Math.Min(minLen, len);
                }
            }
            return minLen == int.MaxValue ? 0 : minLen;
        }

        /*
         * refactor of same solution above
         */
        public int MinSubArrayLen1(int s, int[] nums)
        {
            var minLen = int.MaxValue;
            var start = 0;
            var sum = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                sum = sum + nums[end];

                while(sum >= s)
                {
                    var currLen = end - start + 1;
                    minLen = System.Math.Min(minLen, currLen);
                    sum = sum - nums[start];
                    start++;
                }
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }

        public void test()
        {
            var res = MinSubArrayLen(7, new int[] {2,3,1,2,4,3 });
        }
    }
}
