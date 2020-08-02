using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Graph_Matrix
{
    public class max_area_of_island
    {
        /*
            Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

            Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

            Example 1:

            [[0,0,1,0,0,0,0,1,0,0,0,0,0],
             [0,0,0,0,0,0,0,1,1,1,0,0,0],
             [0,1,1,0,1,0,0,0,0,0,0,0,0],
             [0,1,0,0,1,1,0,0,1,0,1,0,0],
             [0,1,0,0,1,1,0,0,1,1,1,0,0],
             [0,0,0,0,0,0,0,0,0,0,1,0,0],
             [0,0,0,0,0,0,0,1,1,1,0,0,0],
             [0,0,0,0,0,0,0,1,1,0,0,0,0]]
            Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
            Example 2:

            [[0,0,0,0,0,0,0,0]]
            Given the above grid, return 0.       
            
            https://leetcode.com/problems/max-area-of-island/
         */

        public int MaxArea(int[,] island)
        {
            var lenX = island.GetLength(0);
            var lenY = island.GetLength(1);

            var maxArea = 0;

            var visitedCells = new bool[lenX, lenY];

            for(int i = 0; i < lenX; i++)
            {
                for(int j = 0; j < lenY; j++)
                {
                    if(island[i, j] == 1 && !visitedCells[i, j])
                    {
                        var area = VisitNeighbouringCells(island, visitedCells, i, j);

                        maxArea = System.Math.Max(maxArea, area);
                    }
                }
            }
            return maxArea;
        }

        int[] dirX = new int[4] { 1, -1, 0, 0 };
        int[] dirY = new int[4] { 0, 0, 1, -1 };
        public int VisitNeighbouringCells(int[,] input, bool[,] visited, int row, int col)
        {
            visited[row, col] = true;

            var area = 0;
            for(int i = 0; i < dirX.Length; i++)
            {
                var newX = row + dirX[i];
                var newY = col + dirY[i];

                if (newX < 0 || newY < 0 || newX >= input.GetLength(0) || newY >= input.GetLength(1))
                    continue;

                if (visited[newX, newY])
                    continue;

                if (input[newX, newY] == 0)
                    continue;

                area = area + VisitNeighbouringCells(input, visited, newX, newY);
            }

            return area + 1;
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

            var cnt = MaxArea(matrix);
        }
    }
}
