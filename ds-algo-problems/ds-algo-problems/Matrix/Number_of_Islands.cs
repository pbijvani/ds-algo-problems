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
        private bool[,] visitedCells;
        public int noOfIslands = 0;
        public int NumberOfIslands(int[,] input)
        {
            var rows = input.GetLength(0);
            var cols = input.GetLength(1);

            visitedCells = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (input[i, j] == 1 && !visitedCells[i, j])
                    {
                        VisitNearbyLand(input, i, j);
                        noOfIslands++;
                    }
                }
            }
            return 0;
        }

        public void VisitNearbyLand(int[,] array, int row, int col)
        {
            if (row < 0 || row >= array.GetLength(0)) return;
            if (col < 0 || col >= array.GetLength(1)) return;

            if (visitedCells[row, col]) return;
            visitedCells[row, col] = true;

            VisitNearbyLand(array, row, col + 1);
            VisitNearbyLand(array, row, col - 1);
            VisitNearbyLand(array, row + 1, col);
            VisitNearbyLand(array, row - 1, col);
        }

    }
}
