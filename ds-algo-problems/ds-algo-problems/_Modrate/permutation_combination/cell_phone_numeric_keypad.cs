using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.permutation_combination
{
    public class cell_phone_numeric_keypad
    {
        // you are given old phone numeric keypad where each key has set of letter assigned.
        // you are given a number.
        // you are given a set of words (dictionary)
        // find all possible valid words based on given number
        // Run time of bellw is : N 4 Power (n) .. we are making 4 branch from each recursion

        private readonly Dictionary<char, List<char>> mapping;
        private readonly HashSet<string> dictionary;
        public cell_phone_numeric_keypad()
        {
            mapping = new Dictionary<char, List<char>>();

            mapping.Add('2', new List<char>() { 'a', 'b', 'c' });
            mapping.Add('3', new List<char>() { 'd', 'e', 'f' });
            mapping.Add('4', new List<char>() { 'g', 'h', 'i' });
            mapping.Add('5', new List<char>() { 'j', 'k', 'l' });
            mapping.Add('6', new List<char>() { 'm', 'n', 'o' });
            mapping.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            mapping.Add('8', new List<char>() { 't', 'u', 'v' });
            mapping.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });

            dictionary = new HashSet<string>();
        }
        public string[] FindWords(string number)
        {
            List<string> validWords = new List<string>();

            GetValidWords(number, 0, "", validWords);

            return validWords.ToArray();
        }

        public void GetValidWords(string number, int index, string prefix, List<string> validWords)
        {
            if(index == number.Length)
            {
                if (dictionary.Contains(prefix)) validWords.Add(prefix);
                return;
            }
            var possibleChars = mapping[number[index]];
            foreach(var ch in possibleChars)
            {
                string newPrefix = prefix + ch;
                GetValidWords(number, index + 1, newPrefix, validWords);
            }
        }

        
        // Solution 2:
        // Here when we encounter prefix which doesnt make any work we should break recursion
        // For that HashSet structure of dictionary wont work
        // We need to use Trie data structure, its kind of tree used to stroe words.
        // theoritically run time is same but practically it will be lot faster

        // Sol:3
        // If we need to call this multiple time
        // we can preapre a reverse structure. 
        // Dictionary of (Number -> list of words)
        // then it will be just pulling list from dictonary

    }
}
