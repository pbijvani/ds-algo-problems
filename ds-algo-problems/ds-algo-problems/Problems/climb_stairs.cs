using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class climb_stairs
    {
        public int MaxSteps(int n)
        {
            return MoveSteps(0, n);
        }

        // Move steps 1 and 2 recursive
        public int MoveSteps(int curr, int dest)
        {
            if (curr > dest) return 0;
            if (curr == dest) return 1;

            return MoveSteps(curr + 1, dest) + MoveSteps(curr + 2, dest);
        }
        //Move steps 1 and 2 iterative
        public int climbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        // Move given steps recursive
        public int MoveSteps(int curr, int[] steps, int dest)
        {
            if (curr == dest) return 1;
            if (curr > dest) return 0;

            int cnt = 0;
            for (int i = 0; i < steps.Length; i++)
            {
                cnt += MoveSteps(curr + steps[i], steps, dest);
            }
            return cnt;
        }
        //Move given steps iterative
        public int MoveSteps(int n, int[] steps)
        {
            if (n == 1) return 1;
            int[] res = new int[n + 1];
            res[0] = 0;
            res[1] = 1;
            res[2] = 2;

            int sum = 0;
            for (int i = 3; i <= n; i++)
            {
                for (int j = 0; j < steps.Length; j++)
                {
                    if (i - steps[j] >= 0) res[i] = res[i] + res[i - steps[j]];
                }
            }
            return res[n];
        }
    }
}
