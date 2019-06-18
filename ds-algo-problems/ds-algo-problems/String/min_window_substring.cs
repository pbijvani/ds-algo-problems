using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class min_window_substring
    {

        public string minSubString(string input, string matchString)
        {
            int left = 0;
            int right = matchString.Length - 1;

            int bestLefIndex = 0;
            int bestRightIndex = 0;

            int windowLen = input.Length;
            while (left < input.Length && right < input.Length && left <= right)
            {
                var subString = input.Substring(left, right - left + 1);

                if (containseAllChar(subString, matchString))
                {
                    int newWindowLen = right - left + 1;

                    if (windowLen > newWindowLen)
                    {
                        windowLen = newWindowLen;
                        bestLefIndex = left;
                        bestRightIndex = right;
                    }
                    left++;
                }
                else
                {
                    right++;
                }
            }

            return input.Substring(bestLefIndex, bestRightIndex - bestLefIndex + 1);
        }

        public bool containseAllChar(string str, string match)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var s in match)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s] = dict[s] + 1;
                }
                else
                {
                    dict.Add(s, 1);
                }
            }

            foreach (var m in str)
            {
                if (dict.ContainsKey(m))
                {
                    dict[m] = dict[m] - 1;

                    if (dict[m] == 0) dict.Remove(m);
                }
            }

            return dict.Any() ? false : true;
        }

    }
}
