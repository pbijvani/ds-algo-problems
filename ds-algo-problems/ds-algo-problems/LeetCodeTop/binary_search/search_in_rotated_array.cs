using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.binary_search
{

    /*
        Given an integer array nums sorted in ascending order, and an integer target.

        Suppose that nums is rotated at some pivot unknown to you beforehand (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

        You should search for target in nums and if you found return its index, otherwise return -1.

 

        Example 1:

        Input: nums = [4,5,6,7,0,1,2], target = 0
        Output: 4
        Example 2:

        Input: nums = [4,5,6,7,0,1,2], target = 3
        Output: -1
        Example 3:

        Input: nums = [1], target = 0
        Output: -1

        https://leetcode.com/problems/search-in-rotated-sorted-array/
     
     */
    public class search_in_rotated_array
    {
        /*
         * Iterative approach
         * Time complexity : O(LOG N)
         */
        public int Search(int[] nums, int target)
        {
            var len = nums.Length;

            if (len == 0) return -1;
            if (len == 1) return nums[0] == target ? 0 : -1;

            var left = 0;
            var right = len - 1;

            bool searchLeft = false;
            bool searchRight = false;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                var leftVal = nums[left];
                var rightVal = nums[right];
                var midVal = nums[mid];

                if (midVal == target) return mid;
                if (leftVal == target) return left;
                if (rightVal == target) return right;

                if(leftVal < midVal && midVal < rightVal) // array is sorted and not rotated
                {
                    searchLeft = target <= midVal;
                    searchRight = target > midVal;
                }                
                else if (leftVal < midVal) // left part is sorted
                {
                    if(leftVal <= target && target <= midVal)
                    {
                        searchLeft = true;
                    }
                    else
                    {
                        searchRight = true;
                    }
                }
                else if(midVal < rightVal)
                {
                    if(midVal <= target && target <= rightVal)
                    {
                        searchRight = true;
                    }
                    else
                    {
                        searchLeft = true;
                    }
                }
                else if (leftVal == midVal && midVal == rightVal)
                {
                    searchLeft = true;
                    searchRight = true;
                }
                else if (leftVal == midVal)
                {
                    searchRight = true;
                }
                else if(midVal == right)
                {
                    searchLeft = true;
                }

                if(searchLeft && searchRight)
                {
                    left = left + 1;
                    right = right - 1;
                }
                else
                {
                    if(searchLeft)
                    {
                        right = mid - 1;
                    }
                    if(searchRight)
                    {
                        left = mid + 1;
                    }
                }

            }

            return -1;

        }

        /*
         * Approach 2 : Recursive
         * look in class SearchInRotatedArray
         */
        public void test()
        {
            var nums = new int[] { 1, 3 };

            var res = Search(nums, 2);
        }
    }
}
