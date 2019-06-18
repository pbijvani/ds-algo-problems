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
 */
        public int CalcWays(int cents, int[] denom, int index)
        {
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

        public int CalcWays(int cents)
        {
            var a = CalcWays(cents, new int[] { 25, 10, 5, 1 }, 0);

            var b = CalcWays(cents, new int[] { 25, 10, 5, 1 }, 0, new Dictionary<string, int>());

            return 0;
        }
    }
}
