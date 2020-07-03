using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    /*
     * Given a root of tree and two node, find common ancestor of two node.
     * option 1 : you can have a pointer to parent
     * Option 2: you do not have pointer to parent
     */
    public class tree_common_ancestor
    {
        public void Test()
        {
            TreeNode root = new TreeNode(100)
            {
                left = new TreeNode(50)
                {
                    left = new TreeNode(30)
                    {
                        left = new TreeNode(10),
                        right = new TreeNode(35)
                    },
                    right = new TreeNode(75)
                    {
                        left = new TreeNode(60),
                        right = new TreeNode(80)
                    }
                },
                right = new TreeNode(150)
                {
                    left = new TreeNode(125)
                    {
                        left = new TreeNode(110),
                        right = new TreeNode(135)
                    },
                    right = new TreeNode(175)
                    {
                        left = new TreeNode(160),
                        right = new TreeNode(180)
                    }
                }
            };

            var res = GetCommonAncestorWithoutParent(root, root.left.left.left, root.left.right);
        }

        public TreeNodeWithParent GetCommonAncestor(TreeNodeWithParent root, TreeNodeWithParent a, TreeNodeWithParent b)
        {
            if (a == b) return a;
            if (a.Parent == b) return b;
            if (b.Parent == a) return a;

            var lenA = GetLength(a);
            var lenB = GetLength(b);

            var lenDiff = System.Math.Abs(lenA - lenB);

            var shorter = lenA > lenB ? b : a;
            var longer = lenA > lenB ? a : b;

            while(lenDiff > 0)
            {
                longer = longer.Parent;
                lenDiff--;
            }

            while(shorter != null && longer != null)
            {
                if (shorter == longer) return shorter;

                shorter = shorter.Parent;
                longer = longer.Parent;
            }

            return null;
        }

                
        public TreeNode GetCommonAncestorWithoutParent(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root == null) return null;

            var leftRes = GetCommonAncestorWithoutParent(root.left, a, b);

            if(leftRes != null && leftRes != a && leftRes != b)
            {
                return leftRes;
            }

            var rightRes = GetCommonAncestorWithoutParent(root.right, a, b);

            if(rightRes != null && rightRes != a && rightRes != b)
            {
                return rightRes;
            }

            if(leftRes != null && rightRes != null)
            {
                return root;
            }

            if(leftRes != null || rightRes != null)
            {
                return leftRes == null ? rightRes : leftRes;
            }

            if (root == a || root == b) return root;

            return null;
        }

        /*
         * above code has limitation. If you have a and b arranged as below in same branch of tree it doesnt work
         *        a
         *      /
         *     b
         *     
         *     it should return a, but it will return b
         */
        public TreeNodeWithResult GetCommonAncestorWithoutParent1(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root == null) return null;

            var leftRes = GetCommonAncestorWithoutParent1(root.left, a, b);

            if (leftRes != null && leftRes.IsResult)
            {
                return leftRes;
            }

            var rightRes = GetCommonAncestorWithoutParent1(root.right, a, b);

            if (rightRes != null && rightRes.IsResult)
            {
                return rightRes;
            }

            if (leftRes != null && rightRes != null)
            {
                return new TreeNodeWithResult()
                {
                    Node = root,
                    IsResult = true
                };
            }
            else if (root == a || root == b)
            {
                return new TreeNodeWithResult()
                {
                    Node = root,
                    IsResult = leftRes != null || rightRes != null
                };
            }
            else
                return leftRes != null ? leftRes : (rightRes != null ? rightRes : null);
        }

        private int GetLength(TreeNodeWithParent a)
        {
            int len = 0;
            while(a != null)
            {
                len++;
                a = a.Parent;
            }
            return len;
        }
    }

    public class TreeNodeWithResult
    {        
        public TreeNode Node { get; set; }
        public bool IsResult { get; set; }
    }

    public class TreeNodeWithParent
    {
        public int data { get; set; }
        public TreeNodeWithParent Left { get; set; }
        public TreeNodeWithParent Right { get; set; }
        public TreeNodeWithParent Parent { get; set; }
    }
}
