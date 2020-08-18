using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.HashMap
{
    /*
        A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

        The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

        How many possible unique paths are there?

        Example 1:

        Input: m = 3, n = 2
        Output: 3
        Explanation:
        From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
        1. Right -> Right -> Down
        2. Right -> Down -> Right
        3. Down -> Right -> Right

        https://leetcode.com/problems/unique-paths/

     */
    public class unique_path
    {
        // Time and space : O(m*n)
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];

            for(int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for(int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }

            return dp[m - 1, n - 1];
        }

        // Optimazation : we can have constant space by just using two rows. we dont need any previous rows
        public int UniquePathsOptimazed(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            var dp = new int[2, n];

            for (int i = 0; i < 2; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }
            var currRow = 1;
            var prevRow = 0;
            for (int i = 1; i < m; i++)
            {
                currRow = i % 2;
                prevRow = (i - 1) % 2;
                for (int j = 1; j < n; j++)
                {
                    dp[currRow, j] = dp[currRow, j - 1] + dp[prevRow, j];
                }
            }

            return dp[currRow, n - 1];
        }
    }
}
