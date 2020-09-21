using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class tree_lowest_common_ancestor
    {
        /*
         * given a element from tree.
         * find lowst common ancestor (parent). Give Node itselft can be a ancestor
         */
        //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/submissions/
        public int LowestCommn(int node1, int node2)
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(15)
                    },
                    right = new TreeNode(2),
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(10),
                    right = new TreeNode(12)
                    {
                        right = new TreeNode(20)
                    },
                }
            };

            var stack1 = getPathToX(root, node1);
            var stack2 = getPathToX(root, node2);

            int commonAncestor = -1;
            while(stack1.Peek() == stack2.Peek())
            {
                commonAncestor = stack1.Pop();
                stack2.Pop();
            }

            return commonAncestor;
        }

        private Stack<int> getPathToX(TreeNode root, int x)
        {
            if (root == null) return null;

            if(root.data == x) return new Stack<int>(new int[] { x });

            var leftPath = getPathToX(root.left, x);
            if(leftPath != null)
            {
                leftPath.Push(root.data);
                return leftPath;
            }

            var rightPath = getPathToX(root.right, x);
            if(rightPath != null)
            {
                rightPath.Push(root.data);
                return rightPath;
            }

            return null;
        }

        // 9/20/2020
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return helper(root, p, q);
        }

        public TreeNode helper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root == p) return p;
            else if (root == q) return q;
            else
            {
                var leftRes = helper(root.left, p, q);
                var rightRes = helper(root.right, p, q);

                if(leftRes != null && rightRes != null)
                {
                    return root;
                }
                else if(leftRes != null || rightRes != null)
                {
                    return leftRes == null ? rightRes : leftRes;
                }
                else
                {
                    return null;
                }
            }

        }

        public void test()
        {
            var root = new TreeNode(100)
            {
                left = new TreeNode(50)
                {
                    left = new TreeNode(20)
                    {

                    },
                    right = new TreeNode(25)
                },
                right = new TreeNode(200)
                {
                    left = new TreeNode(250),
                    right = new TreeNode(255)
                }
            };

            var p = root.left;
            var q = root.left.right;

            var res = LowestCommonAncestor(root, p, q);

        }
    }
}
