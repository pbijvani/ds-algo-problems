using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class rotate_matrix
    {
        public void RotateMatrix(int[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");


            int n = matrix.GetLength(0);
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first, i];

                    matrix[first, i] = matrix[last - offset, first];
                    matrix[last - offset, first] = matrix[last, last - offset];
                    matrix[last, last - offset] = matrix[i, last];
                    matrix[i, last] = top;
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(matrix[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine(" ");
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
