using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class binary_tree_path_with_sum
    {
        /*
 * You are given a binary tree in which each node contains an integer value.
 * Find the number of paths that sum to a given value.
 * The path does not need to start or end at the root or a leaf, 
 * but it must go downwards (traveling only from parent nodes to child nodes).
 */
        // Brute force solution

        // Note: if you want to print all path then take each route from root to leaf 
        //and search contineous sub array within that

        public int CountBinaryTreePathWithSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            CountSum(root, 0, sum);

            int cntFromRoot = CountSum(root, 0, sum);

            int cntFromLeft = CountBinaryTreePathWithSum(root.left, sum);
            int cntFromRight = CountBinaryTreePathWithSum(root.right, sum);

            return cntFromRoot + cntFromLeft + cntFromRight;
        }

        private int CountSum(TreeNode start, int sumSoFar, int sum)
        {
            if (start == null) return 0;

            sumSoFar = sumSoFar + start.data;

            int totalCount = 0;

            if (sumSoFar == sum)
            {
                totalCount++;
            }

            totalCount += CountSum(start.left, sumSoFar, sum);
            totalCount += CountSum(start.right, sumSoFar, sum);

            return totalCount;

        }


        /////////////// Better solution
        ///

        private int CountPathsWithSum(TreeNode root, int targetSum, int runningSum, Dictionary<int, int> dict)
        {
            if (root == null) return 0;

            runningSum = runningSum + root.data;
            int sum = runningSum - targetSum;
            int totalPath = dict.GetOrDefault(sum, 0);


            if (runningSum == targetSum) totalPath++;

            IncrementDict(dict, runningSum, 1);
            totalPath += CountPathsWithSum(root.left, targetSum, runningSum, dict);
            totalPath += CountPathsWithSum(root.right, targetSum, runningSum, dict);
            IncrementDict(dict, runningSum, -1);

            return totalPath;
        }

        private void IncrementDict(Dictionary<int, int> dict, int key, int delta)
        {
            int newCount = dict.GetOrDefault(key, 0) + delta;

            if (newCount == 0) dict.Remove(key);
            else dict.Add(key, newCount);
        }

        public void TestCountBinaryTreePathWithSum(int sum)
        {
            TreeNode root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(3)
                        {
                            left = new TreeNode(2)
                        },
                        right = new TreeNode(-2)
                    },
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(1)
                        {

                        }
                    }
                },
                right = new TreeNode(-3)
                {
                    right = new TreeNode(11)
                }
            };


            if (root == null) return;
            var dict = new Dictionary<int, int>();
            var cnt = CountPathsWithSum(root, 8, 0, dict);

        }
    }
}
