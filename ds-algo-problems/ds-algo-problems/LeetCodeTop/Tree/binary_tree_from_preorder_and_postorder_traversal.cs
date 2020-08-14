using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Tree
{
    /*
        Return any binary tree that matches the given preorder and postorder traversals.

        Values in the traversals pre and post are distinct positive integers.

 

        Example 1:

        Input: pre = [1,2,4,5,3,6,7], post = [4,5,2,6,7,3,1]
        Output: [1,2,3,4,5,6,7]
 

        Note:

        1 <= pre.length == post.length <= 30
        pre[] and post[] are both permutations of 1, 2, ..., pre.length.
        It is guaranteed an answer exists. If there exists multiple answers, you can return any of them.

        https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/
     
     */
    public class binary_tree_from_preorder_and_postorder_traversal
    {
        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            var lenPre = pre.Length;
            var lenPost = post.Length;

            if (lenPre == 0 || lenPost == 0 || lenPre != lenPost) return null;

            //var res = BuildTreeHelper(pre, post);
            var res = BuildTreeHelperIndexes(pre, post, 0, 0, lenPost);

            return res;
        }

        private TreeNode BuildTreeHelper(int[] pre, int[] post)
        {
            var n = pre.Length;

            if (n == 0) return null;

            var root = new TreeNode(pre[0]);

            if (n == 1) return root;

            int L = 0;
            for (int i = 0; i < n; ++i)
                if (post[i] == pre[1])
                    L = i + 1;

            root.left = BuildTreeHelper(SubArray(pre, 1, L), SubArray(post, 0, L));
            root.right = BuildTreeHelper(SubArray(pre, L + 1, n - L), SubArray(post, L, n - L - 1));

            return root;
        }

        public int[] SubArray(int[] data, int index, int length)
        {
            return data.Skip(index).Take(length).ToArray();
        }

        public void test()
        {
            var preorder = new int[] { 1, 2, 4, 5, 3, 6, 7 };
            var postorder = new int[] { 4, 5, 2, 6, 7, 3, 1 };

            var res = ConstructFromPrePost(preorder, postorder);
        }

        private TreeNode BuildTreeHelperIndexes(int[] pre, int[] post, int preIndx, int postIndx, int n)
        {
            if (n == 0) return null;

            var root = new TreeNode(pre[preIndx]);

            if (n == 1) return root;

            int L = 0;
            for (int i = postIndx; i < postIndx + n - 1; ++i)
                if (post[i] == pre[preIndx + 1])
                    L = i - postIndx + 1;

            root.left = BuildTreeHelperIndexes(pre, post, preIndx + 1, postIndx, L);
            root.right = BuildTreeHelperIndexes(pre, post, preIndx + 1 + L, postIndx + L, n - L - 1);

            return root;
        }
    }
}
