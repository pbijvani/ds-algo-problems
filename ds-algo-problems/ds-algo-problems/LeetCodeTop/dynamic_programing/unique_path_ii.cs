using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    public class unique_path_ii
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1) return 0;

            var lenRow = obstacleGrid.Length;
            var lenCol = obstacleGrid[0].Length;

            
            if (obstacleGrid[lenRow - 1][lenCol - 1] == 1) return 0;

            for (int i = 0; i < lenRow; i++)
            {
                if(obstacleGrid[i][0] == 1)
                {
                    break;
                }
                obstacleGrid[i][0] = -1;
            }
            for (int j = 0; j < lenCol; j++)
            {
                if (obstacleGrid[0][j] == 1)
                {
                    break;
                }
                obstacleGrid[0][j] = -1;
            }

            for (int i = 1; i < lenRow; i++)
            {
                for (int j = 1; j < lenCol; j++)
                {
                    if (obstacleGrid[i][j] == 1) continue;
                    obstacleGrid[i][j] = (obstacleGrid[i][j - 1] == 1 ? 0 : obstacleGrid[i][j - 1]) + (obstacleGrid[i - 1][j] == 1 ? 0 : obstacleGrid[i - 1][j]);
                }
            }

            return obstacleGrid[lenRow - 1][lenCol - 1] * -1;
        }
    }
}
