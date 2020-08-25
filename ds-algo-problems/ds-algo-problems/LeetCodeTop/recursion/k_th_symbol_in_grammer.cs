using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.recursion
{
    // https://leetcode.com/problems/k-th-symbol-in-grammar/
    public class k_th_symbol_in_grammer
    {
        public int KthGrammar(int N, int K)
        {
            if (N == 1 && K == 1)
            {
                return 0;
            }

            int len = (int)System.Math.Pow(2, N - 1);

            int mid = len / 2;

            if (K <= mid)
            {
                return KthGrammar(N - 1, K);
            }
            else
            {
                return KthGrammar(N - 1, K - mid) == 0 ? 1 : 0;
            }
        }
    }
}
