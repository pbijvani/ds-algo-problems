using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    public class common_word
    {
        /*
         * Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  
         * It is guaranteed there is at least one word that isn't banned, and that the answer is unique.

Words in the list of banned words are given in lowercase, and free of punctuation.  
Words in the paragraph are not case sensitive.  The answer is in lowercase.
Example:

Input: 
paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
banned = ["hit"]
Output: "ball"
Explanation: 
"hit" occurs 3 times, but it is a banned word.
"ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
Note that words in the paragraph are not case sensitive,
that punctuation is ignored (even if adjacent to words, such as "ball,"), 
and that "hit" isn't the answer even though it occurs more because it is banned.
         */

        public string CommonWord(string para, string[] banned)
        {
            var set = new HashSet<string>();
            foreach(var word in banned)
            {
                set.Add(word.ToLower());
            }

            var map = new Dictionary<string, int>();
            var charArr = para.ToCharArray();
            StringBuilder buffer = new StringBuilder();

            var maxCount = 0;
            var mostFrequentWord = "";
            for(int i = 0; i < charArr.Length; i++)            
            {
                var ch = charArr[i];
                if(IsLetter(ch))
                {
                    buffer.Append(ch.ToString().ToLower());
                    if(i != charArr.Length - 1)
                        continue;
                }

                if (buffer.Length > 0)
                {
                    var word = buffer.ToString();

                    if (!set.Contains(word))
                    {
                        var count = map.ContainsKey(word) ? map[word] + 1 : 1;
                        if (map.ContainsKey(word))
                        {
                            map[word] = count;
                        }
                        else
                        {
                            map.Add(word, count);
                        }
                        if (count > maxCount)
                        {
                            maxCount = count;
                            mostFrequentWord = word;
                        }
                    }
                }
                buffer = new StringBuilder();
            }
            return mostFrequentWord;
        }

        public bool IsLetter(char ch)
        {
            return char.IsLetterOrDigit(ch);
        }
    }
}
