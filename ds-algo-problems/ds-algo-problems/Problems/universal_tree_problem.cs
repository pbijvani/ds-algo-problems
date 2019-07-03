using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class universal_tree_problem
    {
        /*
         * universal tree is one which has all element with same value
         *          1
         *         / \
         *         1  1
         * lead element are also a universal tree
         */

        int count = 0;
        public bool UniversalTreeCount(TreeNode node)
        {
            if(node == null)
            {                
                return true;
            }

            var leftVal = UniversalTreeCount(node.left);
            var rightVal = UniversalTreeCount(node.right);

            if(leftVal && rightVal && (node.left == null || node.data == node.left.data))
            {
                count++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Test()
        {
            TreeNode root = new TreeNode(0)
            {
                left = new TreeNode(1),
                right = new TreeNode(0)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(1),
                        right = new TreeNode(1)
                    },
                    right = new TreeNode(0)
                }
            };

            var val = UniversalTreeCount(root);

            return count;
        }
    }
}












