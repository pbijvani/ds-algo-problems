using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Graph1.Problems
{
    public class bidirectional_bfs
    {
        public bool PathExists(Graph src, Graph dest)
        {
            Queue<Graph> queueSrc = new Queue<Graph>();
            Queue<Graph> queueDest = new Queue<Graph>();

            var visitedSrc = new HashSet<Graph>();
            var visitedDest = new HashSet<Graph>();

            queueSrc.Enqueue(src);
            queueDest.Enqueue(dest);

            while(queueSrc.Any() || queueDest.Any())
            {
                if(PathExistsHelper(queueSrc, visitedSrc, visitedDest))
                {
                    return true;
                }

                if(PathExistsHelper(queueDest, visitedDest, visitedSrc))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PathExistsHelper(Queue<Graph> queue, HashSet<Graph> visistedFromThisSide, HashSet<Graph> visistedFromOtherSide)
        {
            if(queue.Any())
            {
                var currNode = queue.Dequeue();

                visistedFromThisSide.Add(currNode);

                var adjucentNodes = currNode.Descendant;

                foreach(var node in adjucentNodes)
                {
                    if(visistedFromOtherSide.Contains(node))
                    {
                        // Node is already visited from otehr side. We found the path.
                        return true;
                    }

                    if(!visistedFromThisSide.Contains(node))
                    {
                        // if node is not visisted from this side then add it to queue
                        queue.Enqueue(node);
                    }
                }
            }

            return false;
        }

        public void test()
        {
            var node0 = new Graph(0);
            var node1 = new Graph(1);
            var node4 = new Graph(4);
            var node6 = new Graph(6);
            var node7 = new Graph(7);
            var node9 = new Graph(9);
            var node10 = new Graph(10);
            var node11 = new Graph(11);
            var node12 = new Graph(12);

            node0.Descendant = new List<Graph>() { node4 };
            node1.Descendant = new List<Graph>() { node4 };
            node4.Descendant = new List<Graph>() { node0, node1, node6 };
            node6.Descendant = new List<Graph>() { node4, node7 };
            node7.Descendant = new List<Graph>() { node6, node9, node10 };
            node10.Descendant = new List<Graph>() { node7 };
            node9.Descendant = new List<Graph>() { node7, node11, node12 };
            node11.Descendant = new List<Graph>() { node9 };
            node12.Descendant = new List<Graph>() { node9 };

            var res = PathExists(node0, node12);
        }
    }

    public class GraphQueueItemWithDepth
    {
        public GraphQueueItemWithDepth(Graph graph, int depth)
        {
            this.Node = graph;
            this.Depth = depth;
        }
        public Graph Node { get; set; }
        public int Depth { get; set; }
    }
}
