using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ds_algo_problems.Domain;

namespace ds_algo_problems.Graph1.Problems
{
    class graph_dfs_bfs_other_methods
    {
        public void IsPathExists()
        {
            visited = new Dictionary<int, bool>();

            Graph item1 = new Graph(100);
            Graph root = new Graph(20)
            {
                Descendant = new List<Graph>()
                {
                    new Graph(10)
                    {
                        Descendant = new List<Graph>()
                        {
                            new Graph(22)
                            {
                            },
                            item1
                        }
                    },
                    new Graph(40)
                    {
                        Descendant = new List<Graph>()
                        {
                            new Graph(32)
                            {
                            },
                            item1
                        }
                    },
                    new Graph(50)
                    {
                        Descendant = new List<Graph>()
                        {
                            new Graph(42)
                            {
                            },
                            item1
                        }
                    }
                }
            };

            //SearchDFS(root);
            SearchBFS(root);
        }

        Dictionary<int, bool> visited = null;

        public void SearchDFS(Graph node)
        {
            if (node == null) return;

            if (!visited.ContainsKey(node.Data))
            {
                visited.Add(node.Data, true);
            }


            Console.WriteLine(node.Data);

            if (node.Descendant != null)
            {
                foreach (var item in node.Descendant)
                {
                    if (!visited.ContainsKey(item.Data))
                    {
                        SearchDFS(item);
                    }
                }
            }

        }

        public void SearchBFS(Graph root)
        {
            Queue<Graph> queue = new Queue<Graph>();
            queue.Enqueue(root);

            Console.WriteLine(root.Data);

            visited.Add(root.Data, true);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node.Descendant == null) continue;
                foreach (var item in node.Descendant)
                {
                    if (visited.ContainsKey(item.Data)) continue;

                    Console.WriteLine(item.Data);
                    visited.Add(item.Data, true);
                    queue.Enqueue(item);
                }
            }
        }


        /*
         * Top Sort
        */
        int white = 0;
        int gray = 1;
        int black = 2;
        bool isPossible = true;
        int orderIndex = -1;
        public int[] TopologicalSort(Dictionary<int, List<Edge>> graph, int numNodes)
        {

            isPossible = true;
            var visited = new int[numNodes];
            var order = new int[numNodes];

            orderIndex = numNodes - 1;

            for (int at = 0; at < numNodes; at++)
            {
                if (visited[at] == white)
                {
                    TopSortDFS(graph, at, visited, order);
                }
            }

            return order;
        }

        public void TopSortDFS(Dictionary<int, List<Edge>> graph, int at, int[] visited, int[] order)
        {
            if (isPossible == false) return;

            visited[at] = gray;

            var edges = graph.ContainsKey(at) ? graph[at] : new List<Edge>();

            foreach (var edge in edges)
            {
                if (visited[edge.To] == white)
                {
                    TopSortDFS(graph, edge.To, visited, order);
                }
                else if (visited[edge.To] == gray)
                {
                    isPossible = false;
                }
            }

            visited[at] = black;
            order[orderIndex] = at;
            orderIndex--;
        }

        public void TestTopologicalSort()
        {
            int n = 4;
            var graph = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            graph[0].Add(new Edge(0, 1, 1));
            graph[0].Add(new Edge(0, 2, 1));
            graph[1].Add(new Edge(1, 3, 1));
            graph[2].Add(new Edge(2, 3, 1));
            //graph[1].Add(new Edge(1, 0, 1)); this causes cycle

            var order = TopologicalSort(graph, 4);
        }

        public void TestShortestPath()
        {
            int n = 4;
            var graph = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            graph[0].Add(new Edge(0, 1, 1));
            graph[0].Add(new Edge(0, 2, 2));
            graph[1].Add(new Edge(1, 3, 6));
            graph[2].Add(new Edge(2, 3, 3));


            int start = 0;

            var order = TopologicalSort(graph, 4);
            var distance = new int?[n];
            distance[start] = 0;

            for (int i = 0; i < order.Length; i++)
            {
                int key = order[i];

                if (graph.ContainsKey(key))
                {
                    var edges = graph[key];

                    if (edges.Any())
                    {
                        foreach (var edge in edges)
                        {
                            var newDistance = distance[key] + edge.Weight;

                            if (distance[edge.To] == null)
                            {
                                distance[edge.To] = newDistance;
                            }
                            else
                            {
                                distance[edge.To] = Math.Min(distance[edge.To].Value, newDistance.Value);
                            }
                        }
                    }
                }
            }
        }
    }
    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public Edge(int from, int to, int weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }
}
