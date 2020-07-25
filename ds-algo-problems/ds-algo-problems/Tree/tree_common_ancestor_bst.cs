using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class tree_common_ancestor_bst
    {
        public void TestCommonAnsestor1()
        {
            var root = new TreeNode(6)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(5)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(9)
                }
            };

            var a = root.left;
            var b = root.left.right.right;

            var res = CommonAnsestor1(root, a, b);
        }
        public TreeNode CommonAnsestor1(TreeNode root, TreeNode a, TreeNode b)
        {
            if (a.data < root.data && b.data < root.data)
            {
                return CommonAnsestor1(root.left, a, b);
            }
            else if (a.data > root.data && b.data > root.data)
            {
                return CommonAnsestor1(root.right, a, b);
            }
            else
            {
                return root;
            }
        }
    }
}
