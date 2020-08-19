using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        Say you have an array prices for which the ith element is the price of a given stock on day i.

        Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).

        Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

        Example 1:

        Input: [7,1,5,3,6,4]
        Output: 7
        Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
                     Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
        Example 2:

        Input: [1,2,3,4,5]
        Output: 4
        Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
                     Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
                     engaging multiple transactions at the same time. You must sell before buying again.
        Example 3:

        Input: [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transaction is done, i.e. max profit = 0.    

        https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
     */
    public class best_time_to_buy_and_sell_stock
    {
        /*
            Time complexity : O(n)O(n). Single pass.

            Space complexity : O(1)O(1). Constant space required.         
         */
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1) return 0;
            if (prices.Length == 2 && prices[0] >= prices[1]) return 0;

            var len = prices.Length;

            int i = 0;
            int maxProfit = 0;
            int vally = prices[0];
            int peak = prices[0];
            while(i < len - 1)
            {
                while(i < len - 1 && prices[i] >= prices[i+1])
                {
                    i++;
                }

                vally = prices[i];

                while(i < len - 1 && prices[i] <= prices[i+1])
                {
                    i++;
                }

                peak = prices[i];
                maxProfit = maxProfit + (peak - vally);
            }
            return maxProfit;
        }

        /*
            Time complexity : O(n)O(n). Single pass.

            Space complexity : O(1)O(1). Constant space required.         
         */
        public int MaxProfit1(int[] prices)
        {
            if (prices.Length <= 1) return 0;
            if (prices.Length == 2 && prices[0] >= prices[1]) return 0;

            var len = prices.Length;

            int profit = 0;

            for(int i = 1; i < len; i++)
            {
                if(prices[i] > prices[i-1])
                {
                    profit = profit + (prices[i] - prices[i - 1]);
                }
            }
            return profit;
        }


        /*
         * Dynamic programming implementation
         * Takes O(N) time and O(N) spaces
         */
        public int MaxProfit2(int[] prices)
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
                dp[i, 1] = System.Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }

            return dp[len - 1, 0];
        }
    }
}
