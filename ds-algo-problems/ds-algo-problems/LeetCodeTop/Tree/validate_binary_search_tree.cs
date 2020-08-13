using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given a binary tree, determine if it is a valid binary search tree (BST).

        Assume a BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees.
 

        Example 1:

            2
           / \
          1   3

        Input: [2,1,3]
        Output: true
        Example 2:

            5
           / \
          1   4
             / \
            3   6

        Input: [5,1,4,null,null,3,6]
        Output: false
        Explanation: The root node's value is 5 but its right child's value is 4.     

        https://leetcode.com/problems/validate-binary-search-tree/

     */
    public class validate_binary_search_tree
    {
        //  Approach 1 : at each node, recurese left and right sub tree to check if it meets BST condition.
        // Not efficient
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            return IsValidBSTHelper(root.left, root.data, true) &&
                IsValidBSTHelper(root.right, root.data, false) &&
                IsValidBST(root.left) &&
                IsValidBST(root.right);
        }


        public bool IsValidBSTHelper(TreeNode root, int Val, bool isLess)
        {
            if (root == null) return true;

            if (isLess)
            {
                if (root.data >= Val) return false;
            }
            else
            {
                if (root.data <= Val) return false;
            }

            return IsValidBSTHelper(root.left, Val, isLess) && IsValidBSTHelper(root.right, Val, isLess);

        }

        // APproach 2 : efficient, pass min, max to each node and make descision
        //Time complexity : \mathcal{O}(N)O(N) since we visit each node exactly once.
        //Space complexity : \mathcal{O}(N)O(N) since we keep up to the entire tree.
        public bool IsValidBST1(TreeNode root)
        {
            return IsValidBSTHelper(root, null, null);
        }

        public bool IsValidBSTHelper(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;

            if (!IsBetween(root.data, min, max))
            {
                return false;
            }

            if (!IsValidBSTHelper(root.left, min, root.data)) return false;
            if (!IsValidBSTHelper(root.right, root.data, max)) return false;
            return true;
        }

        private bool IsBetween(int num, int? min, int? max)
        {

            return (min == null || min < num) && (max == null || num < max);

        }

        // Aproach 3 : in order traversal . Tree inorder traversal need to be sorted if tree is bst
        // O(N) both time and space
        public bool IsValidBST2(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var inorder = int.MinValue;

            while(stack.Any() || root != null)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if (inorder >= root.data) return false;
                inorder = root.data;
                root = root.right;
            }

            return true;
        }

    }
}
