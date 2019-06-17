using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class MaxDepthOfBinaryTree1
    {
        /// <summary>
        /// Maximum Depth of Binary Tree
        /// </summary>
        /// <returns></returns>

        /// 1 + floor(log(n))
        public int MaxDepthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;

            var left = MaxDepthOfBinaryTree(root.left);
            var right = MaxDepthOfBinaryTree(root.right);

            return Math.Max(left, right) + 1;
        }
    }
}
