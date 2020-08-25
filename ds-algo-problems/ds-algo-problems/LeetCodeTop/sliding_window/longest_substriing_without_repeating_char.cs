using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.sliding_window
{
    /*
        Given a string, find the length of the longest substring without repeating characters.

        Example 1:

        Input: "abcabcbb"
        Output: 3 
        Explanation: The answer is "abc", with the length of 3. 
        Example 2:

        Input: "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3. 
                     Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    
        https://leetcode.com/problems/longest-substring-without-repeating-characters/

        additional similar problem:
        https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/
        https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
     */

    /*
     * Approach 1: Brute Force
     * Check all the substring one by one to see if it has no duplicate character.
        
        Time : O(N3)
        Space : O(min(m, n))
        where m is len of string, and n is len of char set
    
     */


    /*
     * Approach 1: Sliding Window
     * Time: O(2n) = O(n)
     * Space; O(min(m,n))
     */
    public class longest_substriing_without_repeating_char
    {
        public int LengthOfLongestSubstring(string s)
        {
            var strLen = s.Length;
            var set = new HashSet<char>();
            var len = 0;
            var maxLen = 0;
            var start = 0;
            var end = 0;

            while (start >= 0 && end <= strLen - 1 && start <= end)
            {
                if(set.Contains(s[end]))
                {
                    while(start >=0 && start < end && s[start] != s[end])
                    {
                        set.Remove(s[start]);
                        start++;
                        len--;
                    }
                    start++;
                    end++;
                }
                else
                {
                    set.Add(s[end]);
                    end++;
                    len++;
                    maxLen = System.Math.Max(maxLen, len);
                }
            }

            return maxLen;
        }

        /*
         * Approach 1: Sliding Window optimized
         * Time: O(n)
         * Space; O(min(m,n))
         */
        public int LengthOfLongestSubstring1(string s)
        {
            var lenOfString = s.Length;
            var dict = new Dictionary<char, int>();
            var len = 0;
            var maxLen = 0;
            var start = 0;

            for (int end = 0; end < lenOfString; end++)
            {
                if (dict.ContainsKey(s[end]) && dict[s[end]] >= start)
                {
                    var lastInde = dict[s[end]];
                    start = lastInde + 1;
                    len = end - start + 1;
                    dict[s[end]] = end;
                }
                else
                {
                    if (dict.ContainsKey(s[end]))
                        dict[s[end]] = end;
                    else
                        dict.Add(s[end], end);
                    len++;
                    maxLen = System.Math.Max(maxLen, len);
                }
            }
            return maxLen;
        }

        /*
         * Approach 4 : Solution in approach 2 can be optimized using bit vector instead of map to sptore char index
         * This will get the O(1) space
         * Letters a-z : 26 bit needed
         * ASCII : 128 bit needed
         * extended ASCII : 256 bit needed
         * 
         * https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
         * 
         */

        // assuming char range is a-z
        // Set bit : bitVector = bitVector | (1 << charIndex);
        // Clear bit : bitVector = bitVector & ~(1 << charIndex);
        // CHeck if bit is ON : (bitVector & (1 << charIndex)) > 0
        public int LengthOfLongestSubstring3(string s)
        {
            var strLen = s.Length;
            var len = 0;
            var maxLen = 0;
            var start = 0;
            var end = 0;
            int bitVector = 0;
            while (start >= 0 && end <= strLen - 1 && start <= end)
            {
                var currChar = s[end];
                int charIndex = currChar - 'a';
                if ((bitVector & (1 << charIndex)) > 0)
                {
                    while (start >= 0 && start < end && s[start] != s[end])
                    {
                        bitVector = bitVector & (~(1 << (s[start] - 'a')));
                        start++;
                        len--;
                    }
                    start++;
                    end++;
                }
                else
                {
                    bitVector = bitVector | (1 << charIndex);
                    end++;
                    len++;
                    maxLen = System.Math.Max(maxLen, len);
                }
            }

            return maxLen;
        }


        public void test()
        {
            var res = LengthOfLongestSubstring1("tmmzuxt");
        }
    }
}
