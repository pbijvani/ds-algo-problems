using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    public class minimum_depth_of_binary_tree
    {
        /*
         * https://leetcode.com/problems/minimum-depth-of-binary-tree/
         */
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            var leftDepth = MinDepth(root.left);
            var rightDepth = MinDepth(root.right);

            if(leftDepth == 0)
            {
                return rightDepth + 1;
            }
            else if(rightDepth == 0)
            {
                return leftDepth + 1;
            }
            else
            {
                return System.Math.Min(leftDepth, rightDepth) + 1;
            }            
        }

        /*
         * Once we found size of left tree and if right tree has more depth than left
         * we dont need to fully traverse right
         */

        public int MinDepth(TreeNode root, int runningHeight, int leftMinDepth)
        {            
            var leftSize = root.left == null ? 0 : MinDepth(root.left, runningHeight + 1, -1);

            var rightSize = 0;

            if(runningHeight == leftMinDepth) // right sub tree is equal or larger
            {
                return runningHeight;
            }
            else if(root.right == null)
            {
                rightSize = 0;
            }
            else
            {
                rightSize = MinDepth(root.right, runningHeight + 1, leftSize);
            }

            if(leftSize == 0 && rightSize == 0)
            {
                return runningHeight;
            }
            else
            {
                return (leftSize == 0 || rightSize == 0) ? leftSize + rightSize : System.Math.Min(leftSize, rightSize);
            }            
        }
        // Using BFS
        public int MinDepthUsingBFS(TreeNode root)
        {
            if (root == null) return 0;

            var queue = new Queue<Tuple<TreeNode, int>>();

            queue.Enqueue(new Tuple<TreeNode, int>(root, 1));
            
            while(queue.Any())
            {
                var node = queue.Dequeue();

                if(node.Item1.left == null && node.Item1.right == null) // Found first leaf node. and that is the min depth
                {
                    return node.Item2;
                }

                if(node.Item1.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.Item1.left, node.Item2 + 1));
                }

                if (node.Item1.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.Item1.right, node.Item2 + 1));
                }
            }

            return 0;
        }

        public void test()
        {
            //var root = new TreeNode(1)
            //{
            //    left = new TreeNode(2)
            //};

            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                }
            };

            var res = MinDepth(root, 1, -1);
        }


    }
}
