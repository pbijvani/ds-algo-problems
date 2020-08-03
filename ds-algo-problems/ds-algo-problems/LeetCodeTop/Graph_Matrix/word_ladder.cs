using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Graph_Matrix
{
    /*
        Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:

        Only one letter can be changed at a time.
        Each transformed word must exist in the word list.
        Note:

        Return 0 if there is no such transformation sequence.
        All words have the same length.
        All words contain only lowercase alphabetic characters.
        You may assume no duplicates in the word list.
        You may assume beginWord and endWord are non-empty and are not the same.
        Example 1:

        Input:
        beginWord = "hit",
        endWord = "cog",
        wordList = ["hot","dot","dog","lot","log","cog"]

        Output: 5

        Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        return its length 5.   
        
        https://leetcode.com/problems/word-ladder/
     */

    public class word_ladder
    {
        private void PrepareCombinations(List<string> wordList, Dictionary<string, List<string>> map)
        {
            foreach (var word in wordList)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var pattern = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    if (map.ContainsKey(pattern))
                    {
                        map[pattern].Add(word);
                    }
                    else
                    {
                        map.Add(pattern, new List<string>() { word });
                    }
                }
            }
        }
        public int LadderLengthBFS(string beginWord, string endWord, List<string> wordList)
        {
            var map = new Dictionary<string, List<string>>();

            PrepareCombinations(wordList, map);
            PrepareCombinations(new List<string>() { beginWord }, map);

            var visited = new HashSet<string>();

            var queue = new Queue<QueItemWithDepth>();

            queue.Enqueue(new QueItemWithDepth(beginWord, 1));

            while(queue.Any())
            {
                var queueItem = queue.Dequeue();

                var currWord = queueItem.Word;

                if (currWord == endWord) return queueItem.Depth;

                visited.Add(currWord);

                for(int i = 0; i < currWord.Length; i++)
                {
                    var pattern = currWord.Substring(0, i) + "*" + currWord.Substring(i + 1);

                    foreach(var nextWord in map[pattern])
                    {
                        if(!visited.Contains(nextWord))
                        {
                            queue.Enqueue(new QueItemWithDepth(nextWord, queueItem.Depth + 1));
                        }
                    }
                }
            }

            return 0;
        }

        public void test()
        {
            var list = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
            var beginWord = "hit";
            var endWord = "cog";

            var count = LadderLengthBFS(beginWord, endWord, list);

        }
    }

    public class QueItemWithDepth
    {
        public QueItemWithDepth(string word, int depth)
        {
            Word = word;
            Depth = depth;
        }
        public string Word { get; set; }
        public int Depth { get; set; }
    }
}
