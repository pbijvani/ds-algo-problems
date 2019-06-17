using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class Flattern_Tree_To_Linked_List
    {
        //Iterative
        public void Flatten(TreeNode root)
        {
            TreeNode newRoot = null;

            var myStack = new Stack<TreeNode>();

            if (root != null)
                myStack.Push(root);

            while (myStack.Count > 0)
            {
                var top = myStack.Pop();

                if (top.right != null)
                {
                    myStack.Push(top.right);
                    top.right = null;
                }

                if (top.left != null)
                {
                    myStack.Push(top.left);
                    top.left = null;
                }

                if (newRoot == null)
                {
                    newRoot = top;
                }
                else
                {
                    newRoot.right = top;
                    newRoot = top;
                }
            }
        }
        // Recursion of same idea above
        public void FlattenIterative(TreeNode root)
        {
            var previous = new List<TreeNode>();
            this.FlattenHelper(root, previous);

            var start = root;
            for (int i = 1; i < previous.Count; i++)
            {
                start.right = previous[i];
                start.left = null;

                start = start.right;
            }
        }

        private void FlattenHelper(TreeNode root, List<TreeNode> previous)
        {
            if (root == null) return;
            // visited root
            previous.Add(root);

            this.FlattenHelper(root.left, previous);
            this.FlattenHelper(root.right, previous);
        }


        //Modified Morris Traversal for preorder


        public void Flatten3(TreeNode root)
        {
            while (root != null)
            {
                if (root.left == null)
                {
                    root = root.right;
                }
                else
                {
                    var pre = root.left;
                    while (pre.right != null)
                    {
                        pre = pre.right;
                    }

                    pre.right = root.right;
                    root.right = root.left;
                    root.left = null;

                    root = root.right;
                }
            }
        }
    }
}
