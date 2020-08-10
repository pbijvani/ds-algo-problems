using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
         Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

        For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

        Example:

        Given the sorted array: [-10,-3,0,5,9],

        One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

              0
             / \
           -3   9
           /   /
         -10  5

        https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
     */
    public class sorted_array_to_bst
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            var len = nums.Length;

            return SortedArrayToBSTHelper(nums, 0, len - 1);
        }

        public TreeNode SortedArrayToBSTHelper(int[] nums, int left, int right)
        {
            if(left > right)
            {
                return null;
            }
            else
            {
                var mid = (left + right) / 2;

                var root = new TreeNode(nums[mid]);

                root.left = SortedArrayToBSTHelper(nums, left, mid - 1);
                root.right = SortedArrayToBSTHelper(nums, mid + 1, right);

                return root;
            }            
        }

        public TreeNode SortedArrayToBSTIterative(int[] nums)
        {
            var len = nums.Length;

            if (len == 0) return null;

            var left = 0;
            var right = len - 1;            

            var queue = new Queue<TreeNodeWithBound>();

            var root = new TreeNode(0);

            queue.Enqueue(new TreeNodeWithBound(root, left, right));

            while(queue.Any())
            {
                var queueLen = queue.Count;

                for(int i = 0; i < queueLen; i++)
                {
                    var node = queue.Dequeue();

                    var mid = (node.LeftBound + node.RightBound) / 2;

                    node.Node.data = nums[mid];

                    if(node.LeftBound < mid)
                    {
                        node.Node.left = new TreeNode(0);
                        queue.Enqueue(new TreeNodeWithBound(node.Node.left, node.LeftBound, mid - 1));
                    }

                    if(mid < node.RightBound)
                    {
                        node.Node.right = new TreeNode(0);
                        queue.Enqueue(new TreeNodeWithBound(node.Node.right, mid + 1, node.RightBound));
                    }
                }
            }

            return root;
        }
    }

    public class TreeNodeWithBound
    {
        public TreeNodeWithBound(TreeNode _node, int _left, int _right)
        {
            Node = _node;
            LeftBound = _left;
            RightBound = _right;
        }
        public TreeNode Node { get; set; }
        public int LeftBound { get; set; }
        public int RightBound { get; set; }
    }
}
