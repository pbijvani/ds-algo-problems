using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class matrix_row_col_sorted_find_ele
    {

        /*
         * you are given a maxrix
         * all rows are sorted in asc order
         * all cols are sorted in asc order
         * given a element, check if its available in matrix
         */

        public bool FindElement(int[,] matrix, int ele)
        {
            var lastRow = matrix.GetLength(0);
            var lastCol = matrix.GetLength(1);

            var currX = 0;
            var currY = lastCol - 1;

            while(currX < lastRow && currY >= 0)
            {
                while (currY >= 0 && matrix[currX, currY] > ele)
                {
                    currY--;
                }

                if (currY < 0) return false;

                if(matrix[currX, currY] == ele)
                {
                    return true;
                }

                currX++;

            }

            return false;            
        }

        public void Test()
        {
            var matrix = new int[4, 4] { { 15, 20, 40, 85 }, { 20, 35, 80, 95 }, { 30, 55, 95, 105 }, { 40, 80, 100, 120 } };

            var res = FindElement(matrix, 55);
        }
    }
}
