using ds_algo_problems.Graph1.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Graph1.Problems
{
    public class cheapest_flight_with_k_stop
    {
        private int minCost = int.MaxValue;
        public int CheapestFlight(int n, List<Edge> flights, int src, int dest, int k)
        {
            if (src == dest) return 0;

            var dict = new Dictionary<int, List<Edge>>();
            foreach(var flight in flights)
            {
                if(dict.ContainsKey(flight.From))
                {
                    dict[flight.From].Add(flight);
                }
                else
                {
                    dict.Add(flight.From, new List<Edge>() { flight });
                }
            }

            var visisted = new bool[n];
            visisted[src] = true;

            dfs(dict, src, dest, k, 0, visisted);

            return minCost == int.MaxValue ? -1 : minCost;
        }

        public void dfs(Dictionary<int, List<Edge>> map, int src, int dst, int k, int cost, bool[] visited)
        {
            if(src == dst)
            {
                minCost = System.Math.Min(minCost, cost);
                return;
            }

            if(k < 0)
            {
                return;
            }

            var edges = map.ContainsKey(src) ? map[src] : new List<Edge>();

            if(edges.Any())
            {
                foreach(var edge in edges)
                {
                    if(!visited[edge.To] && cost + edge.Weight < minCost)
                    {
                        visited[edge.To] = true;
                        dfs(map, edge.To, dst, k - 1, cost + edge.Weight, visited);
                        visited[edge.To] = false;
                    }
                }
            }
        }

        // Sol 2: we can use BFS instead of DFS

        // Sol 3:

        public int findCheapestPrice(int n, List<Edge> flights, int src, int dst, int K)
        {
            int[] dp = new int[n + 1];
            int MAX = int.MaxValue;
            for (int i = 0; i <= n; i++) dp[i] = MAX;

            dp[src] = 0;

            for (int i = 0; i <= K; i++)
            {
                int[] temp = new int[n + 1];
                System.Array.Copy(dp, 0, temp, 0, n + 1);
                foreach(var flight in flights)
                {
                    int u = flight.From, v = flight.To, cost = flight.Weight;
                    
                    temp[v] = System.Math.Min(temp[v], dp[u] == int.MaxValue ? int.MaxValue : dp[u] + cost);
                }
                dp = temp;
            }

            return dp[dst] == MAX ? -1 : dp[dst];
        }

        public int Test()
        {
            var edges = new List<Edge>()
            {
                new Edge(0, 1, 10),
                new Edge(0, 2, 30),
                new Edge(1, 2, 10),
                new Edge(1, 3, 20),
                new Edge(2, 3, 20),
                new Edge(2, 4, 10),
                new Edge(3, 3, 20)
            };
            int n = 5;

            var res = findCheapestPrice(n, edges, 0, 4, 3);

            return res;
        }
    }

    
}
