﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class Parentheses_Prob
    {
        public List<string> GenerateParanth(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();

            generateCombination(list, count, count, str, 0);

            return list;
        }
        // Rule : at no point no of right paran should be greated than no of left parnth
        // select left as long as we have left paran
        // we can insert right as long as it doesnt lead syntax error (rule above)
        private void generateCombination(List<string> list, int leftRem, int rightRemain, char[] str, int index)
        {
            // invalid state
            if (leftRem < 0 || rightRemain < leftRem) return;

            if (leftRem == 0 && rightRemain == 0)
            {
                list.Add(string.Join("", str));
            }
            else
            {
                str[index] = '(';
                generateCombination(list, leftRem - 1, rightRemain, str, index + 1);

                str[index] = ')';
                generateCombination(list, leftRem, rightRemain - 1, str, index + 1);
            }
        }


    }
}
