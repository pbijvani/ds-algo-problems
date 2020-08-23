using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.binary_search
{
    /*
        Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

        Find the minimum element.

        You may assume no duplicate exists in the array.

        Example 1:

        Input: [3,4,5,1,2] 
        Output: 1
        Example 2:

        Input: [4,5,6,7,0,1,2]
        Output: 0     
     */
    public class find_minimum_in_sorted_rotated_array
    {
        /*
            Time Complexity : Same as Binary Search O(\log N)O(logN)
            Space Complexity : O(1)O(1)         
         */
        public int FindMin(int[] nums)
        {
            var len = nums.Length;

            if (len == 0) return -1;
            if (len == 1) return nums[0];

            var left = 0;
            var right = len - 1;

            // array is not sorted
            if(nums[left] < nums[right])
            {
                return nums[left];
            }

            while(left <= right)
            {
                var mid = (left + right) / 2;

                // if the mid element is greater than its next element then mid+1 element is the smallest
                // This point would be the point of change. From higher to lower value.
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }

                // if the mid element is lesser than its previous element then mid element is the smallest
                if (nums[mid - 1] > nums[mid])
                {
                    return nums[mid];
                }

                if (nums[left] < nums[mid]) // left part is sorted
                {
                    left = mid;
                }
                else if(nums[mid] < nums[right]) // right part is sorted
                {
                    right = mid;
                }
            }

            return -1;
        }
    }
}
