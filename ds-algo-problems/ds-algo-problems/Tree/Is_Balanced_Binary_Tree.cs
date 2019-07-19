using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class IsBalancedBinaryTree1
    {
        /// <summary>
        /// Balanced Binary Tree
        /// a binary tree in which the depth of the two subtrees of every node 
        /// never differ by more than 1.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalancedBinaryTree(TreeNode root)
        {
            if (root == null) return true;

            if (System.Math.Abs(GetHeight(root.left) - GetHeight(root.right)) < 2)
            {
                return this.IsBalancedBinaryTree(root.left) && this.IsBalancedBinaryTree(root.right);
            }

            return false;
        }


        public int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftHeight = GetHeight(root.left);
            var rightHeight = GetHeight(root.right);

            return System.Math.Max(leftHeight, rightHeight) + 1;

        }

        /// <summary>
        /// above problem can be solved by below more efficient algo
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced2(TreeNode root)
        {
            if (root == null) return true;
            var left = IsBalancedHelper(root.left);
            var right = IsBalancedHelper(root.right);

            if (left == -1 || right == -1) return false;
            if (System.Math.Abs(left - right) >= 2) return false;

            return true;
        }

        private int IsBalancedHelper(TreeNode root)
        {
            if (root == null) return 0;

            var left = IsBalancedHelper(root.left);
            var right = IsBalancedHelper(root.right);

            if (left == -1 || right == -1) return -1;
            if (System.Math.Abs(left - right) >= 2) return -1;

            return System.Math.Max(left, right) + 1;
        }
    }
}
