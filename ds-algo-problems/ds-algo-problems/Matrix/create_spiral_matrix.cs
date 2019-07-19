using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    class CreateSpiralMatrix
    {
        public List<List<int>> spiral(int A)
        {
            int[,] result1 = new int[A, A];

            List<List<int>> result = new List<List<int>>();

            int i = 1;
            int noOfElement = A * A;

            int x = 0;
            int y = 0;

            int[] dir = new int[] { 1, 2, 3, 4 };
            int currDir = 1;

            while (i <= noOfElement)
            {
                result[x][y] = i;
                i++;

                switch (currDir)
                {
                    case 1:
                        {
                            y++;
                            if (y == A - 1 || result[x][y + 1] != 0) currDir = 2;
                        }

                        break;
                    case 2:
                        {
                            x++;
                            if (x == A - 1 || result[x + 1][y] != 0) currDir = 3;
                        }
                        break;
                    case 3:
                        {
                            y--;
                            if (y == 0 || result[x][y - 1] != 0) currDir = 4;
                        }
                        break;
                    case 4:
                        {
                            x--;
                            if (x == 0 || result[x - 1][y] != 0) currDir = 1;
                        }
                        break;
                }
            }
            return result;
        }
    }
}
