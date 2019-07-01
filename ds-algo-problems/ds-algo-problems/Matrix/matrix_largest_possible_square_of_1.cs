using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class matrix_largest_possible_square_of_1
    {
        /*
         * you are given a matrix (n by m) and each element is 1 or 0.
         * calculate largest square haveing all 1s
         * 
         * Sol1 : this can be solved using recursion.
         * for each element go and check right, bottom and bottom-right element.
         * and repete this recursively for each element.
         * need to maintain state for each element so that we dont compute again.
         */
        public int CalculateLargestSquareSize(int[,] matrix)
        {
            int maxSqSize = 0;
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            var solutionMatrix = new int[m, n];

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0 || i - 1 < 0 || j - 1 < 0)
                    {
                        solutionMatrix[i, j] = 0;
                    }
                    else
                    {
                        var min = MinOf(solutionMatrix[i - 1, j - 1], solutionMatrix[i, j - 1], solutionMatrix[i - 1, j]);
                        int currCellSize = min + matrix[i, j];
                        solutionMatrix[i, j] = currCellSize;

                        maxSqSize = System.Math.Max(maxSqSize, currCellSize);
                    }
                }
            }
            return maxSqSize;
        }

        public int MinOf(int a, int b, int c)
        {
            var min = System.Math.Min(a, b);
            min = System.Math.Min(min, c);
            return min;
        }

    }
}
