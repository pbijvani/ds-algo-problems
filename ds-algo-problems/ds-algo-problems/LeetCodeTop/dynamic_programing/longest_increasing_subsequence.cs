using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        Given an unsorted array of integers, find the length of longest increasing subsequence.

        Example:

        Input: [10,9,2,5,3,7,101,18]
        Output: 4 
        Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
        Note:

        There may be more than one LIS combination, it is only necessary for you to return the length.
        Your algorithm should run in O(n2) complexity.

        Follow up: Could you improve it to O(n log n) time complexity?    
        
        https://leetcode.com/problems/longest-increasing-subsequence/
     */
    public class longest_increasing_subsequence
    {
        // Below solution will not work

        //public int LengthOfLIS(int[] nums)
        //{
        //    var count = 0;
        //    var maxCount = 0;

        //    for(int i = 0; i < nums.Length; i++)
        //    {
        //        var runningNum = nums[i];
        //        count = 1;
        //        for(int j = i + 1; j < nums.Length; j++)
        //        {
        //            if(nums[j] > runningNum)
        //            {
        //                runningNum = nums[j];
        //                count++;
        //            }
        //        }
        //        maxCount = System.Math.Max(count, maxCount);
        //    }

        //    return maxCount;
        //}


        /*
            Complexity Analysis

            Time complexity : O(2^n) Size of recursion tree will be 2^n
            
             .

            Space complexity : O(n^2) memomemo array of size n * nn∗n is used                     
         */
        public int LengthOfLIS(int[] nums, int prev, int currIndex)
        {
            if (currIndex == nums.Length) return 0;

            int taken = 0;
            if(nums[currIndex] > prev)
            {
                taken = 1 + LengthOfLIS(nums, nums[currIndex], currIndex + 1);
            }

            int notTaken = LengthOfLIS(nums, prev, currIndex + 1);

            return System.Math.Max(taken, notTaken);
        }

        /*
Time complexity : O(n^2)
Space complexity : O(n^2)
         */
        public int LengthOfLISWithMem(int[] nums, int prevIndex, int currIndex, int[,] memo)
        {
            if (currIndex == nums.Length) return 0;

            if(memo[prevIndex+1, currIndex] >= 0)
            {
                return memo[prevIndex + 1, currIndex];
            }

            int taken = 0;
            if (prevIndex < 0 || nums[currIndex] > nums[prevIndex])
            {
                taken = 1 + LengthOfLISWithMem(nums, currIndex, currIndex + 1, memo);
            }

            int notTaken = LengthOfLISWithMem(nums, prevIndex, currIndex + 1, memo);

            memo[prevIndex + 1, currIndex] = System.Math.Max(taken, notTaken);

            return memo[prevIndex + 1, currIndex];
        }

        // Time : O (N2)
        // Space: O(N)
        public int lengthOfLISDP(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var dp = new int[nums.Length];

            dp[0] = 1;

            int max = 1;

            for(int i = 1; i < nums.Length; i++)
            {
                var maxVal = 0;

                for(int j = 0; j < nums.Length; j++)
                {
                    if(nums[i] < nums[i])
                    {
                        maxVal = System.Math.Max(maxVal, dp[j]);
                    }
                }

                dp[i] = maxVal + 1;
                max = System.Math.Max(maxVal, max);
            }

            return max;
        }

        public void test()
        {
            var res = LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 4 }, int.MinValue, 0);
        }

        public void testWithMemo()
        {
            var nums = new int[] { 10, 9, 2, 5, 3, 4 };

            var memo = new int[nums.Length + 1, nums.Length];

            for(int i = 0; i < memo.GetLength(0); i++)
            {
                for(int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            var res = LengthOfLISWithMem(nums, -1, 0, memo);
        }
    }
}
