using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class best_time_to_buy_sell_stock_with_cooldown
    {
        /*
         * https://leetcode.com/submissions/detail/370834491/
         * Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
Example:

Input: [1,2,3,0,2]
Output: 3 
Explanation: transactions = [buy, sell, cooldown, buy, sell]

         */
        public int MaxProfit(int[] prices)
        {

            if (prices.Length <= 1) return 0;

            if (prices.Length == 2)
            {
                if (prices[0] < prices[1])
                {
                    return prices[1] - prices[0];
                }
                else
                {
                    return 0;
                }
            }
            var len = prices.Length;
            var dp = new int[len, 2];

            // 0 - no stock in hand
            // 1 = stock in hand

            dp[0, 0] = 0;
            dp[0, 1] = prices[0] * -1;

            dp[1, 0] = System.Math.Max(dp[0, 0], dp[0, 1] + prices[1]);
            dp[1, 1] = System.Math.Max(dp[0, 1], dp[0, 0] - prices[1]);

            for (int i = 2; i < len; i++)
            {
                dp[i, 0] = System.Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = System.Math.Max(dp[i - 1, 1], dp[i - 2, 0] - prices[i]);
            }

            return dp[len - 1, 0];

        }
        
    }
}
