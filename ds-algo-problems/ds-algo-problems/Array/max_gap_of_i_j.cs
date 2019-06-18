using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class max_gap_of_i_j
    {

        /*
        Given an array A of integers, find the maximum of j - i subjected to the constraint of A[i] <= A[j].
        If there is no solution possible, return -1.

        Example :

        A : [3 5 4 2]

        Output : 2 
        for the pair (3, 4) 
         */
        public int maximumGap(int[] input)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                map.Add(i, input[i]);
            }

            int minIndex = input.Length - 1;
            int diff = -1;

            foreach (var item in map.OrderBy(x => x.Value))
            {
                if (item.Key < minIndex)
                    minIndex = item.Key;

                if (diff < item.Key - minIndex)
                    diff = item.Key - minIndex;
            }
            return diff;
        }
    }
}
