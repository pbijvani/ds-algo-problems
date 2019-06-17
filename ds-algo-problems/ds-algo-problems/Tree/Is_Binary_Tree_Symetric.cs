using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class IsBinaryTreeSymetric1
    {
        /// <summary>
        /// Given a binary tree, check whether it is a symmetric 
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public bool IsBinaryTreeSymetric(TreeNode tree)
        {
            if (tree.left != null && tree.right != null)
            {
                var leftSymetric = IsBinaryTreeSymetric(tree.left);
                var rightSymetric = IsBinaryTreeSymetric(tree.right);

                return leftSymetric && rightSymetric;
            }
            else
            {
                if (tree.left == null && tree.right == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
