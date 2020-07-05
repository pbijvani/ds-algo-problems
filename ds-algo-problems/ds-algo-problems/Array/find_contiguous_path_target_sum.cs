using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class find_contiguous_path_target_sum
    {
        // Brutforce : with two loop and check for each subarray : O(n square)
        // O(N) : optimized solution.
        public int FindContiguousPathCount(int[] array, int targetSum)
        {
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1);

            int runningSum = 0;
            int result = 0;
            foreach (var item in array)
            {
                runningSum = runningSum + item;
                var sum = runningSum - targetSum;

                result = result + dict.GetOrDefault(sum, 0);

                if (dict.ContainsKey(runningSum))
                {
                    dict[runningSum] = dict[runningSum] + 1;
                }
                else
                {
                    dict.Add(runningSum, 1);
                }
            }

            return result;
        }

        public List<List<int>> FindContiguousPath(int[] array, int targetSum)
        {
            var dict = new Dictionary<int, List<int>>();
            var subArrayIndex = new List<Tuple<int, int>>();

            dict.Add(0, new List<int>() { -1 });

            int runningSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var item = array[i];

                runningSum = runningSum + item;
                var sum = runningSum - targetSum;

                if (dict.ContainsKey(sum))
                {
                    dict[sum].ForEach(x =>
                    {
                        subArrayIndex.Add(new Tuple<int, int>(x + 1, i));
                    });
                }


                if (dict.ContainsKey(runningSum))
                {
                    dict[runningSum].Add(i);
                }
                else
                {
                    dict.Add(runningSum, new List<int>() { i });
                }
            }

            var res = new List<List<int>>();
            foreach (var indx in subArrayIndex)
            {
                var arr = new List<int>();
                for (int i = indx.Item1; i <= indx.Item2; i++)
                {
                    arr.Add(array[i]);
                }
                res.Add(arr);
            }

            return res;
        }
    }
}
