using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Matrix
{
    public class ant_infinite_grid
    {
        /*
         * Ant is sitting on infinite grid of black and white cell
         * initially all cell are white and ant facing right
         * at each step do following
         * if ant is at white, flip the color of cell, turn 90 right (clockwise) and move forwar one unit
         * if ant is at black, flip the color of cell, turn 90 left (anti clockwise) and move forward one
         * 
         * write program to make k move.
         * after k move print the grid.
         * 
         * choose the right data structure.
         * 
         */
        public void MoveAnt(int k)
        {
            HashSet<string> hashSet = new HashSet<string>();
            AntPosition position = new AntPosition(0, 0, 'R');

            int top = 0, left = 0, right = 0, bottow = 0;

            while (k != 0)
            {
                string dirKey = $"{position.Row}.{position.Col}";
                if(hashSet.Contains(dirKey))
                {
                    hashSet.Remove(dirKey);
                    position.MoveForward(false);
                }
                else
                {
                    hashSet.Add(dirKey);
                    position.MoveForward(true);
                }
                k--;

                top = System.Math.Max(top, position.Row);
                bottow = System.Math.Min(bottow, position.Row);
                left = System.Math.Min(left, position.Col);
                right = System.Math.Max(right, position.Col);

            }

            for (int j = top; j >= bottow; j--) 
            {
                for (int i = left; i <= right; i++)
                {
                    string dirKey = $"{i}.{j}";
                    if (hashSet.Contains(dirKey))
                        Console.Write("B ");
                    else
                        Console.Write("W ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        

    }
    public class AntPosition
    {
        public AntPosition(int r, int c, char d)
        {
            this.Row = r;
            this.Col = c;
            this.Direction = d;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public char Direction { get; set; }

        public void MoveForward(bool clockWise)
        {
            ChangeDirection(clockWise);
            IncrementStep();
        }

        private void IncrementStep()
        {
            switch (Direction)
            {
                case 'R':
                    Row = Row + 1;
                    break;
                case 'D':
                    Col = Col - 1;
                    break;
                case 'L':
                    Row = Row - 1;
                    break;
                case 'U':
                    Col = Col + 1;
                    break;
            }
        }

        private void ChangeDirection(bool clockWise)
        {
            if(clockWise)
            {
                switch (Direction)
                {
                    case 'R':
                        Direction = 'D';
                        break;
                    case 'D':
                        Direction = 'L';
                        break;
                    case 'L':
                        Direction = 'U';
                        break;
                    case 'U':
                        Direction = 'R';
                        break;
                }
            }
            else
            {
                switch (Direction)
                {
                    case 'R':
                        Direction = 'U';
                        break;
                    case 'U':
                        Direction = 'L';
                        break;
                    case 'L':
                        Direction = 'D';
                        break;
                    case 'D':
                        Direction = 'R';
                        break;
                }
            }
        }
    }

}
