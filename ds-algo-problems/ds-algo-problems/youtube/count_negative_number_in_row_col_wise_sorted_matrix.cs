using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class count_negative_number_in_row_col_wise_sorted_matrix
    {
        /*
         * -3, -2, -2, 1
         * -2,  3,  3, 4
         *  5,  6,  7, 8
         */

        public int CountNegativeNumbers(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            int negNumCount = 0;

            int i = 0;
            int j = m - 1;
            while(i < n)
            {
                while(j >=0)
                {
                    if(matrix[i, j] < 0)
                    {
                        negNumCount += j + 1;                        
                        break;
                    }
                    else
                    {
                        j--;
                    }
                }
                i++;
            }

            return negNumCount;
        }

    }
}
