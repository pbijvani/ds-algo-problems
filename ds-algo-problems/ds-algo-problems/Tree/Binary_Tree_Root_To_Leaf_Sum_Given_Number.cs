using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class BinaryTreeRootToLeafSumGivenNumber
    {
        /// <summary>
        /// Path Sum
        /// Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool IsSumOfPathIs(TreeNode treeNode, int sum)
        {
            return SumOfPath(treeNode, 0, sum);
        }

        public bool SumOfPath(TreeNode root, int sumSoFar, int sum)
        {
            if (root == null && sumSoFar == sum)
            {
                return true;
            }
            else if (root == null)
            {
                return false;
            }
            else
            {
                var leftStatus = SumOfPath(root.left, sumSoFar + root.data, sum);
                var rightStatus = SumOfPath(root.right, sumSoFar + root.data, sum);

                return leftStatus == true || rightStatus == true;
            }

        }

        public string[] TestSumOfPathReturnPath(TreeNode root, int sum)
        {
            return SumOfPathReturnPath(root, 0, sum);
        }

        public string[] SumOfPathReturnPath(TreeNode root, int sumSoFar, int sum)
        {
            if (root.left == null &&
                root.right == null &&
                sumSoFar + root.data == sum)
            {
                // leaf node and sum matches
                return new string[] { $"{root.data}" };
            }
            else if (root.left == null &&
                root.right == null)
            {
                // leaf node and sum matches
                return new string[] { };
            }
            else
            {
                string[] leftStatus = new string[] { };
                string[] rightStatus = new string[] { };
                if (root.left != null)
                {
                    leftStatus = SumOfPathReturnPath(root.left, sumSoFar + root.data, sum);
                }
                if (root.right != null)
                {
                    rightStatus = SumOfPathReturnPath(root.right, sumSoFar + root.data, sum);
                }
                return leftStatus.Concat(rightStatus).ToList().Select(x => $"{root.data},{x}").ToArray();
            }
        }
    }
}
