using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    /*
        Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

        If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

        The replacement must be in-place and use only constant extra memory.

        Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.

        1,2,3 → 1,3,2
        3,2,1 → 1,2,3
        1,1,5 → 1,5,1  
        
        https://leetcode.com/problems/next-permutation/
     */
    public class next_permutation
    {
        public void NextPermutation(int[] nums)
        {
            var len = nums.Length;
            var leftIndex = len - 1;

            while (leftIndex >= 1 && nums[leftIndex] <= nums[leftIndex - 1])
            {
                leftIndex = leftIndex - 1;
            }
            var breakingIndex = leftIndex - 1;
            if (leftIndex >= 0)
            {
                
                var swapIndex = leftIndex;
                var minDiff = int.MaxValue;

                for (int i = breakingIndex + 1; i < len - 1; i++)
                {
                    var diff = nums[i] - nums[breakingIndex];

                    if (diff < minDiff && diff > 0)
                    {
                        diff = minDiff;
                        swapIndex = i;
                    }
                }

                // swap
                var temp = nums[swapIndex];
                nums[swapIndex] = nums[breakingIndex];
                nums[breakingIndex] = temp;
            }

            // Reverse partial array
            var partialArray = nums.SubArray(breakingIndex + 1, len - breakingIndex - 1).Reverse().ToArray();

            for (int i = breakingIndex + 1; i < len; i++)
            {
                nums[i] = partialArray[i - breakingIndex - 1];
            }
        }

        // Clean code. Same as above
        public void nextPermutation1(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                swap(nums, i, j);
            }
            reverse(nums, i + 1);
        }

        private void reverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                swap(nums, i, j);
                i++;
                j--;
            }
        }

        private void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void test()
        {
            var num = new int[] { 1,3,2 };

            NextPermutation(num);
        }
    }
}

