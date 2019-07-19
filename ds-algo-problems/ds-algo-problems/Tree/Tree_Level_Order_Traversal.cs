using ds_algo_problems.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class LevelOrderTraversal
    {
        /// <summary>
        /// Binary Tree Level Order Traversal II
        /// Given a binary tree, return the bottom-up level order traversal of its nodes' values. 
        /// (ie, from left to right, level by level from leaf to root).
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList> LevelOrder(TreeNode root)
        {
            var res = new List<IList>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var size = queue.Count;
                var one = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var top = queue.Dequeue();
                    if (top == null) continue;
                    one.Add(top.data);
                    queue.Enqueue(top.left);
                    queue.Enqueue(top.right);
                }
                if (one.Any())
                {
                    res.Add(one);
                }
            }
            return res;
        }

        IList<IList> orderLevel = new List<IList>();
        public IList<IList> LevelOrderII(TreeNode tree)
        {
            LevelOrderHelper(tree, 0);
            return orderLevel;
        }

        public void LevelOrderHelper(TreeNode root, int height)
        {
            if (root == null) return;
            if (orderLevel.Count == height)
            {
                orderLevel.Add(new List<int>());
            }
            orderLevel[height].Add(root.data);
            LevelOrderHelper(root.left, height + 1);
            LevelOrderHelper(root.right, height + 1);
        }
    }
}
