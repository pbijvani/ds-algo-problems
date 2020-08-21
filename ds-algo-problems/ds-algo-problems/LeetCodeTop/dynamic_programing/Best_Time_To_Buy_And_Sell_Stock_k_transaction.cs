using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    public class Best_Time_To_Buy_And_Sell_Stock_k_transaction
    {
        /*
         * https://www.youtube.com/watch?v=oDhu5uGq_ic
         * 
         * https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
         * 
         * Space and time : O(day * transaction)
         */
        public int BestProfit(int[] prices, int k)
        {
            if (k == 0) return 0;
            var len = prices.Length;

            if (len <= 1) return 0;

            var dt = new int[k + 1, len];
            int maxDiff = int.MinValue;
            for (int t = 1; t <= k; t++)
            {
                maxDiff = prices[0] * -1;
                for (int d = 1; d < len; d++)
                {
                    dt[t, d] = System.Math.Max(dt[t, d - 1], maxDiff + prices[d]);

                    maxDiff = System.Math.Max(maxDiff, dt[t - 1, d] - prices[d]);
                }
            }

            return dt[k, len - 1];
        }
    }
}
