using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Given inorder and postorder traversal of a tree, construct the binary tree.

        Note:
        You may assume that duplicates do not exist in the tree.

        For example, given

        inorder = [9,3,15,20,7]
        postorder = [9,15,7,20,3]
        Return the following binary tree:

            3
           / \
          9  20
            /  \
           15   7   
        
        https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/

     */
    public class binary_tree_from_inorder_and_postorder_traversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
                var lenIn = inorder.Length;
                var lenPost = postorder.Length;

                if (lenIn == 0 || lenPost == 0 || lenIn != lenPost) return null;

                var map = new Dictionary<int, int>();
                for(int i = 0; i < inorder.Length; i++)
                {
                    map.Add(inorder[i], i);
                }


                var res = BuildTreeHelper(inorder, postorder, 0, lenIn - 1, lenIn - 1, map);

                return res;
        }

        public TreeNode BuildTreeHelper(int[] inorder, int[] postorder, int inStart, int inEnd, int post, Dictionary<int, int> inMap)
        {
            if (inStart > inEnd) return null;

            var currRootEle = postorder[post];
            var root = new TreeNode(currRootEle);


            var rootElemInorderIndex = inMap[currRootEle];

            var leftOffset = inEnd - rootElemInorderIndex;

            root.left = BuildTreeHelper(inorder, postorder, inStart, rootElemInorderIndex - 1, post - leftOffset - 1, inMap);
            root.right = BuildTreeHelper(inorder, postorder, rootElemInorderIndex + 1, inEnd, post - 1, inMap);

            return root;
        }

        public void test()
        {
            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var postorder = new int[] { 9, 15, 7, 20, 3 };

            //var inorder = new int[] { 1,2,3,4 };
            //var postorder = new int[] { 4,3,2,1 };

            var res = BuildTree(inorder, postorder);



        }

    }
}
