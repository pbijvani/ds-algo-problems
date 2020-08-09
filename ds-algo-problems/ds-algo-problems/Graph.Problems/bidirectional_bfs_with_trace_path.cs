using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Graph1.Problems
{
    public class bidirectional_bfs_with_trace_path
    {
        public int[] ShortestPath(int[] vertices, int[,] edges, int source, int target)
        {
            var adjList = new Dictionary<int, List<int>>();

            foreach (var v in vertices)
            {
                adjList.Add(v, new List<int>());
            }

            var lenX = edges.GetLength(0);
            for (int i = 0; i < lenX; i++)
            {
                var from = edges[i, 0];
                var to = edges[i, 1];

                adjList[from].Add(to);
                adjList[to].Add(from);
            }

            Queue<int> queueSrc = new Queue<int>();
            Queue<int> queueDest = new Queue<int>();

            var visitedSrc = new HashSet<int>();
            var visitedDest = new HashSet<int>();

            var parentSrc = new Dictionary<int, int>();
            var parentDest = new Dictionary<int, int>();
     
            queueSrc.Enqueue(source);
            visitedSrc.Add(source);
            parentSrc.Add(source, -1);

            queueDest.Enqueue(target);
            visitedDest.Add(target);
            parentDest.Add(target, -1);

            int matchedNode = -1;

            while (queueSrc.Any() || queueDest.Any())
            {
                matchedNode = PathExistsHelper(queueSrc, visitedSrc, visitedDest, adjList, parentSrc);
                if (matchedNode != -1)
                {
                    return TracePath(source, target, parentSrc, parentDest, matchedNode);
                }

                matchedNode = PathExistsHelper(queueDest, visitedDest, visitedSrc, adjList, parentDest);
                if (matchedNode != -1)
                {
                    return TracePath(source, target, parentSrc, parentDest, matchedNode);
                }
            }

            return new int[] { };
        }

        private int[] TracePath(int src, int dest, Dictionary<int, int> parentSrc, Dictionary<int, int> parentDest, int matchedNode)
        {
            var shortestPath = new List<int>();

            var node = matchedNode;

            while (node != -1)
            {
                shortestPath.Add(node);
                node = parentSrc[node];
            }

            node = parentDest[matchedNode];
            while(node != -1)
            {
                shortestPath.Insert(0, node);
                node = parentDest[node];
            }

            shortestPath.Reverse();

            return shortestPath.ToArray();
        }

        private int PathExistsHelper(Queue<int> queue, HashSet<int> visistedFromThisSide, HashSet<int> visistedFromOtherSide, Dictionary<int, List<int>> adjList, Dictionary<int, int> parent)
        {
            if (queue.Any())
            {
                var currNode = queue.Dequeue();

                var adjucentNodes = adjList[currNode];

                foreach (var node in adjucentNodes)
                {
                    if (visistedFromOtherSide.Contains(node))
                    {
                        // Node is already visited from otehr side. We found the path.

                        // Add node into parent map
                        if (parent.ContainsKey(node))
                        {
                            parent[node] = currNode;
                        }
                        else
                        {
                            parent.Add(node, currNode);
                        }

                        return node;
                    }

                    if (!visistedFromThisSide.Contains(node))
                    {
                        // if node is not visisted from this side then add it to queue
                        queue.Enqueue(node);
                        visistedFromThisSide.Add(node);

                        if (parent.ContainsKey(node))
                        {
                            parent[node] = currNode;
                        }
                        else
                        {
                            parent.Add(node, currNode);
                        }
                    }
                }
            }

            return -1;
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
                //{ 3, 8 },
                { 4, 6 },
                { 4, 8 },
                { 6, 8 }
            };

            var path = ShortestPath(vertices, edges, 1, 8);
        }
    }
}
