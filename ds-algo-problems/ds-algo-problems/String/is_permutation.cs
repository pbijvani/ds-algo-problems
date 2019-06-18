using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class is_permutation
    {
        public bool IsPermutation(string input, string match)
        {
            if (input.Length != match.Length) return false;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var ch in input)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch] = dict[ch] + 1;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }


            foreach (var ch in match)
            {
                if (!dict.ContainsKey(ch))
                {
                    return false;
                }
                else
                {
                    dict[ch] = dict[ch] - 1;
                }

                if (dict[ch] == 0)
                {
                    dict.Remove(ch);
                }
            }

            return true;
        }
    }
}
