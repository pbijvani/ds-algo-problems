using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    /*
     * https://www.geeksforgeeks.org/find-largest-subtree-sum-tree/
     * 
     * 
     * 
        Find largest subtree sum in a tree
        Last Updated: 13-02-2019
        Given a binary tree, task is to find subtree with maximum sum in tree.

        Examples:

        Input :       1
                    /   \
                   2      3
                  / \    / \
                 4   5  6   7
        Output : 28
        As all the tree elements are positive,
        the largest subtree sum is equal to
        sum of all tree elements.

        Input :       1
                    /    \
                  -2      3
                  / \    /  \
                 4   5  -6   2
        Output : 7
        Subtree with largest sum is :  -2
                                     /  \ 
                                    4    5
        Also, entire tree sum is also 7.
     */
    public class subtree_with_maximum_sum
    {
        public TreeNode SubtreeWithMaximumSum(TreeNode root)
        {
            var res = new TreeNodeWrapper1();
            helper(root, res);

            return res.Root;
        }

        public int helper(TreeNode root, TreeNodeWrapper1 result)
        {
            if (root == null) return 0;

            var leftTotal = helper(root.left, result);
            var rightTotal = helper(root.right, result);

            var totalAtThisLevel = leftTotal + rightTotal + root.data;
            
            if(totalAtThisLevel > result.Sum)
            {
                result.Sum = totalAtThisLevel;
                result.Root = root;
            }
            return totalAtThisLevel;
        }

        public void test()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(-2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(-6),
                    right = new TreeNode(2)
                }
            };

            var res = SubtreeWithMaximumSum(root);
        }
    }

    public class TreeNodeWrapper1
    {
        public int Sum { get; set; }
        public TreeNode Root { get; set; }
    }
}
