using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Graph1.Problems
{
    public class bfs_with_trace_path
    {
        public int[] ShortestPath(int[] vertices, int[,] edges, int source, int target)
        {
            var adjList = new Dictionary<int, List<int>>();

            foreach(var v in vertices)
            {
                adjList.Add(v, new List<int>());
            }

            var lenX = edges.GetLength(0);
            for (int i = 0; i < lenX; i++)
            {
                var from = edges[i, 0];
                var to = edges[i, 1];

                // Note : considering graph is directed
                adjList[from].Add(to);
                
                // If it was undirected, we need to uncomment below
                //adjList[to].Add(from);
            }

            var visited = new HashSet<int>();
            var parent = new Dictionary<int, int>();

            var queue = new Queue<int>();

            queue.Enqueue(source);
            visited.Add(source);
            parent.Add(source, -1);

            while(queue.Any())
            {
                var currV = queue.Dequeue();

                if(currV == target)
                {
                    return TracePath(source, target, parent);
                }                

                foreach(var item in adjList[currV])
                {
                    if(!visited.Contains(item))
                    {
                        queue.Enqueue(item);

                        visited.Add(item);

                        if(parent.ContainsKey(item))
                        {
                            parent[item] = currV;
                        }
                        else
                        {
                            parent.Add(item, currV);
                        }                        
                    }
                }
            }

            return new int[] { };
        }

        private int[] TracePath(int src, int dest, Dictionary<int, int> parent)
        {
            var shortestPath = new List<int>();

            var node = dest;

            while(node != -1)
            {
                shortestPath.Add(node);
                node = parent[node];
            }

            shortestPath.Reverse();

            return shortestPath.ToArray();
        }

        public void test()
        {
            var vertices = new int[] { 1, 2, 3, 4, 6, 8 };
            var edges = new int[,] 
            { 
                { 1, 2 },
                { 1, 3 },
                { 2, 3 },
                { 2, 4 },
                { 3, 4 },
                { 3, 6 },
                { 3, 8 },
                { 4, 6 },
                { 4, 8 },
                { 6, 8 }
            };

            var path = ShortestPath(vertices, edges, 1, 8);
        }
    }
}
