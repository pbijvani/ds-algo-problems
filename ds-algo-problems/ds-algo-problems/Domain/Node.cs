using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Domain
{
    public class Node
    {
        public Node(int x)
        {
            data = x;
        }
        public int data { get; set; }
        public Node next { get; set; }

    }
}
