using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    //https://leetcode.com/problems/partition-labels/
    public class partition_label
    {
        public IList<int> PartitionLabels(string S)
        {
            var lastIndex = new int[26];

            for (int i = 0; i < S.Length; i++)
            {
                var ch = S[i];

                lastIndex[ch - 'a'] = i;
            }

            var startIndex = 0;
            var runningIndex = 0;
            var ans = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                runningIndex = System.Math.Max(runningIndex, lastIndex[S[i] - 'a']);

                if (runningIndex == i)
                {
                    ans.Add(runningIndex - startIndex + 1);
                    startIndex = i + 1;
                }
            }

            return ans;
        }
    }
}
