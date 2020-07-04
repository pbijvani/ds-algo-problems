using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    /*
     * check if one tree is sub tree of another
     */
    public class is_subtree
    {
        public  void test()
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

            var tree = new TreeNode(75)
            {
                left = new TreeNode(60),
                right = new TreeNode(81)
            };

            var res = IsSubTree(root, tree);
        }

        // convert tree to string : pre-order, inorder wont work
        // Null will be inserted as X
        // Run time O (n * n) because of substring method
        // Space : O(n + m)
        public bool IsSubTree1(TreeNode root, TreeNode tree)
        {
            var s1 = new StringBuilder();
            GetString(root, s1);

            var s2 = new StringBuilder();
            GetString(root, s2);

            // check if substring.
            return true;
        }

        public void GetString(TreeNode root, StringBuilder sb)
        {
            var key = root == null ? "X " : root.data + " ";
            sb.Append(key);

            GetString(root.left, sb);
            GetString(root.right, sb);
        }


        // Recursive method
        //  space : O (long(n) + long(m)) , worst case O(n+m) if tree is not balanced
        // time : Worst case : O (m * n) : if each node in T1 has same value as root of T2, will end up calling IsMatch for each node in T1
        // time : real run time : O(m + kn) : where k is then no of node where root of T2 match T1.
        // Even this overstate the run time, when we call IsMatch we do not always traverse each node in T2, as soon as we find its not a match we stop searching.
        public bool IsSubTree(TreeNode root, TreeNode tree)
        {
            if (root == null) return false;

            if (tree == null) return true;

            if(root.data == tree.data)
            {
                var res = IsSameTree(root, tree);
                if (res) return res;
            }

            var resLeft = IsSubTree(root.left, tree);

            if (resLeft) return true;

            var resRight = IsSubTree(root.right, tree);

            return resRight;
        }

        public bool IsSameTree(TreeNode t1, TreeNode t2)
        {
            if(t1 != null && t2 != null)
            {
                if (t1.data != t2.data) return false;

                var leftRes = IsSameTree(t1.left, t2.left);

                if (!leftRes) return false;

                return IsSameTree(t1.right, t2.right);                
            }

            if (t1 == null && t2 == null) return true;

            return false;

        }
        // another version of IsSameTree
        public bool IsMatch(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            else if (t1 == null || t2 == null) return false;
            else if (t1.data != t2.data) return false;
            else
            {
                return IsMatch(t1.left, t2.left) && IsMatch(t1.right, t2.right);
            }
        }
    }
}
