using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    public class flood_fill
    {
        /*
         * An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).

Given a coordinate (sr, sc) representing the starting pixel (row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.

To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on. Replace the color of all of the aforementioned pixels with the newColor.

At the end, return the modified image.

            Example 1:
Input: 
image = [[1,1,1],[1,1,0],[1,0,1]]
sr = 1, sc = 1, newColor = 2
Output: [[2,2,2],[2,2,0],[2,0,1]]
Explanation: 
From the center of the image (with position (sr, sc) = (1, 1)), all pixels connected 
by a path of the same color as the starting pixel are colored with the new color.
Note the bottom corner is not colored 2, because it is not 4-directionally connected
to the starting pixel.
         */
        public int[,] FloodFill(int[,] matrix, int sr, int sc, int newColor)
        {
            var srcColor = matrix[sr, sc];

            if (srcColor == newColor) return matrix;

            FillDFS(matrix, sr, sc, srcColor, newColor);

            return matrix;
        }

        public void FillDFS(int[,] matrix, int row, int col, int srcColor, int newColor)
        {
            if (matrix[row, col] != srcColor) return;

            matrix[row, col] = newColor;

            int[] directionRow = new int[] { -1, 1, 0, 0 };
            int[] directionCol = new int[] { 0, 0, 1, -1 };

            for(int i = 0; i < directionCol.Length; i++)
            {
                var newRow = row + directionRow[i];
                var newCol = col + directionCol[i];

                if (newRow < 0 || newRow >= matrix.GetLength(0)) continue;
                if (newCol < 0 || newCol >= matrix.GetLength(1)) continue;

                FillDFS(matrix, newRow, newCol, srcColor, newColor);
            }            
        }
    }
}
