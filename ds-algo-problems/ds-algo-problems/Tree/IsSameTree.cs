using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class IsSameTree1
    {
        /// <summary>
        /// Given two binary trees, write a function to check if they are the same or not.
        //Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;

            if (a.data != b.data) return false;

            return IsSameTree(a.left, b.left) && IsSameTree(a.right, b.right);
        }
    }
}
