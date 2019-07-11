using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class Best_Time_To_Buy_And_Sell_Stock
    {
        /// <summary>
        /// Best Time to Buy and Sell Stock II
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        /// Design an algorithm to find the maximum profit. 
        /// You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxStockProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProf = 0;

            foreach(var price in prices)
            {
                if(price < minPrice)
                {
                    minPrice = price;
                }
                else if(price - minPrice > maxProf)
                {
                    maxProf = price - minPrice;
                }
            }
            return maxProf;
        }
        /// <summary>
        /// Same as above. But we can make only two transactions
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxStockProfitTwoTransactionOnly(int[] prices)
        {
            List<int> stockAppretiation = new List<int>();

            int runningMaxProfit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                {
                    runningMaxProfit += prices[i + 1] - prices[i];
                }
                else
                {
                    stockAppretiation.Add(runningMaxProfit);
                    runningMaxProfit = 0;
                }
                if (i == prices.Length - 2 && runningMaxProfit > 0)
                {
                    stockAppretiation.Add(runningMaxProfit);
                }
            }
            return stockAppretiation.OrderByDescending(x => x).Take(2).Sum();
        }
        // Note : above sol has problem. Refer below to get right sol
        //https://miafish.wordpress.com//?s=stock&search=Go
    }
}
