using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        Say you have an array for which the ith element is the price of a given stock on day i.

        Design an algorithm to find the maximum profit. You may complete at most two transactions.

        Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

        Example 1:

        Input: [3,3,5,0,0,3,1,4]
        Output: 6
        Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
                     Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
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

        https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/

     */
    public class best_time_to_buy_and_sell_stock_max_two_transaction
    {
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

            var firstSell = 0;
            var firstBuy = prices[0] * -1;

            var secondSell = 0;
            var seconfBuy = int.MinValue;
            // 0 - no stock in hand
            // 1 = stock in hand

            for (int i = 1; i < len; i++)
            {
                firstSell = System.Math.Max(firstSell, firstBuy + prices[i]);
                firstBuy = System.Math.Max(firstBuy, -1 * prices[i]);

                seconfBuy = System.Math.Max(seconfBuy, firstSell - prices[i]);
                secondSell = System.Math.Max(secondSell, seconfBuy + prices[i]);

            }

            return secondSell;
        }

        // another approach

        public int MaxProfit2(int[] prices)
        {
            var maxProfitFor2Transactions = 0;
            var leftMaxProfit = maxProfitFromBegin(prices);
            var rightMaxProfit = maxProfitFromEnd(prices);

            for (int i = 0; i < prices.Length; i++)
            {
                var left = leftMaxProfit[i];
                var right = rightMaxProfit[i];
                maxProfitFor2Transactions = System.Math.Max(maxProfitFor2Transactions, left + right);
            }

            return maxProfitFor2Transactions;
        }

        public int[] maxProfitFromBegin(int[] prices)
        {
            var maxProfit = new int[prices.Length + 1];
            var minPrice = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                minPrice = System.Math.Min(minPrice, prices[i]);
                maxProfit[i + 1] = System.Math.Max(maxProfit[i], prices[i] - minPrice);
            }
            return maxProfit;
        }
        public int[] maxProfitFromEnd(int[] prices)
        {
            var maxProfit = new int[prices.Length + 1];
            var maxPrice = int.MinValue;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                maxPrice = System.Math.Max(maxPrice, prices[i]);
                maxProfit[i] = System.Math.Max(maxProfit[i + 1], maxPrice - prices[i]);
            }

            return maxProfit;
        }
    }
}
