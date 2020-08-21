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


        /*
         * Approach mentioned https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/solution/
         * 
         * Complexity

Time Complexity: \mathcal{O}(nk)O(nk) if 2k \le n2k≤n , \mathcal{O}(n)O(n) if 2k > n2k>n, where nn is the length of the prices sequence, since we have two for-loop.

Space Complexity: \mathcal{O}(nk)O(nk) without state-compressed, and \mathcal{O}(k)O(k) with state-compressed, where nn is the length of the prices sequence.
         */
        public int BestProfit1(int[] prices, int k)
        {
            var n = prices.Length;

            if (k < 0 || n < 2) return 0;

            // 2k > n is a special case and can be addressed easily
            if(2 * k > n)
            {
                int result = 0;

                for(int i = 1; i < n; i++)
                {
                    result = result + System.Math.Max(0, prices[i] - prices[i - 1]);
                }

                return result;
            }

            // Initialize dp array
            // dp[price, transaction, buy/sell (hold/nohold)]
            // 0 = no hold
            // 1 = hold
            var dp = new int[n,k + 1,2];

            // Initialize array
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j <= k; k++)
                {
                    dp[i, j, 0] = int.MinValue;
                    dp[i, j, 1] = int.MinValue;
                }
            }

            // Base case
            dp[0, 0, 0] = 0; // First day not holding anything
            dp[0, 0, 0] = prices[0] * -1; // bought share on first day

            // Dynamic Programming 
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; k++)
                {
                    // not holding stock, 
                    // Max of (value at prev day, sold today which you were holding prev day)
                    dp[i, j, 0] = System.Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);

                    if(j > 0) // // you can't hold stock without any transaction
                    {
                        // holding stock
                        // max of (value at prev day, bought today so price from last transaction any prv day minus price you paid today
                        dp[i, j, 1] = System.Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                    }
                }
            }

            int res = 0;
            for(int i = 0; i <= k; i++)
            {
                res = System.Math.Max(res, dp[n - 1, i, 0]);
            }

            return 0;
        }

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
