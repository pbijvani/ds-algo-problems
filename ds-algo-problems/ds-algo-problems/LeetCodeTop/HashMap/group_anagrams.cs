using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.HashMap
{
    public class group_anagrams
    {
        /*
         Given an array of strings, group anagrams together.

        Example:

        Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
        Output:
        [
          ["ate","eat","tea"],
          ["nat","tan"],
          ["bat"]
        ]
         */

        // Time complexity : O(M N LOG (N)
        // M : number of string in array
        // N : largerst length string in array
        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<List<string>>();
            var dict = new Dictionary<string, List<string>>();
            foreach(var str in strs)
            {
                var sortedStrt = string.Join("", str.ToCharArray().OrderBy(x => x));

                if(!dict.ContainsKey(sortedStrt))
                {
                    dict.Add(sortedStrt, new List<string>());
                }

                dict[sortedStrt].Add(str);
            }

            return new List<List<string>>(dict.Values);
        }

        public void test()
        {
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var res = GroupAnagrams1(strs);
        }

        // This reduces cost of sorting each string
        // Time complexity : O(MN)
        // M : number of string in array
        // N : largerst length string in array
        public List<List<string>> GroupAnagrams1(string[] strs)
        {
            var result = new List<List<string>>();
            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var charCount = new int[26];

                foreach(var ch in str)
                {
                    charCount[ch - 'a']++;
                }

                StringBuilder encodedStrSb = new StringBuilder();

                foreach(var cnt in charCount)
                {
                    encodedStrSb.Append($"#{cnt}");
                }

                var encodedStr = encodedStrSb.ToString();

                if (!dict.ContainsKey(encodedStr))
                {
                    dict.Add(encodedStr, new List<string>());
                }

                dict[encodedStr].Add(str);
            }

            return new List<List<string>>(dict.Values);
        }
    }
}
