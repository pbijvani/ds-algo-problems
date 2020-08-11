using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

        For example:
        Given binary tree [3,9,20,null,null,15,7],
            3
           / \
          9  20
            /  \
           15   7
        return its zigzag level order traversal as:
        [
          [3],
          [20,9],
          [15,7]
        ]     

        https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

     */
    public class binary_tree_zigzag_level_order_traversal
    {      
        // BFS solution
        public List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return new List<List<int>>();

            var result = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            var depth = 0;

            queue.Enqueue(root);

            while (queue.Any())
            {
                var levelOrderList = new List<int>();

                var len = queue.Count;
                for (int i = 0; i < len; i++)
                {
                    var node = queue.Dequeue();

                    if(depth % 2 == 0)
                        levelOrderList.Add(node.data);
                    else
                        levelOrderList.Insert(0, node.data);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                depth = depth + 1;
                result.Add(levelOrderList);
            }

            return result;
        }

        public void test()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
                {                    
                    right = new TreeNode(5)
                }
            };

            var res = ZigzagLevelOrder(root);
        }

        // DFS solution
        public List<List<int>> ZigzagLevelOrderDFS(TreeNode root)
        {
            var res = new List<List<int>>();

            ZigzagLevelOrderDFSHelper(res, root, 0);

            return res;
        }

        public void ZigzagLevelOrderDFSHelper(List<List<int>> res, TreeNode root, int depth)
        {
            if (root == null) return;

            if(res.Count < depth + 1)
            {
                res.Add(new List<int>());
            }

            if(depth % 2 == 0)
            {
                res[depth].Add(root.data);
            }
            else
            {
                res[depth].Insert(0, root.data);
            }

            ZigzagLevelOrderDFSHelper(res, root.left, depth + 1);
            ZigzagLevelOrderDFSHelper(res, root.right, depth + 1);
        }
    }
}
