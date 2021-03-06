﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.sliding_window
{
    // https://leetcode.com/problems/minimum-window-substring/solution/
    public class minimum_window_substring
    {
        /*
         * Approach 1 : sliding window
         * 
         * Complexity Analysis

            Time Complexity: O(|S| + |T|)O(∣S∣+∣T∣) where |S| and |T| represent the lengths of strings SS and TT. In the worst case we might end up visiting every element of string SS twice, once by left pointer and once by right pointer. |T|∣T∣ represents the length of string TT.

            Space Complexity: O(|S| + |T|)O(∣S∣+∣T∣). |S|∣S∣ when the window size is equal to the entire string SS. |T|∣T∣ when TT has all unique characters.
         */
        public string MinWindow(string s, string t)
        {
            var sLen = s.Length;
            var tLen = t.Length;

            var tSet = new Dictionary<char, int>();
            var windowSet = new Dictionary<char, int>();
            var rLen = 0;

            foreach (var ch in t)
            {
                if (tSet.ContainsKey(ch))
                {
                    tSet[ch] = tSet[ch] + 1;
                }
                else
                {
                    tSet.Add(ch, 1);
                }
            }

            var requiredChar = tSet.Count;
            var windowChar = 0;

            var left = 0;
            var right = 0;

            var minLen = int.MaxValue;
            var minBegin = -1;
            var minEnd = -1;

            for (right = 0; right < s.Length; right++)
            {
                var ch = s[right];

                if (tSet.ContainsKey(ch))
                {
                    if (windowSet.ContainsKey(ch))
                    {
                        windowSet[ch] = windowSet[ch] + 1;
                    }
                    else
                    {
                        windowSet.Add(ch, 1);
                    }
                    rLen++;

                    if(windowSet[ch] == tSet[ch])
                    {
                        windowChar++;
                    }
                }

                while (left <= right && windowChar == requiredChar)
                {
                    if (right - left + 1 < minLen)
                    {
                        minLen = right - left + 1;
                        minBegin = left;
                        minEnd = right;
                    }

                    var sCh = s[left];
                    left++;

                    if (windowSet.ContainsKey(sCh))
                    {
                        windowSet[sCh] = windowSet[sCh] - 1;

                        if (windowSet[sCh] < tSet[sCh])
                        {
                            windowChar--;
                        }

                        rLen--;
                    }
                }
            }

            return minBegin == -1 ? "" : s.Substring(minBegin, minEnd - minBegin + 1);
        }

        /*
         * Approach 2 : improved sliding window. Useful when t is significantly smaller than s
         * 
         *   S = "ABCDDDDDDEEAFFBC" T = "ABC"
              filtered_S = [(0, 'A'), (1, 'B'), (2, 'C'), (11, 'A'), (14, 'B'), (15, 'C')]
              Here (0, 'A') means in string S character A is at index 0.
         */

        public void test()
        {
            var res = MinWindow("bbaa", "aba");
        }
    }
}
