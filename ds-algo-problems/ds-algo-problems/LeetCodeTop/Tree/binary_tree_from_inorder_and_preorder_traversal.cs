using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given preorder and inorder traversal of a tree, construct the binary tree.

        Note:
        You may assume that duplicates do not exist in the tree.

        For example, given

        preorder = [3,9,20,15,7]
        inorder = [9,3,15,20,7]
        Return the following binary tree:

            3
           / \
          9  20
            /  \
           15   7     

        https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

     */
    public class binary_tree_from_inorder_and_preorder_traversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var lenPreorder = preorder.Length;
            var lenOnorder = inorder.Length;

            if (lenPreorder == 0 || lenOnorder == 0 || lenPreorder != lenOnorder) return null;

            var res = BuildTreeHelper(preorder, inorder, 0, preorder.Length - 1, 0, new HashSet<int>());

            return res;
        }

        public TreeNode BuildTreeHelper(int[] preorder, int[] inorder, int left, int right, int preorderPointer, HashSet<int> processed)
        {
            if (left > right) return null;
            preorderPointer = GetRootAtCurrLevel(preorder, preorderPointer, processed);

            var root = new TreeNode(preorder[preorderPointer]);
            processed.Add(preorder[preorderPointer]);

            if(left == right)
            {
                return root;
            }
            else
            {
                var indexOfRootEleInorde = GetIndexOfEleInInorderArr(preorder[preorderPointer], inorder, left, right);

                root.left = BuildTreeHelper(preorder, inorder, left, indexOfRootEleInorde - 1, preorderPointer, processed);
                root.right = BuildTreeHelper(preorder, inorder, indexOfRootEleInorde + 1, right, preorderPointer, processed);

                return root;
            }            
        }

        private int GetIndexOfEleInInorderArr(int num, int[] inorder, int left, int right)
        {
            for(int i = left; i <=right; i++)
            {
                if (num == inorder[i]) return i;
            }

            return -1;
        }

        private int GetRootAtCurrLevel(int[] preorder, int preorderPointer, HashSet<int> processed)
        {
            while(processed.Contains(preorder[preorderPointer]))
            {
                preorderPointer++;
            }

            return preorderPointer;
        }

        // Cleaner Version of same code above with little optimization.
        public TreeNode BuildTreeVer1(int[] preorder, int[] inorder)
        {
            var lenPreorder = preorder.Length;
            var lenOnorder = inorder.Length;

            if (lenPreorder == 0 || lenOnorder == 0 || lenPreorder != lenOnorder) return null;

            var map = new Dictionary<int, int>();
            for(int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            var root = BuildTreeHelperClean(preorder, inorder, 0, inorder.Length - 1, 0, map);

            return root;
        }
        public TreeNode BuildTreeHelperClean(int[] preorder, int[] inorder, int inStart, int inEnd, int pre, Dictionary<int, int> inMap)
        {
            if (pre > preorder.Length - 1 || inStart > inEnd) return null;

            var rootElement = preorder[pre];

            var root = new TreeNode(rootElement);

            var inIndexOfRootElement = inMap[rootElement];

            var rightOffset = inIndexOfRootElement - inStart;

            root.left = BuildTreeHelperClean(preorder, inorder, inStart, inIndexOfRootElement - 1, pre + 1, inMap);
            root.right = BuildTreeHelperClean(preorder, inorder, inIndexOfRootElement + 1, inEnd, pre + rightOffset + 1, inMap);

            return root;
        }

        public void test()
        {
            //var preorder = new int[] { 3, 9, 20, 15, 7 };
            //var inorder = new int[] { 9, 3, 15, 20, 7 };

            var preorder = new int[] { 1, 2 };
            var inorder = new int[] { 2, 1 };

            var root = BuildTree(preorder, inorder);
        }

        public void test1()
        {
            var preorder = new int[] { 3, 9, 20, 15, 7 };
            var inorder = new int[] { 9, 3, 15, 20, 7 };

            var res = BuildTree1(preorder, inorder);
        }

        // Approach 2
        // https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/discuss/34543/Simple-O(n)-without-map
        public TreeNode BuildTree1(int[] preorder, int[] inorder)
        {
            var res = BuildHelper(preorder, inorder, int.MinValue);

            return res;
        }
        int preo = 0; 
        int ino = 0;
        public TreeNode BuildHelper(int[] preorder, int[] inorder, int stop)
        {
            if (preo >= preorder.Length) return null;

            if(inorder[ino] == stop)
            {
                ino++;
                return null;
            }

            TreeNode node = new TreeNode(preorder[preo]);
            preo++;

            node.left = BuildHelper(preorder, inorder, node.data);
            node.right = BuildHelper(preorder, inorder, stop);

            return node;
        }
    }
}
