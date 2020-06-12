using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class Remove_Duplicate_From_Array_Max_2_Allowed
    {
        public int RemoveDuplicateElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }
        public int removeDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
        public int RemoveDuplicatesMax2Allowed(int[] nums)
        {
            var i = 0;

            foreach (var num in nums)
            {
                if (i < 2 || num != nums[i - 2])
                {
                    nums[i++] = num;
                }
            }

            return i;
        }
    }
}
