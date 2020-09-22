using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    /*
     * Find Related Products
     * 
     * https://leetcode.com/discuss/interview-question/782606/
     * https://aonecode.com/amazon-online-assessment-find-related-books
     * 
     * Amazon online assessment problem
     */
    public class amazon_OA_2020_1
    {
        public List<string> largestItemAssociation(List<PairString> itemAssociation)
        {
            var map = new Dictionary<string, List<string>>();

            foreach(var item in itemAssociation)
            {
                if(!map.ContainsKey(item.first))
                {
                    map.Add(item.first, new List<string>());
                }
                if (!map.ContainsKey(item.second))
                {
                    map.Add(item.second, new List<string>());
                }

                map[item.first].Add(item.second);
                map[item.second].Add(item.first);
            }

            var visitedMap = new HashSet<string>();
            var connectedComponent = new List<List<string>>();

            foreach(var item in map)
            {
                var node = item.Key;
                if(!visitedMap.Contains(node))
                {
                    var component = new List<string>();

                    dfsHelper(map, node, visitedMap, component);

                    connectedComponent.Add(component);
                }
            }

            connectedComponent.Sort(new Comparer1());

            return connectedComponent[0];
        }

        public void dfsHelper(Dictionary<string, List<string>> map, string node, HashSet<string> visited, List<string> result)
        {
            result.Add(node);
            visited.Add(node);

            if(map.ContainsKey(node))
            {
                foreach(var nextNode in map[node])
                {
                    if(!visited.Contains(nextNode))
                    {
                        dfsHelper(map, nextNode, visited, result);
                    }
                }
            }
        }

        public void test()
        {
            var result = largestItemAssociation(new List<PairString>()
            {
                new PairString("item1", "item2"),
                new PairString("item3", "item4"),
                new PairString("item4", "item5")
            });
        }
    }

    public class PairString
    {
        public string first { get; set; }
        public string second { get; set; }

        public PairString(string first, string second)
        {
            this.first = first;
            this.second = second;
        }
    }

    public class Comparer1 : IComparer<List<string>>
    {
        public int Compare(List<string> x, List<string> y)
        {
            if (x.Count == y.Count)
            {
                var first = x.First();
                var second = y.First();

                return first.CompareTo(second);
            }
            else
            {
                return x.Count > y.Count ? -1 : 1;
            }
        }
    }
}
