using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Matrix
{
    public class tic_tac_win
    {
        public bool TicTacWin(int[,] matrix, int n)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    if(matrix[i,j] != matrix[i,j-1])
                    {
                        return false;
                    }
                    if (matrix[j, i] != matrix[j - 1, i])
                    {
                        return false;
                    }
                }
                if(i != 0)
                {
                    if (matrix[i, i] != matrix[i-1, i-1])
                    {
                        return false;
                    }
                    if(matrix[n-1-i, i-1] != matrix[n-i, i])
                    {
                        return false;
                    }
                }                
            }
            return true;
        }
    }
}
