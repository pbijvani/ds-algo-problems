using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class shortest_bridge
    {
        /*
 *In a given 2D binary array A, there are two islands.  
 * (An island is a 4-directionally connected group of 1s not connected to any other 1s.)
Now, we may change 0s to 1s so as to connect the two islands together to form 1 island.
Return the smallest number of 0s that must be flipped.  (It is guaranteed that the answer is at least 1.)

Input: [[0,1,0],[0,0,0],[0,0,1]]
Output: 2
*/

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        public void ShortestBridgeMethod()
        {
            int[,] matrix = new int[3, 3] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };

            var r = matrix.GetLength(0);
            var c = matrix.GetLength(1);
            bool[,] visited = new bool[r, c];

            bool foundFirstIsland = false;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        MatrixDFS(matrix, i, j);
                        foundFirstIsland = true;
                        break;
                    }
                    if (foundFirstIsland) break;
                }
            }

            while (queue.Any())
            {
                var node = queue.Dequeue();

                DiscoverIsland(matrix, node.Item1, node.Item2);
                nodesLeftInIteration--;

                if (foundIsland) break;

                if (nodesLeftInIteration == 0)
                {
                    nodesLeftInIteration = nodesInNextIteration;
                    steps++;
                }
            }

        }
        int steps = 0;
        bool foundIsland = false;
        public void DiscoverIsland(int[,] matrix, int row, int col)
        {


            if (foundIsland) return;

            if (matrix[row, col] == 0) return;
            if (matrix[row, col] == 1)
            {
                foundIsland = true;
            }

            for (int i = 0; i < 4; i++)
            {
                var nextR = row + dirx[i];
                var nextC = col + diry[i];

                if (nextR < 0 || nextC < 0) continue;
                if (nextR == matrix.GetLength(0) || nextC == matrix.GetLength(1)) continue;

                if (foundIsland) return;

                if (matrix[nextR, nextC] == -1 || matrix[nextR, nextC] == -2)
                {
                    continue;
                }

                if (matrix[nextR, nextC] == 0)
                {
                    matrix[nextR, nextC] = -2;
                    nodesInNextIteration++;
                    queue.Enqueue(new Tuple<int, int>(nextR, nextC));

                    continue;
                }

                if (matrix[nextR, nextC] == 1)
                {
                    foundIsland = true;
                    return;
                }
            }

        }
        int nodesLeftInIteration = 0;
        int nodesInNextIteration = 0;
        int[] dirx = new int[] { 1, -1, 0, 0 };
        int[] diry = new int[] { 0, 0, -1, 1 };

        public void MatrixDFS(int[,] matrix, int i, int j)
        {
            if (i < 0 || j < 0) return;
            if (i == matrix.GetLength(0) || j == matrix.GetLength(1)) return;

            if (matrix[i, j] == 0) return;
            if (matrix[i, j] == -1) return;

            matrix[i, j] = -1;
            queue.Enqueue(new Tuple<int, int>(i, j));
            nodesLeftInIteration++;

            MatrixDFS(matrix, i, j + 1);
            MatrixDFS(matrix, i, j - 1);
            MatrixDFS(matrix, i + 1, j);
            MatrixDFS(matrix, i - 1, j);

        }
    }
}
