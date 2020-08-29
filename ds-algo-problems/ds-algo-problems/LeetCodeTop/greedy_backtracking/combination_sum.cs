using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.greedy_backtracking
{
    /*
        Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

        The same repeated number may be chosen from candidates unlimited number of times.

        Note:

        All numbers (including target) will be positive integers.
        The solution set must not contain duplicate combinations.
        Example 1:

        Input: candidates = [2,3,6,7], target = 7,
        A solution set is:
        [
          [7],
          [2,2,3]
        ]
        Example 2:

        Input: candidates = [2,3,5], target = 8,
        A solution set is:
        [
          [2,2,2,2],
          [2,3,3],
          [3,5]
        ]     

        https://leetcode.com/problems/combination-sum/
     */
    public class combination_sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            CombinationSumHelper(candidates, new List<int>(), target, 0, res);

            return res;
        }

        public void CombinationSumHelper(int[] candidates, List<int> list, int remaining, int index, List<IList<int>> result)
        {
            if(remaining == 0)
            {
                result.Add(new List<int>(list));
                return;
            }

            if(remaining < 0)
            {
                return;
            }

            for(int i = index; i < candidates.Length; i++)
            {
                if(remaining - candidates[i] >= 0)
                {
                    list.Add(candidates[i]);
                    CombinationSumHelper(candidates, list, remaining - candidates[i], i, result);
                    list.Remove(candidates[i]);
                }
            }
        }

        public void test()
        {
            var res = CombinationSum(new int[] { 2, 3, 5 }, 8);
        }
    }
}
