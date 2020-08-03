using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Graph_Matrix
{
    /*
        In a undirected graph, find number of connected component

        http://buttercola.blogspot.com/2016/01/leetcode-number-of-connected-components.html
        https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
     
     */
    public class connected_component_in_undirected_graph
    {
        #region DSF
        public int CountConnectedComponentDSF(int n, int[,] edges)
        {
            var adjList = new List<List<int>>();
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }

            var noOfEdges = edges.GetLength(0);

            for(int i = 0; i < noOfEdges; i++)
            {
                var from = edges[i,0];
                var to = edges[i,1];

                adjList[from].Add(to);
                adjList[to].Add(from);
            }

            int connectedComponent = 0;
            for(int i = 0; i < n; i++)
            {
                if(!visited[i])
                {
                    DSFHelper(adjList, i, visited);
                    connectedComponent++;
                }
            }

            return connectedComponent;
        }

        public void DSFHelper(List<List<int>> adjList, int currV, bool[] visited)
        {
            visited[currV] = true;

            foreach(var V in adjList[currV])
            {
                if(!visited[V])
                {
                    DSFHelper(adjList, V, visited);
                }
            }
        }
        #endregion

        #region BFS

        public int CountConnectedComponentBSF(int n, int[,] edges)
        {
            var adjList = new List<List<int>>();
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }

            var noOfEdges = edges.GetLength(0);

            for (int i = 0; i < noOfEdges; i++)
            {
                var from = edges[i, 0];
                var to = edges[i, 1];

                adjList[from].Add(to);
                adjList[to].Add(from);
            }

            var queue = new Queue<int>();
            var connectedComponent = 0;

            for(int i = 0; i < n; i++)
            {
                if(!visited[i])
                {
                    queue.Enqueue(i);

                    while(queue.Any())
                    {
                        var queueItem = queue.Dequeue();
                        visited[queueItem] = true;

                        foreach(var v in adjList[queueItem])
                        {
                            if(!visited[v])
                            {
                                queue.Enqueue(v);
                            }
                        }
                    }
                    connectedComponent++;
                }
            }
            return connectedComponent;
        }
        #endregion

        #region Union-Find Method

        private int[] father;
        public int countComponents(int n, int[,] edges)
        {

            var set = new HashSet<int>();
            father = new int[n];
            for (int i = 0; i < n; i++)
            {
                father[i] = i;
            }
            for (int i = 0; i < edges.Length; i++)
            {
                union(edges[i,0], edges[i,1]);
            }

            for (int i = 0; i < n; i++)
            {
                set.Add(find(i));
            }
            return set.Count;
        }

        int find(int node)
        {
            if (father[node] == node)
            {
                return node;
            }
            father[node] = find(father[node]);
            return father[node];
        }

        void union(int node1, int node2)
        {
            father[find(node1)] = find(node2);
        }

        #endregion

        public void test()
        {
            var arr = new int[,] { { 0, 1 }, { 1, 2 }, { 3, 4 } };

            //var count = CountConnectedComponentDSF(5, arr);

            //var count = CountConnectedComponentBSF(5, arr);

            var count = countComponents(5, arr);
        }
    }

     
}
