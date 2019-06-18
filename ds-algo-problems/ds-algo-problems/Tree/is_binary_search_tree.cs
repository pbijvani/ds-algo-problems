using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class is_binary_search_tree
    {
        public bool TestIsBinarySearchTree()
        {
            TreeNode root = new TreeNode(50);
            root.left = new TreeNode(30);
            root.right = new TreeNode(70);

            root.left.left = new TreeNode(10);
            root.left.right = new TreeNode(61);

            root.right.left = new TreeNode(60);
            root.right.right = new TreeNode(80);

            var res = IsBinarySearchTree(root, null, null);

            return res;
        }
        private bool IsBinarySearchTree(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;
            else
            {
                var leftStatus = IsBinarySearchTree(root.left, min, root.data);
                var rightStatus = IsBinarySearchTree(root.right, root.data, max);

                if (leftStatus == false || rightStatus == false)
                    return false;

                if (min == null && max == null)
                {
                    return true;
                }
                else if (min == null)
                {
                    return root.data < max;
                }
                else if (max == null)
                {
                    return min <= root.data;
                }
                else
                {
                    return min <= root.data && root.data < max;
                }

            }
        }
    }
}
