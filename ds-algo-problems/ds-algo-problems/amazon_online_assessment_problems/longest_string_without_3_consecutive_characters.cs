using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://aonecode.com/amazon-online-assessment-questions#lsw
     * https://stackoverflow.com/questions/57740827/find-the-largest-string-such-that-a-b-c-are-not-continuos
    Longest String Without 3 Consecutive Characters
Given A, B, C, find any string of maximum length that can be created such that no 3 consecutive characters are same. There can be at max A 'a', B 'b' and C 'c'.

Example 1:

Input: A = 1, B = 1, C = 6
Output: "ccbccacc"

Example 2:

Input: A = 1, B = 2, C = 3
Output: "acbcbc"     
     */
    public class longest_string_without_3_consecutive_characters
    {
        public string Sequence(int[] freq)
        {
            var dict = new Dictionary<char, int>();

            dict.Add('a', freq[0]);
            dict.Add('b', freq[1]);
            dict.Add('c', freq[2]);

            var output = new StringBuilder();

            while(true)
            {
                var choice = GetKey(dict, 0); // Get char with highest freq;

                if (choice.Value == 0) break; // no more char to process

                if(output.Length >= 2 && output[output.Length - 2] == choice.Key && output[output.Length - 1] == choice.Key) // last 2 char are same as choice
                {
                    choice = GetKey(dict, 1);

                    if (choice.Value == 0) break;
                }

                output.Append(choice.Key);
                dict[choice.Key] = dict[choice.Key] - 1;
            }

            return output.ToString();
        }

        private KeyValuePair<char, int> GetKey(Dictionary<char, int> dict, int order)
        {
            if(order == 0)
            {
                return dict.OrderByDescending(x => x.Value).First();
            }
            else if(order == 1)
            {
                return dict.OrderByDescending(x => x.Value).Skip(1).Take(1).First();
            }
            else
            {
                return dict.OrderByDescending(x => x.Value).First();
            }
        }
    }
}
