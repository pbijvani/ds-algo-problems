﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class ways_to_decode_message
    {
        /*
         * https://www.youtube.com/watch?v=qli-JCrSwuk&list=PLBZBJbE_rGRVnpitdvpdY9952IsKMDuev&index=1
         */
        public int decode(string num)
        {
            var len = num.Length;
            int?[] memo = new int?[len+1];
            var retVal = NoOfWays(num, len, memo);

            return retVal;
        }
        /*
         * at each element we have two choice
         * grap 1 element and recurse for remaining
         * grab 2 element (conditinoal) and recurse remaining
         * 
         * we need to user memorization
         */
        public int NoOfWays(string num, int k, int?[] memo)
        {
            if (k == 0) return 1;            

            int s = num.Length - k;

            if (num[s] == '0') return 0;

            if (memo[k] != null) return memo[k].Value;

            var result = NoOfWays(num, k - 1, memo);

            if(k > 1 && Convert.ToInt32(num.Substring(s, 2)) <= 26)
            {
                result = result + NoOfWays(num, k - 2, memo);
            }

            memo[k] = result;

            return result;
        }

        public int num_ways(string data)
        {
            var memo = new int[data.Length];

            for(int i = 0; i < data.Length; i++)
            {
                memo[i] = -1;
            }

            return helper(data, data.Length, memo);
        }

        public int helper(string data, int k, int[] memo)
        {
            if (k == 0) return 1;

            var startIndex = data.Length - k;

            if (data[startIndex] == '0') return 0;

            if (memo[k] != -1) return memo[k];

            var result = helper(data, k - 1, memo);

            if(k >= 2 && Convert.ToInt32(data.Substring(startIndex, 2)) <= 26)
            {
                result = result + helper(data, k - 1, memo);
            }

            memo[k] = result;

            return result;
        }
    }
}
