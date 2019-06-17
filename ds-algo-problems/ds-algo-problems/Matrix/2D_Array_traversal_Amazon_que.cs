using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class _2D_Array_traversal_Amazon_que
    {
        /*
    
    This is classic graph traversal problem. Instead of graph we have a two dimentional array.
    I am using BSF approach to solve this.
    
    logic to travse to next node: From any element in 2D array we can go to top, bottom, left, right.
    We just need to care about boundry conditions.
    
    Maintaining Queue to handle to logic of BSF. Starting root of element I am moving to all possible directions until I find the
    element I am looking for.
    
    
    
    
    */


        bool[,] visited;
        Queue<int> qRow = new Queue<int>();
        Queue<int> qCol = new Queue<int>();

        int nodesLeftInIteration = 1;
        int nodesInNextIteration = 0;


        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int removeObstacle(int numRows, int numColumns, int[,] lot)
        {
            // maintain visited cell so that we dont visit them again
            visited = new bool[numRows, numColumns];

            // top-left element
            int sourceR = 0;
            int sourceC = 0;

            // Variable to keep count
            int moveCount = 0;

            bool reachedToDestination = false;

            // Maintaining two query to store two dimensions. I could have used single queur but that would needed a queye of object
            qRow.Enqueue(sourceR);
            qCol.Enqueue(sourceC);

            visited[sourceR, sourceC] = true;

            // Untial we have any node to traverse
            while (qRow.Any())
            {
                // Dequeue element
                int r = qRow.Dequeue();
                int c = qCol.Dequeue();

                if (lot[r, c] == 9)
                {
                    reachedToDestination = true;
                    break;
                }

                VisitNeighbourArea(r, c, lot, numRows, numColumns);

                // decrement node count in current iteration.
                nodesLeftInIteration--;


                if (nodesLeftInIteration == 0)
                {
                    // reset node count
                    nodesLeftInIteration = nodesInNextIteration;
                    nodesInNextIteration = 0;

                    // increment move count
                    moveCount++;
                }

            }

            if (reachedToDestination)
            {
                return moveCount;
            }
            else
            {
                return -1;
            }
        }
        // This is logic to traverse into the 2D array avoiding all duplicates and avoiding all node where we cant go
        public void VisitNeighbourArea(int r, int c, int[,] lot, int numRows, int numColumns)
        {
            int[] directionRow = new int[] { -1, 1, 0, 0 };
            int[] directionCol = new int[] { 0, 0, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                var nextR = r + directionRow[i];
                var nextC = c + directionCol[i];

                if (nextR < 0 || nextC < 0) continue;
                if (nextR >= numRows || nextC >= numColumns) continue;

                if (visited[nextR, nextC] == true) continue;
                if (lot[nextR, nextC] == 0) continue;

                qRow.Enqueue(nextR);
                qCol.Enqueue(nextC);

                visited[nextR, nextC] = true;

                // maintain how many node we have in next iteration.
                nodesInNextIteration++;
            }
        }
    }
}
