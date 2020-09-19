using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://leetcode.com/problems/search-suggestions-system/
     * https://leetcode.com/problems/search-suggestions-system/discuss/436151/JavaPython-3-Simple-Trie-and-Binary-Search-codes-w-comment-and-brief-analysis.
        Given an array of strings products and a string searchWord. We want to design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with the searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.

        Return list of lists of the suggested products after each character of searchWord is typed. 

        Example 1:

        Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
        Output: [
        ["mobile","moneypot","monitor"],
        ["mobile","moneypot","monitor"],
        ["mouse","mousepad"],
        ["mouse","mousepad"],
        ["mouse","mousepad"]
        ]
        Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"]
        After typing m and mo all products match and we show user ["mobile","moneypot","monitor"]
        After typing mou, mous and mouse the system suggests ["mouse","mousepad"]
        Example 2:

        Input: products = ["havana"], searchWord = "havana"
        Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
        Example 3:     
     */
    public class trie_search_suggession
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            TrieNode root = new TrieNode();
            System.Array.Sort(products);

            foreach(var p in products)
            {
                var trie = root;
                foreach(var ch in p)
                {
                    var index = ch - 'a';
                    if(trie.Children[index] == null)
                    {
                        trie.Children[index] = new TrieNode();
                    }
                    trie = trie.Children[index];

                    if(trie.Suggession.Count < 3)
                    {
                        trie.Suggession.Add(p);
                    }
                }
            }

            var ans = new List<IList<string>>();

            var searchRoot = root;

            foreach(var ch in searchWord)
            {
                if(searchRoot != null)
                {
                    var index = ch - 'a';

                    searchRoot = searchRoot.Children[index];
                }
                if (searchRoot != null)
                {
                    ans.Add(searchRoot.Suggession);
                }
                else
                {
                    ans.Add(new List<string>());
                }

            }

            return ans;
        }

        public void test()
        {
            //var product = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            //var searchWord = "mouse";

            var product = new string[] { "havana" };
            var searchWord = "tatiana";

            var res = SuggestedProducts(product, searchWord);
        }
    }

    public class TrieNode
    {
        public TrieNode[] Children { get; set; }
        public List<string> Suggession { get; set; }
        public TrieNode()
        {
            this.Children = new TrieNode[26];
            this.Suggession = new List<string>();
        }
    }
}
