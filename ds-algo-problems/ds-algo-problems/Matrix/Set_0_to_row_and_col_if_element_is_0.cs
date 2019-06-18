using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class Set_0_to_row_and_col_if_element_is_0
    {
        public void SetMatrixZero(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            int row = -1;
            int col = -1;
            int ii = 0;
            while (ii < rows.Count)
            {
                row = rows[ii];
                col = cols[ii];

                int j = 0;
                while (j < matrix.GetLength(0))
                {
                    matrix[row, j] = 0;
                    matrix[j, col] = 0;

                    j++;
                }
                ii++;
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

        }
    }
}
