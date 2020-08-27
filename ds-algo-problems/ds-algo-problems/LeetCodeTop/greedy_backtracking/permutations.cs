using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.greedy_backtracking
{
    public class permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var res = new List<IList<int>>();

            PermuteHelper(nums, res, 0);

            return res;
        }


        public void PermuteHelper(int[] nums, List<IList<int>> result, int start)
        {
            if (start == nums.Length)
            {
                result.Add(new List<int>(nums));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                Swap(ref nums[i], ref nums[start]);
                PermuteHelper(nums, result, start + 1);
                Swap(ref nums[i], ref nums[start]);
            }
        }

        public void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public void test()
        {
            var res = Permute(new int[] { 1, 2, 3 });
        }
    }
}
