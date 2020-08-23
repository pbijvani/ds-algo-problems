using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.binary_search
{
    // https://leetcode.com/problems/search-insert-position/
    public class insert_position
    {

        public int SearchInsertIterative(int[] nums, int target)
        {
            var len = nums.Length;

            if (target <= nums[0]) return 0;

            if (target > nums[len - 1]) return nums.Length;

            if (target == nums[len - 1]) return len - 1;

            var left = 0;
            var right = len - 1;

            while(left <= right)
            {
                var mid = (left + right) / 2;

                if(nums[mid] == target)
                {
                    return mid;
                }
                else if(target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public int SearchInsert(int[] nums, int target)
        {

            if (target <= nums[0]) return 0;

            if (target > nums[nums.Length - 1]) return nums.Length;

            if (target == nums[nums.Length - 1]) return nums.Length - 1;

            return SearchInsertHelper(nums, 0, nums.Length - 1, target);
        }

        public int SearchInsertHelper(int[] nums, int left, int right, int target)
        {
            if (left > right)
            {
                return -1;
            }

            var mid = (left + right) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }
            else if (target < nums[mid])
            {
                if (mid - 1 >= 0 && nums[mid - 1] < target)
                {
                    return mid - 1;
                }
                else
                {
                    return SearchInsertHelper(nums, left, mid - 1, target);
                }
            }
            else
            {
                if (mid + 1 >= nums.Length && target < nums[mid + 1])
                {
                    return mid + 1;
                }
                else
                {
                    return SearchInsertHelper(nums, mid + 1, right, target);
                }
            }

        }

        public void test()
        {
            var res = SearchInsert(new int[] { 1,3,5,6 }, 5);
        }
    }
}
