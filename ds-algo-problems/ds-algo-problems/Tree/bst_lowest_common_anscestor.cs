using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/solution/
    public class bst_lowest_common_anscestor
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return helper(root, p, q);
        }

        public TreeNode helper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root.data > p.data && root.data > q.data)
            {
                return helper(root.left, p, q);
            }
            else if (root.data < p.data && root.data < q.data)
            {
                return helper(root.right, p, q);
            }
            else
            {
                return root;
            }
        }
    }
}
