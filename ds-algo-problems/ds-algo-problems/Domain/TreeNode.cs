using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Domain
{
    public class TreeNode
    {
        public TreeNode(int x)
        {
            data = x;
        }
        public int data { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

    }
}
