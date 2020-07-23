using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Matrix
{
    public class matrix_of_letter_find_if_word_exists
    {
        /*
         * you are given a matrix having letter on each cell
         * you are given a word and find if you can form a word from matrix
         * 
         * word can be formed vertical or horizontal (or both). 
         * same letter cant be repeated.
         * 
         */

        public bool FindWord(char[,] board, string word)
        {
            var lenX = board.GetLength(0);
            var lenY = board.GetLength(1);

            for(int i = 0; i < lenX; i++)
            {
                for(int j = 0; j < lenY; j++)
                {
                    if(board[i, j] == word[0] && dfs(board, i, j, 0, word))
                    {
                        return true;
                    }
                }
            }

            return false;            
        }

        private bool dfs(char[,] board, int i, int j, int count, string word)
        {
            if (count == word.Length)
            {
                return true;
            }

            if(i >= board.GetLength(0) || j >= board.GetLength(1) || i < 0 || j < 0 || board[i, j] != word[count])
            {
                return false;
            }

            var temp = board[i, j];
            board[i, j] = ' ';

            var found = dfs(board, i + 1, j, count + 1, word)
                || dfs(board, i - 1, j, count + 1, word)
                || dfs(board, i, j + 1, count + 1, word)
                || dfs(board, i, j - 1, count + 1, word);

            board[i, j] = temp;

            return found;
        }
    }
}
