using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class Tow_Dimension_Get_two_closest_points
    {
        public int[,] GetTwoClosestPoints(int[,] input)
        {
            double first = double.MaxValue;
            double second = double.MaxValue;

            int[] firstPoint = new int[2];
            int[] secondPoint = new int[2];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                var distance = CalculateDistance(input[i, 0], input[i, 1]);

                if (distance < first)
                {
                    second = first;
                    first = distance;

                    secondPoint[0] = firstPoint[0];
                    secondPoint[1] = firstPoint[1];

                    firstPoint[0] = input[i, 0];
                    firstPoint[1] = input[i, 1];
                }
                else if (distance < second)
                {
                    second = distance;

                    secondPoint[0] = input[i, 0];
                    secondPoint[1] = input[i, 1];
                }
            }

            return new int[,] { { firstPoint[0], firstPoint[1] }, { secondPoint[0], secondPoint[1] } };
        }

        private double CalculateDistance(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return System.Math.Abs(x + y);
            }
            else
            {
                return System.Math.Sqrt((x * x) + (y * y));
            }
        }
    }
}
