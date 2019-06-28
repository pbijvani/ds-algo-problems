using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Matrix
{
    public class pond_size
    {
        // 2d matrix...
        // 0 represents water.
        // pond is connected 0s horizontally, vertically and diagonally
        // find ponds with its size

        public int[] PondSize(int[,] pond)
        {
            int size = pond.GetLength(0);

            var visited = new bool[size, size];
            List<int> pondSizes = new List<int>();
            
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (visited[i, j] || pond[i, j] != 0) continue;

                    var pondSize = MatrixDFS(pond, i, j, visited);
                    pondSizes.Add(pondSize);

                    visited[i, j] = true;
                }
            }

            return pondSizes.ToArray();
        }

        int[] dirX = new int[8] { 0, 0, 1, -1, 1, 1, -1, -1 };
        int[] dirY = new int[8] { 1, -1, 0, 0, 1, -1, 1, -1 };

        public int MatrixDFS(int[,] pond, int i, int j, bool[,] visited)
        {            
            if (i < 0 || j < 0 || i == pond.GetLength(0) || j == pond.GetLength(0)) return 0;

            if (visited[i, j]) return 0;

            if (pond[i, j] != 0) return 0;

            visited[i, j] = true;

            int size = 1;
            for(int cnt = 0; cnt < 8; cnt++)
            {                
                size += MatrixDFS(pond, i + dirX[cnt], j + dirY[cnt], visited);
            }
            return size;
        }
    }
}
