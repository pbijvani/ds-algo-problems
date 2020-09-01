using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    public class is_subsequence
    {
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s)) return true;
            if (string.IsNullOrEmpty(t)) return false;

            var sptr = 0;
            var tptr = 0;

            while (tptr < t.Length && sptr < s.Length)
            {
                if(t[tptr] == s[sptr])
                {
                    sptr++;
                }
                tptr++;
            }

            return sptr == s.Length;
        }
    }
}
