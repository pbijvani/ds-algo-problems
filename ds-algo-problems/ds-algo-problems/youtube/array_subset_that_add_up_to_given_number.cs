using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class array_subset_that_add_up_to_given_number
    {
        /*
         * you are given an array of int and a number
         * [2,4,6,10] and 16
         * find a subset that add up to 16
         * Ans: {2,4,10} {6,10}
         */

        public int FindSubset(int[] array, int sum)
        {
            //return FindSet(array, 0, sum, 0);
            return rec(array, sum, array.Length - 1, new Dictionary<string, int>());
        }

        public int FindSet(int[] array, int runningSum, int sum, int k)
        {
            if (runningSum == sum) return 1;
            if(k == array.Length)
            {
                return 0;
            }

            return FindSet(array, runningSum, sum, k + 1) 
                + FindSet(array, runningSum + array[k], sum, k + 1);
        }

        public int rec(int[] array, int total, int i, Dictionary<string, int> mem)
        {
            var key = $"{total}:{i}";
            if(mem.ContainsKey(key))
            {
                return mem[key];
            }

            if (total == 0)
            {
                return 1;
            }
            else if (total < 0)
            {
                return 0;
            }
            else if (i < 0)
            {
                return 0;
            }
            else if (total < array[i])
            {
                var ret = rec(array, total, i - 1, mem);
                mem.Add(key, ret);
                return ret;
            }
            else
            {
                var ret = rec(array, total, i - 1, mem) + rec(array, total - array[i], i - 1, mem);
                mem.Add(key, ret);
                return ret;
            }
        }
    }
}










