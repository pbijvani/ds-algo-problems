using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    public class matrix_min_cost_path
    {
        /*
         * you are given a 2D matrix
         * you need to reach from top-left to bottom-right
         * you can move only right or down from any cell
         * value of each cell represents the cost of moving to that cell.
         * find path with  min value
         */

        public int minCost = int.MaxValue;
        public int MinCost(int[,] matrix)
        {
            helper(matrix, 0, 0, 0, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);

            return minCost;
        }

        // Recursioni without memorization
        public void helper(int[,] matrix, int cost, int x, int y, int destX, int destY)
        {
            if(x == destX && y == destY)
            {
                var finalCost = cost + matrix[x, y];
                minCost = System.Math.Min(minCost, finalCost);
                return;
            }

            if(x + 1 < matrix.GetLength(0) && cost + matrix[x, y] < minCost)
            {
                helper(matrix, cost + matrix[x, y], x + 1, y, destX, destY);
            }

            if (y + 1 < matrix.GetLength(1) && cost + matrix[x, y] < minCost)
            {
                helper(matrix, cost + matrix[x, y], x, y+1, destX, destY);
            }
        }

        public void Test()
        {
            var matrix = new int[,] 
            {
                { 1, 3, 5, 8},
                { 4, 2, 1, 7},
                { 4, 3, 2, 3}
            };

            MinCostMem(matrix);
        }

        public void MinCostMem(int[,] matrix)
        {
            var lenX = matrix.GetLength(0);
            var lenY = matrix.GetLength(1);

            var mem = new int[lenX, lenY];

            var res = minCostRec(matrix, lenX - 1, lenY - 1, 0, 0, mem);


        }
        // recursion with memorization
        public int minCostRec(int[,] cost, int m, int n, int x, int y, int[,] mem)
        {            
            if (x > m || y > n)
            {
                return int.MaxValue;
            }

            if (mem[x, y] != 0) return mem[x, y];

            if (x == m && y == n)
            {                
                return cost[m,n];
            }

            int t1 = minCostRec(cost, m, n, x + 1, y, mem);            
            int t2 = minCostRec(cost, m, n, x, y + 1, mem);

            var minCost = cost[x, y] + System.Math.Min(t1, t2);

            mem[x, y] = minCost;

            return minCost;
        }

        // Iterative Solution
        
        public int MinCostIterative(int[,] cost)
        {
            int lenX = cost.GetLength(0);
            int lenY = cost.GetLength(1);

            var temp = new int[lenX, lenY];

            int sum = 0;

            for(int i = 0; i < lenX; i++)
            {
                temp[i, 0] = sum + cost[i, 0];
                sum = temp[i, 0];
            }
            sum = 0;

            for(int i = 0; i< lenY; i++)
            {
                temp[0, i] = sum + cost[0, i];
                sum = temp[0, i];
            }

            for(int i = 1; i < lenX; i++)
            {
                for(int j = 1; j < lenY; j++)
                {
                    temp[i, j] = cost[i,j] + System.Math.Min(temp[i - 1, j], temp[i, j - 1]);
                }
            }

            return temp[lenX - 1, lenY - 1];
        }
    }
}
