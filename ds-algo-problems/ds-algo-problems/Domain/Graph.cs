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
        public int Data { get; set; }
        public List<Graph> Descendant { get; set; }
    }
}
