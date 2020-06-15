using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    /*
     * Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
     */
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

        // VErsion with improved containseAllChar logic using dictionary

        public int MinWondowSubstring(string input, string match)
        {
            var dictMatch = new Dictionary<char, int>();
            var runningMatch = new Dictionary<char, int>();

            foreach (var ch in match)
            {
                if (dictMatch.ContainsKey(ch))
                {
                    dictMatch[ch] = dictMatch[ch] + 1;
                }
                else
                {
                    dictMatch.Add(ch, 1);
                }
            }

            var left = 0;
            var right = 0;
            var len = input.Length;
            var bestLen = int.MaxValue;

            if (dictMatch.ContainsKey(input[right]))
            {
                AddToRunningDict(runningMatch, input[right]);
            }

            while (left < len && right < len && left <= right)
            {
                while (dictMatch.Any(x => !runningMatch.ContainsKey(x.Key) || (runningMatch.ContainsKey(x.Key) && runningMatch[x.Key] < x.Value)))
                {
                    right++;
                    if (right == len) break;
                    var ch = input[right];
                    AddToRunningDict(runningMatch, ch);
                }


                while (!dictMatch.Any(x => !runningMatch.ContainsKey(x.Key) || (runningMatch.ContainsKey(x.Key) && runningMatch[x.Key] < x.Value)))
                {
                    if (bestLen > right - left + 1)
                    {
                        bestLen = right - left + 1;
                    }

                    var ch = input[left];
                    left++;
                    if (left == len) break;
                    RemoveFromRunningDict(runningMatch, ch);
                }

            }
            
            return bestLen;
        }

        public void AddToRunningDict(Dictionary<char, int> runningMatch, char ch)
        {
            if (runningMatch.ContainsKey(ch))
            {
                runningMatch[ch] = runningMatch[ch] + 1;
            }
            else
            {
                runningMatch.Add(ch, 1);
            }
        }

        public void RemoveFromRunningDict(Dictionary<char, int> runningMatch, char ch)
        {
            if (runningMatch.ContainsKey(ch))
            {
                runningMatch[ch] = runningMatch[ch] - 1;

                if (runningMatch[ch] == 0)
                {
                    runningMatch.Remove(ch);
                }
            }


        }
    }
}
