using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class No_of_Islands
    {
        /// <summary>
        /// Number of Islands
        /// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
        /// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
        /// You may assume all four edges of the grid are all surrounded by water
        /// </summary>

        public int NumberOfIslands(int[,] input)
        {
            var rows = input.GetLength(0);
            var cols = input.GetLength(1);

            int islandCount = 0;

            var visitedCells = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (input[i, j] == 1 && !visitedCells[i, j])
                    {
                        VisitNearbyLand(input, i, j, visitedCells);
                        islandCount++;
                    }
                }
            }
            return 0;
        }

        int[] dirX = new int[4] { 1, -1, 0, 0 };
        int[] dirY = new int[4] { 0, 0, 1, -1 };
        public void VisitNearbyLand(int[,] input, int row, int col, bool[,] visisted)
        {
            visisted[row, col] = true;

            for (int i = 0; i < dirX.Length; i++)
            {
                var newX = row + dirX[i];
                var newY = col + dirY[i];

                if (newX < 0 || newY < 0 || newX >= input.GetLength(0) || newY >= input.GetLength(1))
                    continue;

                if (visisted[newX, newY])
                    continue;

                if (input[newX, newY] == 0)
                    continue;

                VisitNearbyLand(input, newX, newY, visisted);
            }
        }

        public void test()
        {
            var matrix = new int[,]
            {
                { 1, 1, 0, 1, 1 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 1 }
            };

            var cnt = NumberOfIslands(matrix);
        }

    }
}
