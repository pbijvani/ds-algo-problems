using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        You are a professional robber planning to rob houses along a street. 
        Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

 

        Example 1:

        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
                     Total amount you can rob = 1 + 3 = 4.
        Example 2:

        Input: nums = [2,7,9,3,1]
        Output: 12
        Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
                     Total amount you can rob = 2 + 9 + 1 = 12.
     
        https://leetcode.com/problems/house-robber/
     */
    public class house_robber
    {
        // Time O(2N)
        // Space 
        public int RobRecHelper(int[] nums, int index)
        {
            if (index >= nums.Length) return 0;

            return System.Math.Max(RobRecHelper(nums, index + 1), RobRecHelper(nums, index + 2) + nums[index]);
        }

        // Time : O(N) due to memorization
        // Space: O (N)
        public int RobHelper(int[] nums, int index, int[] memo)
        {
            if (index >= nums.Length) return 0;

            if (memo[index] > -1) return memo[index];

            memo[index] = System.Math.Max(RobHelper(nums, index + 1, memo), RobHelper(nums, index + 2, memo) + nums[index]);

            return memo[index];
        }


        // Time : O(N2)
        // Space : O(N)
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var dp = new int[nums.Length];

            dp[0] = nums[0];

            var maxRobbedValue = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                var runningRobbedVal = nums[i]; 

                for(int j = 0; j < i - 1; j++)
                {
                    runningRobbedVal = System.Math.Max(runningRobbedVal, dp[j] + nums[i]);
                }

                dp[i] = runningRobbedVal;
                maxRobbedValue = System.Math.Max(maxRobbedValue, runningRobbedVal);
            }
            return maxRobbedValue;
        }

        // O(N) time and O(N) space
        public int Rob1(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var dp = new int[nums.Length + 1];

            dp[0] = 0;
            dp[1] = nums[0];            

            for (int i = 1; i < nums.Length; i++)
            {
                int val = nums[i];

                dp[i + 1] = System.Math.Max(dp[i - 1] + val, dp[i]);
            }
            return dp[nums.Length];
        }

        // O(N) time and O(1) space
        public int Rob2(int[] nums)
        {
            if (nums.Length == 0) return 0;            

            var prev1 = 0;
            var prev2 = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int val = nums[i];

                var curr = System.Math.Max(prev1 + val, prev2);

                prev1 = prev2;
                prev2 = curr;
            }
            return prev2;
        }

        public void test()
        {
            var nums = new int[] { 2, 7, 9, 3, 1};

            var res = Rob(nums);
        }
    }
}
