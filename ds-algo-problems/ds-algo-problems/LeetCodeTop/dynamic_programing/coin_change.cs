using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    public class coin_change
    {

        /*
         * Approach 1 : Dynamic programmin - bottom up 
         * Time complexity - O(coins.size * total)
         * Space complexity - O(coins.size * total)
         * 
         * Below solution using 2d array for maintaining dp state
         * some test case are failing with below 2d arrary solution
         * https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/CoinChangingMinimumCoin.java
         */
        public int CoinChange(int[] coins, int amount)
        {
            var noOfCoins = coins.Length;

            var dp = new int[noOfCoins, amount + 1];

            //coins = coins.OrderBy(x => x).ToArray();

            for (int i = 0; i < noOfCoins; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    dp[i, j] = int.MaxValue - 1; // 
                }
            }

            for (int coinIndx = 0; coinIndx < noOfCoins; coinIndx++)
            {
                var coin = coins[coinIndx];

                for(int amt = 1; amt <= amount; amt++)
                {
                    if (amt >= coin)
                    {
                        var prev = coinIndx == 0 ? dp[coinIndx, amt] : dp[coinIndx - 1, amt];
                        var neww = dp[coinIndx, amt - coin] + 1;

                        if(neww <= prev)
                        {
                            dp[coinIndx, amt] = neww;
                        }                        
                    }
                    else
                    {
                        dp[coinIndx, amt] = coinIndx == 0 ? dp[coinIndx, amt] : dp[coinIndx - 1, amt];
                    }
                }
            }

            return dp[noOfCoins-1, amount] == int.MaxValue -1 ? -1 : dp[noOfCoins - 1, amount];

        }

        /*
         * DP - top down approach with memorization
         * https://leetcode.com/problems/coin-change/solution/
         */

        public int CoinChange2(int[] coins, int total)
        {
            var res = CoinChange2Helper(coins, total, new Dictionary<int, int>());

            return res;
        }

        public int CoinChange2Helper(int[] coins, int remaining, Dictionary<int, int> mem)
        {
            if (remaining < 0) return -1;

            if (remaining == 0) return 0;

            if (mem.ContainsKey(remaining)) return mem[remaining];

            var minNumberOfCoin = int.MaxValue;

            foreach(var coin in coins)
            {
                int res = CoinChange2Helper(coins, remaining - coin, mem);

                if(res >= 0 && res < minNumberOfCoin)
                {
                    minNumberOfCoin = 1 + res;
                }
            }

            mem.Add(remaining, minNumberOfCoin == int.MaxValue ? -1 : minNumberOfCoin);

            return mem[remaining];
        }

        /*
         * same as above, just instead of 2d array we are using 1d array
         * Time complexity - O(coins.size * total)
         * Space complexity - O(total)         
         */

        public int CoinChange1(int[] coins, int total)
        {
            var dp = new int[total + 1];
            dp[0] = 0;

            for (int i = 1; i <= total; i++)
            {
                dp[i] = int.MaxValue - 1;
            }
            for (int j = 0; j < coins.Length; j++)
            {
                for (int amt = 1; amt <= total; amt++)
                {
                    var currCoinVal = coins[j];

                    if (amt >= currCoinVal)
                    {
                        dp[amt] = System.Math.Min(dp[amt], dp[amt - currCoinVal] + 1);
                    }
                }
            }
            return dp[total];
        }

        public void test()
        {
            //var coins = new int[] { 186, 419, 83, 408 };

            //var amt = 6249;

            var coins = new int[] { 1, 3, 5 };

            var amt = 6;

            //var coins = new int[] { 1, 2, 5 };

            //var amt = 11;

            var res = CoinChange1(coins, amt);
        }
    }
}
