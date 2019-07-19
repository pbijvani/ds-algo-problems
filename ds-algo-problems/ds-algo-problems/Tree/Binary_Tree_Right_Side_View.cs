using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class Binary_Tree_Right_Side_View
    {
        /// <summary>
        /// Binary Tree Right Side View
        /// Given a binary tree, 
        /// imagine yourself standing on the right side of it, 
        /// return the values of the nodes you can see ordered from top to bottom
        /// </summary>
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        public void BinaryTreeRightSideView(TreeNode root, bool isRightSide, int depth)
        {
            if (root == null) return;

            if (!dict.ContainsKey(depth)) dict.Add(depth, root.data);

            BinaryTreeRightSideView(root.right, true, depth + 1);
            BinaryTreeRightSideView(root.left, true, depth + 1);
        }
    }
}
