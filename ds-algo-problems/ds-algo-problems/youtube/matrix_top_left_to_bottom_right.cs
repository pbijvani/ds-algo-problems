using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class matrix_top_left_to_bottom_right
    {
        public void PathDFS(int[,] matrix)
        {
            // val 1 : valid and can visit
            // val -1 : can not visit
            // val 0 : destination. need to find path for

            var lenx = matrix.GetLength(0);
            var leny = matrix.GetLength(1);

            bool[,] visited = new bool[lenx, leny];

            var path = new List<MatrixCell>() { new MatrixCell(0, 0) };
            matrixDFS(matrix, 0, 0, visited, path);

        }


        int[] dirX = new int[] { 1, -1, 0, 0 };
        int[] dirY = new int[] { 0, 0, -1, 1 };

        private bool matrixDFS(int[,] matrix, int x, int y, bool[,] visisted, List<MatrixCell> path)
        {
            visisted[x, y] = true;

            for(int cnt = 0; cnt < 4; cnt++)
            {
                var newX = x + dirX[cnt];
                var newY = y + dirY[cnt];

                if (newX < 0 || newY < 0 || newX >= matrix.GetLength(0) || newY >= matrix.GetLength(1))
                    continue;

                if (visisted[newX, newY])
                    continue;

                if (matrix[newX, newY] == -1)
                    continue;

                if (matrix[newX, newY] == 0)
                {
                    path.Add(new MatrixCell(newX, newY));
                    return true;
                }

                path.Add(new MatrixCell(newX, newY));

                var res = matrixDFS(matrix, newX, newY, visisted, path);

                if (!res)
                {
                    path.RemoveAt(path.Count - 1);
                }
                else
                    return true;
            }

            return false;
        }


        public void PathBFS(int[,] matrix)
        {
            var lenX = matrix.GetLength(0);
            var lenY = matrix.GetLength(1);

            var visited = new bool[lenX,lenY];
            Queue<QueueItemMatrix> queue = new Queue<QueueItemMatrix>();
            var path = new List<PathItem>();

            var startQueueItem = new QueueItemMatrix(new MatrixCell(0, 0), 0);
            queue.Enqueue(startQueueItem);

            path.Add(new PathItem(startQueueItem.Cell, null));

            MatrixCell destinationCell = null;
            while(queue.Any())
            {
                var cell = queue.Dequeue();

                visited[cell.Cell.x, cell.Cell.y] = true;
                              
                if(matrix[cell.Cell.x, cell.Cell.y] == 0)
                {
                    destinationCell = cell.Cell;
                    break;
                }

                var list = GetAdjucentCell(matrix, cell, visited, lenX, lenY);
                foreach(var item in list)
                {
                    path.Add(new PathItem(item.Cell, cell.Cell));
                    queue.Enqueue(item);
                }
            }

            if(destinationCell != null)
            {
                reconstructPath(destinationCell, path);
            }
            else
            {
                Console.WriteLine("No Path found");
            }
        }

        private void reconstructPath(MatrixCell destinationCell, List<PathItem> path)
        {
            List<MatrixCell> pathTodes = new List<MatrixCell>();
            var pathItem = path.FirstOrDefault(x => x.Cell == destinationCell);

            while(pathItem != null)
            {
                pathTodes.Add(pathItem.Cell);
                pathItem = path.FirstOrDefault(x => x.Cell == pathItem.ParentCell);
            }
            pathTodes.Reverse();
            foreach (var cell in pathTodes)
            {
                Console.WriteLine($"{cell.x}, {cell.y}");
            }
        }

        private List<QueueItemMatrix> GetAdjucentCell(int[,] matrix, QueueItemMatrix cell, bool[,] visisted, int lenX, int lenY)
        {
            var list = new List<QueueItemMatrix>();
            for(int i = 0; i < 4; i++)
            {
                var newX = cell.Cell.x + dirX[i];
                var newY = cell.Cell.y + dirY[i];

                if (newX < 0 || newY < 0 || newX >= lenX || newY >= lenY)
                    continue;

                if (visisted[newX, newY])
                    continue;

                if (matrix[newX, newY] == -1)
                    continue;

                list.Add(new QueueItemMatrix(new MatrixCell(newX, newY), cell.Level + 1));
            }
            return list;
        }


        public void Test()
        {
            var matrix = new int[,] {
                { 1, 1, 1, -1, 1 },
                { 1, -1, 1, 1, 1},
                { 1, -1, 1, -1, 1},
                { 1, -1, 1, -1, 1},
                { 1, 1, 1, -1, 0}
            };

            PathDFS(matrix);
            PathBFS(matrix);
        }
    }

    public class QueueItemMatrix
    {
        public QueueItemMatrix(MatrixCell cell, int level)
        {
            Cell = cell;
            Level = level;
        }
        public MatrixCell Cell { get; set; }
        public int Level { get; set; }
    }

    public class PathItem
    {
        public PathItem(MatrixCell cell, MatrixCell parentCell)
        {
            Cell = cell;
            ParentCell = parentCell;
        }
        public MatrixCell Cell { get; set; }
        public MatrixCell ParentCell { get; set; }
    }

    public class MatrixCell
    {
        public MatrixCell(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
