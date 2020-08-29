using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.greedy_backtracking
{
    /*
        Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

        Each number in candidates may only be used once in the combination.

        Note:

        All numbers (including target) will be positive integers.
        The solution set must not contain duplicate combinations.
        Example 1:

        Input: candidates = [10,1,2,7,6,1,5], target = 8,
        A solution set is:
        [
          [1, 7],
          [1, 2, 5],
          [2, 6],
          [1, 1, 6]
        ]
        Example 2:

        Input: candidates = [2,5,2,1,2], target = 5,
        A solution set is:
        [
          [1,2,2],
          [5]
        ]    
        
        https://leetcode.com/problems/combination-sum-ii/

     */
    public class combination_sum_ii
    {
        //public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        //{
        //    candidates = candidates.OrderBy(x => x).ToArray();

        //    var result = new List<IList<int>>();
        //    var subSet = new List<IList<int>>();
        //    var subSetSum = new List<int>();

        //    var set = new HashSet<int>();

        //    subSet.Add(new List<int>());
        //    subSetSum.Add(0);

        //    foreach (var candidate in candidates)
        //    {
        //        var newSet = new List<IList<int>>();
        //        var newSetSum = new List<int>();

        //        for (int i = 0; i < subSet.Count; i++)
        //        {
        //            if(set.Contains(candidate))
        //            {                        
        //                if(!subSet[i].Any()) continue;

        //                if (subSet[i].Last() != candidate) continue;
        //            }
        //            if (subSetSum[i] + candidate <= target)
        //            {
        //                newSetSum.Add(subSetSum[i] + candidate);

        //                var newList = new List<int>(subSet[i]);
        //                newList.Add(candidate);

        //                newSet.Add(newList);
        //            }
        //        }

        //        set.Add(candidate);

        //        for(int i = 0; i < newSet.Count; i++)
        //        {
        //            subSet.Add(newSet[i]);
        //            subSetSum.Add(newSetSum[i]);
        //        }
        //    }

        //    for(int i = 0; i < subSetSum.Count; i++)
        //    {
        //        if(subSetSum[i] == target)
        //        {
        //            result.Add(subSet[i]);
        //        }
        //    }
        //    return result;
        //}

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {

            candidates = candidates.OrderBy(x => x).ToArray();

            var res = new List<IList<int>>();

            helper(candidates, target, 0, new List<int>(), res);

            return res;
        }

        public void helper(int[] candidate, int target, int index, List<int> current, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            if (target < 0) return;

            for (int i = index; i < candidate.Length; i++)
            {
                if (i == index || candidate[i] != candidate[i - 1])
                {
                    current.Add(candidate[i]);
                    helper(candidate, target - candidate[i], i + 1, current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }

        }

        public void test()
        {
            var nums = new int[] { 2, 5, 2, 1, 2 };

            var res = CombinationSum2(nums, 5);
        }
    }
}
