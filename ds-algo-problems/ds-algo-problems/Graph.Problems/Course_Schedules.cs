using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Graph.Problems
{
    class Course_Schedules
    {
        /// <summary>
        /// Course Schedule
        /// There are a total of n courses you have to take, labeled from 0 to n-1
        /// Some courses may have prerequisites, 
        /// for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
        /// Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
        /// 4, [[1,0],[2,0],[3,1],[3,2]]
        /// True, correct order [0,1,2,3]
        /// Usage of graph
        /// </summary>
        bool[] visited;
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            visited = new bool[numCourses];
            var res = new List<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    var returns = FindOrderDFS(numCourses, prerequisites, i, new List<int>());
                    if (returns == null) return null;
                    res.AddRange(returns);
                }
            }

            res.Reverse();
            return res.ToArray();
        }

        private int[] FindOrderDFS(int numCourses, int[,] prerequisites, int start, List<int> parents)
        {

            var res = new List<int>();

            int rows = prerequisites.GetLength(0);
            int columns = prerequisites.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (prerequisites[i, 1] == start && !visited[prerequisites[i, 0]])
                {
                    if (parents.Contains(prerequisites[i, 0]))
                    {
                        return null;
                    }
                    parents.Add(start);
                    var rest = FindOrderDFS(numCourses, prerequisites, prerequisites[i, 0], parents);

                    if (rest == null)
                    {
                        return null;
                    }
                    res.AddRange(rest);
                }
            }

            res.Add(start);
            visited[start] = true;

            return res.ToArray();
        }

        /***************************************/

        public int[] TopologicalSort(int n, Dictionary<int, List<Tuple<int, int>>> graph)
        {
            bool[] visited = new bool[n];
            int[] order = new int[n];

            int i = n - 1;
            for (int at = 0; at < n; at++)
            {
                if (!visited[at])
                {
                    i = dfs(i, at, visited, order, graph);
                }
            }

            return order;
        }

        private int dfs(int i, int at, bool[] visited, int[] order, Dictionary<int, List<Tuple<int, int>>> graph)
        {

            visited[at] = true;

            var edges = graph[at];

            foreach (var edge in edges)
            {
                if (!visited[edge.Item2])
                {
                    i = dfs(i, at, visited, order, graph);
                }
            }

            order[i] = at;
            return i - 1;
        }
    }
}
