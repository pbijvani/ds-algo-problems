using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.dynamic_programing
{
    /*
        Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

        Note:

        The same word in the dictionary may be reused multiple times in the segmentation.
        You may assume the dictionary does not contain duplicate words.
        Example 1:

        Input: s = "leetcode", wordDict = ["leet", "code"]
        Output: true
        Explanation: Return true because "leetcode" can be segmented as "leet code".
        Example 2:

        Input: s = "applepenapple", wordDict = ["apple", "pen"]
        Output: true
        Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
                     Note that you are allowed to reuse a dictionary word.
        Example 3:

        Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        Output: false

        https://leetcode.com/problems/word-break/
     
     */
    public class word_break
    {
        // Approach 1 : DP with recursion with mem
        // https://www.youtube.com/watch?v=hLQYQ4zj0qg
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var set = new HashSet<string>();

            foreach(var word in wordDict)
            {
                set.Add(word);
            }

            var memo = new Dictionary<string, bool>();

            var res = WordBreakHelper(s, set, memo);

            return res;
        }

        public bool WordBreakHelper(string s, HashSet<string> set, Dictionary<string, bool> memo)
        {
            if (string.IsNullOrEmpty(s)) return true;

            if (memo.ContainsKey(s)) return memo[s];

            for(int len = 1; len <= s.Length; len++)
            {
                var firstPart = s.Substring(0, len);
                var secondPart = s.Substring(len);

                if(set.Contains(firstPart) && WordBreakHelper(secondPart, set, memo))
                {
                    memo.Add(s, true);
                    return true;
                }
            }
            memo.Add(s, false);
            return false;
        }

        // Approach 2

        public bool WordBreak2(string s, IList<string> wordDict)
        {
            var dp = new bool[s.Length + 1];
            dp[0] = true;

            for(int len = 1; len <= s.Length; len++)
            {
                for(int i = 0; i < len; i++)
                {
                    if(dp[i] == true && wordDict.Contains(s.Substring(i, len - i)))
                    {
                        dp[len] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }

        public void test()
        {
            var s = "code";

            var dict = new List<string>() { "c", "od", "e", "y" };

            var res = WordBreak2(s, dict);

            
        }
    }
}
