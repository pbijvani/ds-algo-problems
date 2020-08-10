using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

        Note: A leaf is a node with no children.

        Example:

        Given the below binary tree and sum = 22,

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1
        return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.    

        https://leetcode.com/problems/path-sum/
     */
    public class path_sum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            return HasPathSumHelper(root, root.data, sum);
        }

        public bool HasPathSumHelper(TreeNode root, int runningSum, int target)
        {
            if(root.left == null && root.right == null)
            {
                return runningSum == target;
            }

            // If all positive number in tree then uncomment below optimization
            //if (runningSum > target) return false;

            var leftRes = root.left == null ? false : HasPathSumHelper(root.left, runningSum + root.left.data, target);

            var rightRes = root.right == null ? false : HasPathSumHelper(root.right, runningSum + root.right.data, target);

            return leftRes || rightRes;
        }

        public void test()
        {
            var root = new TreeNode(-2)
            {
                right = new TreeNode(-3)
            };

            var res = HasPathSum(root, -5);
        }
    }
}
