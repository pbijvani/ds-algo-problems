using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class is_permutation_of_palindrom
    {
        public bool IsPermutationOfPalindrom(string input)
        {
            var len = input.Length;

            var isOdd = len % 2 == 1;

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
            int noOfOdd = 0;
            foreach (var item in dict)
            {
                if (item.Value % 2 == 1) noOfOdd++;
            }

            if (isOdd)
            {
                return noOfOdd == 1;
            }
            else
            {
                return noOfOdd != 1;
            }
        }

        // efficient 
        // we just need to know if its even or odd, not count
        // using bit vector
        public bool IsPermutationOfPalindromBitVector(string input)
        {
            int status = 0;

            foreach (var ch in input)
            {
                if (ch < 'a' || ch > 'z')
                    continue;

                var val = ch - 'a';
                var mask = 1 << val;

                status = status ^ mask;
            }

            return (status & (status - 1)) == 0;
        }
    }
}
