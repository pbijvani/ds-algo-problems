using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class letter_combination_of_phone_number
    {
        /*
         * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

            Input: "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

            Complexity Analysis

Time complexity : \mathcal{O}(3^N \times 4^M)O(3 
N
 ×4 
M
 ) where N is the number of digits in the input that maps to 3 letters (e.g. 2, 3, 4, 5, 6, 8) and M is the number of digits in the input that maps to 4 letters (e.g. 7, 9), and N+M is the total number digits in the input.

Space complexity : \mathcal{O}(3^N \times 4^M)O(3 
N
 ×4 
M
 ) since one has to keep 3^N \times 4^M3 
N
 ×4 
M
  solutions.

         */
        public void Test()
        {
            var res = LetterCombinations("23");
        }

        public List<string> LetterCombinations(string number)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(number)) return result;

            var dict = new Dictionary<char, List<char>>()
            {
                { '2', new List<char>(){ 'a', 'b', 'c' }  },
                { '3', new List<char>(){ 'd', 'e', 'f' }  },
                { '4', new List<char>(){ 'g', 'h', 'i' }  },
                { '5', new List<char>(){ 'j', 'k', 'l' }  },
                { '6', new List<char>(){ 'm', 'n', 'o' }  },
                { '7', new List<char>(){ 'p', 'q', 'r', 's' }  },
                { '8', new List<char>(){ 't', 'u', 'v' }  },
                { '9', new List<char>(){ 'w', 'x', 'y', 'z' }  }
            };

            LetterCombinationsRecursive(number, result, dict, "", 0);

            return result;
        }

        private void LetterCombinationsRecursive(string number, List<string> result, Dictionary<char, List<char>> dict, string curr, int index)
        {
            if(number.Length == curr.Length)
            {
                result.Add(curr);
                return;
            }

            var letters = dict[number[index]];

            foreach(var letter in letters)
            {
                LetterCombinationsRecursive(number, result, dict, $"{curr}{letter}", index + 1);
            }
        }
    }
}
