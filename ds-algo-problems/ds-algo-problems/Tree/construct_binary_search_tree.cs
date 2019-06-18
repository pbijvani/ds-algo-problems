using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class construct_binary_search_tree
    {
        public TreeNode ConstructMinHeightBST(int[] input)
        {
            var root = ConstructBST(input);

            return root;
        }

        private TreeNode ConstructBST(int[] input)
        {
            var len = input.Length;
            var midPoint = (len / 2);
            var leftArray = input.Slice(0, midPoint - 1);
            var rightArray = input.Slice(midPoint + 1, len);

            TreeNode node = new TreeNode(input[midPoint]);

            if (leftArray.Length > 1)
            {
                node.left = ConstructBST(leftArray);
            }
            else
            {
                node.left = leftArray.Length == 1 ? new TreeNode(leftArray[0]) : null;
            }
            if (rightArray.Length > 1)
            {
                node.right = ConstructBST(rightArray);
            }
            else
            {
                node.right = rightArray.Length == 1 ? new TreeNode(rightArray[0]) : null;
            }

            return node;
        }
    }
}
