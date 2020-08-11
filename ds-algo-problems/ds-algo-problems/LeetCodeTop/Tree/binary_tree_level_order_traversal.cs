using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

        For example:
        Given binary tree [3,9,20,null,null,15,7],
            3
           / \
          9  20
            /  \
           15   7
        return its level order traversal as:
        [
          [3],
          [9,20],
          [15,7]
        ]    
        
        https://leetcode.com/problems/binary-tree-level-order-traversal/
     */
    public class binary_tree_level_order_traversal
    {

        // BFS
        public List<List<int>> LevelOrder(TreeNode root)
        {
            if (root == null) return new List<List<int>>();

            var result = new List<List<int>>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while(queue.Any())
            {
                var levelOrderList = new List<int>();
                var len = queue.Count;
                for (int i = 0; i < len; i++)
                {
                    var node = queue.Dequeue();

                    levelOrderList.Add(node.data);

                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(levelOrderList);
            }

            return result;
        }

        // DFS
        public List<List<int>> LevelOrderDFS(TreeNode root)
        {
            var res = new List<List<int>>();

            LevelOrderHelper(res, root, 0);

            return res;
        }

        public void LevelOrderHelper(List<List<int>> res, TreeNode root, int level)
        {
            if (root == null) return;

            if(res.Count < level + 1)
            {
                res.Add(new List<int>());
            }

            res[level].Add(root.data);

            if(root.left != null)
            {
                LevelOrderHelper(res, root.left, level + 1);
            }

            if(root.right != null)
            {
                LevelOrderHelper(res, root.right, level + 1);
            }

        }
    }
}
