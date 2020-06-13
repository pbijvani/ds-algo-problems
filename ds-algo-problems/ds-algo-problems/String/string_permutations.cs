using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class string_permutations
    {
        public List<string> getPermutations(string input)
        {
            var result = new List<string>();
            getPerm("", input, result);
            return result;
        }

        // Strig permutation : no duplicate
        // Time Complexity : O(n!)
        private void getPerm(string prefix, string remainer, List<string> result)
        {
            if (remainer.Length == 0) result.Add(prefix);

            int len = remainer.Length;

            for (int i = 0; i < len; i++)
            {
                string before = remainer.Substring(0, i);
                string after = remainer.Substring(i + 1);

                char c = remainer[i];

                getPerm(prefix + c, before + after, result);
            }

        }

        public void StringPermutations(char[] input)
        {
            int len = input.Length;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var ch in input)
            {
                if (dict.ContainsKey(ch)) dict[ch]++;
                else dict.Add(ch, 1);
            }

            char[] runningInput = new char[len];
            int[] inputCount = new int[len];

            int index = 0;
            foreach (var item in dict)
            {
                runningInput[index] = item.Key;
                inputCount[index] = item.Value;
                index++;
            }
            char[] result = new char[len];
            Permute(runningInput, inputCount, result, 0);
        }

        public void Permute(char[] str, int[] count, char[] result, int depth)
        {
            if (depth == str.Length)
            {
                Console.WriteLine(string.Join("", result));
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (count[i] == 0) continue;

                    result[depth] = str[i];
                    count[i]--;
                    Permute(str, count, result, depth + 1);
                    count[i]++;
                }
            }
        }
        /*
         * June 2020
         */
        public List<string> GetPermutations(string input)
        {
            if (input == null) return null;

            if (input.Length == 0) return new List<string>() { "" };

            var permutations = new List<string>();

            var firstChar = input[0];
            var remainder = input.Substring(1);

            var words = GetPermutations(remainder);

            foreach(var word in words)
            {
                for(int i = 0; i <= word.Length; i++)
                {
                    permutations.Add(InsertAti(word, firstChar, i));
                }
            }

            return permutations;
        }

        private string InsertAti(string word, char ch, int i)
        {
            var first = word.Substring(0, i);
            var last = word.Substring(i);
            return first + ch + last;
        }

        public List<string> GetPermutationsDup(string input)
        {
            var dict = PrepareDict(input);

            var result = new List<string>();

            GetPermutationsDup(dict, "", input.Length, result);

            return result;
        }

        private Dictionary<char, int> PrepareDict(string input)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in input)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch] = dict[ch] + 1;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }
            return dict;
        }

        public void GetPermutationsDup(Dictionary<char, int> map, string prefix, int remainder, List<string> result)
        {
            if (remainder == 0)
            {
                result.Add(prefix);
                return;
            }
            var keys = map.Keys.ToList();

            foreach (var ch in keys)
            {
                var count = map[ch];

                if (count > 0)
                {
                    map[ch] = count - 1;
                    GetPermutationsDup(map, prefix + ch, remainder - 1, result);
                    map[ch] = count;
                }
            }
        }
    }
}
