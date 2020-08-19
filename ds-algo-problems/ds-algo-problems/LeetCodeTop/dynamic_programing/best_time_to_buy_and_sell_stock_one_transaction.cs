using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        Say you have an array for which the ith element is the price of a given stock on day i.

        If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

        Note that you cannot sell a stock before you buy one.

        Example 1:

        Input: [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                     Not 7-1 = 6, as selling price needs to be larger than buying price.
        Example 2:

        Input: [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transaction is done, i.e. max profit = 0.     
     */
    public class best_time_to_buy_and_sell_stock_one_transaction
    {
        // Approach 1 : Brute Force
        // find all subarray. Buy at start of array and sell at end of array 
        // maintain max profit

        //Approach 1 : peak and vally
        /*
            Time complexity : O(n)O(n). Only a single pass is needed.

            Space complexity : O(1)O(1). Only two variables are used.         
         */
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0 || prices.Length == 1) return 0;

            var minPrice = prices[0];
            var maxProfit = 0;

            for(int i = 1; i < prices.Length; i++)
            {
                maxProfit = System.Math.Max(maxProfit, prices[i] - minPrice);
                if(prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
            }
            return maxProfit;
        }
    }
}
