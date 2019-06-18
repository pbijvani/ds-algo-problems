using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    class Kth_Largest_element
    {
        public int findKthLargest(int[] nums, int k)
        {
            if (k < 1 || nums == null)
            {
                return 0;
            }

            return getKth(nums.Length - k + 1, nums, 0, nums.Length - 1);
        }

        public int getKth(int k, int[] nums, int start, int end)
        {

            int pivot = nums[end];

            int left = start;
            int right = end;

            while (true)
            {

                while (nums[left] < pivot && left < right)
                {
                    left++;
                }

                while (nums[right] >= pivot && right > left)
                {
                    right--;
                }

                if (left == right)
                {
                    break;
                }

                swap(nums, left, right);
            }

            swap(nums, left, end);

            if (k == left + 1)
            {
                return pivot;
            }
            else if (k < left + 1)
            {
                return getKth(k, nums, start, left - 1);
            }
            else
            {
                return getKth(k, nums, left + 1, end);
            }
        }

        public void swap(int[] nums, int n1, int n2)
        {
            int tmp = nums[n1];
            nums[n1] = nums[n2];
            nums[n2] = tmp;
        }
    }
}
