using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class word_ladder
    {
        /*
            Given two words (beginWord and endWord), 
            and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:

            Only one letter can be changed at a time
            Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
            Note:

            Return an empty list if there is no such transformation sequence.
            All words have the same length.
            All words contain only lowercase alphabetic characters.
            You may assume no duplicates in the word list.
            You may assume beginWord and endWord are non-empty and are not the same.
            Example 1:

            Input:
            beginWord = "hit",
            endWord = "cog",
            wordList = ["hot","dot","dog","lot","log","cog"]

            Output:
            [
              ["hit","hot","dot","dog","cog"],
              ["hit","hot","lot","log","cog"]
            ]
            Example 2:

            Input:
            beginWord = "hit"
            endWord = "cog"
            wordList = ["hot","dot","dog","lot","log"]

            Output: []

            Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.
         
         */

        public List<List<string>> FindLadders(string beginWord, string endWord, List<string> wordList)
        {
            var iterationList = new List<Route>();
            var result = new List<Route>();
           
            iterationList.Add(new Route(beginWord, 0, null));            

            while(iterationList.Any())
            {
                var nextIterationList = new List<Route>();

                foreach(var visited in iterationList)
                {
                    if(IsDifferByAChar(visited.Word, endWord))
                    {
                        result.Add(new Route(endWord, visited.Level + 1, visited));
                        continue;
                    }
                    else
                    {
                        var indexesToRemove = new List<int>();
                        for( int i = 0; i < wordList.Count; i++)
                        {
                            var item = wordList[i];
                            if(IsDifferByAChar(visited.Word, item))
                            {
                                nextIterationList.Add(new Route(item, visited.Level + 1, visited));
                                indexesToRemove.Add(i);
                            }
                            else
                            {
                                continue;
                            }
                        }

                        nextIterationList.ForEach(x => {
                            wordList.Remove(x.Word);
                        });
                        //indexesToRemove.ForEach(x => wordList.Remove(x));
                    }
                }

                iterationList = nextIterationList;
            }

            var newRes = new List<List<string>>();
            foreach(var item in result)
            {
                var list = new List<string>();
                var pointer = item;
                while(pointer != null)
                {
                    list.Add(pointer.Word);
                    pointer = pointer.Prev;
                }
                list.Reverse();
                newRes.Add(list);
            }

            return newRes;
        }

        private bool IsDifferByAChar(string s1, string s2)
        {
            return s1.Where((ch, i) => ch != s2[i]).Count() == 1;
        }

        public void Test()
        {
            var res = FindLadders("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });
        }
    }

    public class Route
    {
        public Route(string word, int level, Route prev)
        {
            Word = word;
            Level = level;
            Prev = prev;
        }
        public string Word { get; set; }
        public int Level { get; set; }
        public Route Prev { get; set; }
    }
}
