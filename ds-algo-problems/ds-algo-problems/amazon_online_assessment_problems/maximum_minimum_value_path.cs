using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://aonecode.com/path-with-maximum-minimum-value-1
     * https://leetcode.com/discuss/interview-question/383669/
     * https://leetcode.com/problems/minimum-path-sum/
     
        Given a two 2D integer array, find the max score of a path from the upper left cell to bottom right cell. The score of a path is the minimum value in that path.

        Notice: the path can only right and down.

        For example:

        Input:

        [7,5,3]
        [2,0,9]
        [4,5,9]

        Here are some paths from [0,0] to [2,2] and the minimum value on each path:

        path: 7->2->4->5->9, minimum value on this path: 2

        path: 7->2->0->9->9, minimum value on this path: 0

        path: 7->2->0->5->9, minimum value on this path: 0

        In the end the max score(the min value) of all the paths is 3. 

        Output: 3

     */

    public class maximum_minimum_value_path
    {
        public int MaxMinPathVal(int[,] matrix)
        {
            var xLen = matrix.GetLength(0);
            var yLen = matrix.GetLength(1);

            var temp = new int[xLen,yLen];

            // Find min from first row and set that in temp array
            var firstRowMin = int.MaxValue;
            for(int i = 0; i < yLen; i++)
            {
                firstRowMin = System.Math.Min(firstRowMin, matrix[0,i]);
            }
            for (int i = 0; i < yLen; i++)
            {
                temp[0,i] = firstRowMin;
            }

            // Find min from first col (starting 2nd row) and assign to temp
            var firstColMin = int.MaxValue;
            for (int i = 1; i < xLen; i++)
            {
                firstColMin = System.Math.Min(firstColMin, matrix[i,0]);
            }
            for (int i = 1; i < xLen; i++)
            {
                temp[i, 0] = firstColMin;
            }

            for(int i = 1; i < xLen; i++)
            {
                for(int j = 1; j < yLen; j++)
                {
                    var opt1 = System.Math.Min(temp[i, j - 1], matrix[i,j]);
                    var opt2 = System.Math.Min(temp[i - 1, j], matrix[i,j]);
                    temp[i, j] = System.Math.Max(opt1, opt2);
                }
            }

            return temp[xLen - 1, yLen - 1];
        }

        public void test()
        {
            var matrix = new int[,] 
            {
                {7, 5, 3 },
                {2, 0, 9 },
                {4, 5, 9 }
            };

            var res = MaxMinPathVal(matrix);
        }
    }
}
