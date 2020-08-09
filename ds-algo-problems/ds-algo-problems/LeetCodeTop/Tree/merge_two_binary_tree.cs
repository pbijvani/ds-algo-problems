using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    public class merge_two_binary_tree
    {
        /*
            Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.

            You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of new tree.

            Example 1:

            Input: 
	            Tree 1                     Tree 2                  
                      1                         2                             
                     / \                       / \                            
                    3   2                     1   3                        
                   /                           \   \                      
                  5                             4   7                  
            Output: 
            Merged tree:
	                 3
	                / \
	               4   5
	              / \   \ 
	             5   4   7
 

            Note: The merging process must start from the root nodes of both trees.         
         */

        /*
            Complexity Analysis

            Time complexity : O(m)O(m). A total of mm nodes need to be traversed. Here, mm represents the minimum number of nodes from the two given trees.

            Space complexity : O(m)O(m). The depth of the recursion tree can go upto mm in the case of a skewed tree. In average case, depth will be O(logm)O(logm).         
         */
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            t1.data = t1.data + t2.data;

            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1;
        }

        // Iterative solution using stack

        public TreeNode MergerTreeIterative(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            var stack = new Stack<List<TreeNode>>();

            stack.Push(new List<TreeNode>() { t1, t2 });

            while(stack.Any())
            {
                var nodes = stack.Pop();

                if (nodes[0] == null || nodes[1] == null) continue;

                nodes[0].data = nodes[0].data = nodes[1].data;

                if(nodes[0].left == null)
                {
                    nodes[0].left = nodes[1].left;
                }
                else
                {
                    stack.Push(new List<TreeNode>() { nodes[0].left, nodes[1].left });
                }

                if (nodes[0].right == null)
                {
                    nodes[0].right = nodes[1].right;
                }
                else
                {
                    stack.Push(new List<TreeNode>() { nodes[0].right, nodes[1].right });
                }
            }

            return t1;
        }
    }
}
