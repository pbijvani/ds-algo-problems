using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    /// <summary>
    /// https://leetcode.com/problems/valid-anagram/description/
    /// </summary>
    public class string_anagram
    {
        public bool IsAnagram(string s, string t)
        {
            var len1 = s.Length;
            var len2 = t.Length;

            if(len1 != len2)
            {
                return false;
            }

            Dictionary<char, int> dict = new Dictionary<char, int>();


            for(int i = 0; i < len1; i++)
            {
                var sChar = s[i];
                var tChar = t[i];

                if(dict.ContainsKey(sChar))
                {
                    dict[sChar] = dict[sChar] + 1;

                    if(dict[sChar] == 0)
                    {
                        dict.Remove(sChar);
                    }
                }
                else
                {
                    dict.Add(sChar, 1);
                }

                if (dict.ContainsKey(tChar))
                {
                    dict[tChar] = dict[tChar] - 1;

                    if (dict[tChar] == 0)
                    {
                        dict.Remove(tChar);
                    }
                }
                else
                {
                    dict.Add(tChar, -1);
                }
            }

            return dict.Count == 0;
        }
    }
}
