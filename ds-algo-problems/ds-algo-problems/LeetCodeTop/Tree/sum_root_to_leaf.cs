using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
     * https://leetcode.com/problems/sum-root-to-leaf-numbers/
     * 
        Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

        An example is the root-to-leaf path 1->2->3 which represents the number 123.

        Find the total sum of all root-to-leaf numbers.

        Note: A leaf is a node with no children.

        Example:

        Input: [1,2,3]
            1
           / \
          2   3
        Output: 25
        Explanation:
        The root-to-leaf path 1->2 represents the number 12.
        The root-to-leaf path 1->3 represents the number 13.
        Therefore, sum = 12 + 13 = 25.
        Example 2:

        Input: [4,9,0,5,1]
            4
           / \
          9   0
         / \
        5   1
        Output: 1026
        Explanation:
        The root-to-leaf path 4->9->5 represents the number 495.
        The root-to-leaf path 4->9->1 represents the number 491.
        The root-to-leaf path 4->0 represents the number 40.
        Therefore, sum = 495 + 491 + 40 = 1026.
     
     */
    public class sum_root_to_leaf
    {
        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var res = helper(root, 0);
            return res;
        }

        public int helper(TreeNode root, int runningSum)
        {
            runningSum = (runningSum * 10) + root.data;

            if (root.left == null && root.right == null)
            {
                return runningSum;
            }

            var leftSum = 0;
            var rightSum = 0;            
                        
            leftSum = root.left == null ? 0 : helper(root.left, runningSum);
            rightSum = root.right == null ? 0 : helper(root.right, runningSum);

            return leftSum + rightSum;

        }

        public void test()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var res = SumNumbers(root);
        }
    }
}
