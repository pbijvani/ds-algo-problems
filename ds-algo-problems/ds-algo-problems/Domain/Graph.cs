using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Domain
{
    public class Graph
    {
        public Graph(int data)
        {
            this.Data = data;
        }
        public Graph(int data, int weight)
        {
            this.Data = data;
            this.Weight = weight;
        }
        public int Data { get; set; }
        public int Weight { get; set; }
        public List<Graph> Descendant { get; set; }
    }
}
