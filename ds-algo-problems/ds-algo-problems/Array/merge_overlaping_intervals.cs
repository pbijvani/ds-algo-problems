using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class merge_overlaping_intervals
    {
        public void TestMergeOverlapingIntervals()
        {
            var input = new List<List<int>>()
            {
                new List<int>(){ 1, 3 },
                new List<int>(){ 4, 6 },
                new List<int>(){ 7, 10 },
                new List<int>(){ 9, 18 }
            };

            var res = MergeOverlapingIntervals(input);

        }
        public List<List<int>> MergeOverlapingIntervals(List<List<int>> input)
        {
            int len = input.Count;
            int i = 0;

            while (i < input.Count - 1)
            {
                if (input[i].Last() < input[i + 1].First())
                    i++;
                else
                {
                    input[i][1] = input[i + 1][1];
                    input.RemoveAt(i + 1);
                }

            }

            return input;
        }

    }
}
