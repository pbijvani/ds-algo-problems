using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Contiguous_Binary_Array_With_equal_0_1
    {
        /// <summary>
        /// Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
        /// Input: [0,1,0]
        ///Output: 2
        ///Explanation: [0, 1] (or[1, 0]) is a longest contiguous subarray with equal number of 0 and 1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int findMaxLength(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 1 ? 1 : -1);
                if (map.ContainsKey(count))
                {
                    maxlen = System.Math.Max(maxlen, i - map[count]);
                }
                else
                {
                    map.Add(count, i);
                }
            }
            return maxlen;
        }
    }
}
