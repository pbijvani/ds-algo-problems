using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

        Example 1:

        Input: [2,3,2]
        Output: 3
        Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2),
                     because they are adjacent houses.
        Example 2:

        Input: [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
                     Total amount you can rob = 1 + 3 = 4.
     
        https://leetcode.com/problems/house-robber-ii/
     */
    public class house_robber_ii
    {
        // This is same concept as house_robber. 
        // Just splitting array into two part. One includes first elemnt and other includes last element
        // Run same algo on both array
        // Max of two is the answer
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            var res1 = RobHelper(nums, 0, nums.Length - 2);
            var res2 = RobHelper(nums, 1, nums.Length - 1);

            return System.Math.Max(res1, res2);
        }

        // this method runs on O(n) time and O(1) space
        public int RobHelper(int[] nums, int start, int end)
        {
            if (start > end) return 0;
            if (start == end) return nums[start];
            if (end - start == 1) return System.Math.Max(nums[start], nums[end]);


            var prev2 = 0;
            var prev1 = nums[start];

            for(int i = start +1; i <= end; i++)
            {
                var temp = System.Math.Max(nums[i] + prev2, prev1);
                prev2 = prev1;
                prev1 = temp;
            }

            return prev1;
        }

        // Attempt to combine both iteration together
        public int RobHelperAnother(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return System.Math.Max(nums[0], nums[1]);

            // Split 1 : 0 to len - 2
            // Split 2 : 1 to len - 1

            var prev2Split2 = 0;
            var prev1Split2 = 0;

            var prev2Split1 = 0;
            var prev1Split1 = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if(i < nums.Length -1 )
                {
                    var tempSplit1 = System.Math.Max(nums[i] + prev2Split1, prev1Split1);
                    prev2Split1 = prev1Split1;
                    prev1Split1 = tempSplit1;
                }

                var tempSplit2 = System.Math.Max(nums[i] + prev2Split2, prev1Split2);
                prev2Split2 = prev1Split2;
                prev1Split2 = tempSplit2;
            }

            return System.Math.Max(prev1Split1, prev1Split2);
        }
    }
}
