using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.DynamicPrograming
{
    class Coin_Denominations
    {
        /*
 * No of ways making 30 cents with {25,10, 5, 1} =
 * no of ways making 30 cents with {10, 5, 1} +
 * nof of ways making 5 cents with {5, 1}
 * 
 * https://leetcode.com/problems/coin-change/solution/
 */
        public int CalcWays(int cents, int[] denom, int index)
        {
            cnt++;
            int coin = denom[index];

            if (index == denom.Length - 1)
            {
                int rem = cents % coin;

                return rem == 0 ? 1 : 0;
            }

            int noOfWays = 0;

            for (int amt = 0; amt <= cents; amt += coin)
            {
                noOfWays += CalcWays(cents - amt, denom, index + 1);
            }
            return noOfWays;
        }

        public int CalcWays(int cents, int[] denom, int index, Dictionary<string, int> map)
        {
            cnt++;
            if (map.ContainsKey($"{cents}-{index}"))
            {
                return map[$"{cents}-{index}"];
            }

            int coin = denom[index];

            if (index == denom.Length - 1)
            {
                int rem = cents % coin;

                return rem == 0 ? 1 : 0;
            }

            int noOfWays = 0;

            for (int amt = 0; amt <= cents; amt += coin)
            {
                noOfWays += CalcWays(cents - amt, denom, index + 1, map);
            }

            map.Add($"{cents}-{index}", noOfWays);

            return noOfWays;
        }

        public int CalcWaysMem(int cents, int[] denom, int index, Dictionary<string, int> map)
        {            
            if (map.ContainsKey($"{cents}"))
            {
                return map[$"{cents}"];
            }

            cnt++; // This is just to find how many time rec function gets called

            int coin = denom[index];

            if (index == denom.Length - 1)
            {
                int rem = cents % coin;

                return rem == 0 ? 1 : 0;
            }

            int noOfWays = 0;

            for (int amt = 0; amt <= cents; amt += coin)
            {
                noOfWays += CalcWaysMem(cents - amt, denom, index + 1, map);
            }

            if(!map.ContainsKey($"{cents}"))
            {
                map.Add($"{cents}", noOfWays);
            }            

            return noOfWays;
        }
        private int cnt = 0;
        public int CalcWays(int cents)
        {
            var x = CalcWays(cents, new int[] { 3, 2, 1 }, 0);


            var a = CalcWays(cents, new int[] { 25, 10, 5, 1 }, 0);

            cnt = 0;

            var b = CalcWays(cents, new int[] { 25, 10, 5, 1 }, 0, new Dictionary<string, int>());

            cnt = 0;

            var c = CalcWaysMem(cents, new int[] { 25, 10, 5, 1 }, 0, new Dictionary<string, int>());

            return 0;
        }
    }

    public class Solution11
    {

        public int MinCoin(int[] denom, int amt)
        {
            int index = 0;
            int len = denom.Length;
            int count = 0;
            int currAmt = amt;
            while(index < len)
            {
                if(currAmt >= denom[index])
                {
                    currAmt = currAmt - denom[index];
                    count++;
                }
                else
                {
                    index++;
                }
            }

            if(currAmt == 0)
            {
                return count;
            }
            else
            {
                return -1;
            }
        }

        public int coinChange(int[] coins, int amount)
        {
            if (amount < 1) return 0;
            return coinChange(coins, amount, new int[amount]);
        }

        private int coinChange(int[] coins, int rem, int[] count)
        {
            if (rem < 0) return 0;
            if (rem == 0) return 1;
            
            int noOfWays = 0;
            foreach(var coin in coins)
            {
                noOfWays += coinChange(coins, rem - coin, count);                
            }

            return noOfWays;
        }
    }
}
