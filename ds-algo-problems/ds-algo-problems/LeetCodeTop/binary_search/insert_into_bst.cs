using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.binary_search
{
    // https://leetcode.com/problems/insert-into-a-binary-search-tree/
    /*
        Given the root node of a binary search tree (BST) and a value to be inserted into the tree, insert the value into the BST. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

        Note that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

        For example, 

        Given the tree:
                4
               / \
              2   7
             / \
            1   3
        And the value to insert: 5
        You can return this binary search tree:

                 4
               /   \
              2     7
             / \   /
            1   3 5
        This tree is also valid:

                 5
               /   \
              2     7
             / \   
            1   3
                 \
                  4    
     */
    public class insert_into_bst
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            var curr = root;

            while(true)
            {
                if(val >= curr.data)
                {
                    // look into right

                    if(curr.right == null)
                    {
                        curr.right = new TreeNode(val);
                        break;
                    }
                    else
                    {
                        curr = curr.right;
                    }

                }
                else
                {
                    if(curr.left == null)
                    {
                        curr.left = new TreeNode(val);
                        break;
                    }
                    else
                    {
                        curr = curr.left;
                    }
                }
            }

            return root;
        }

        public void test()
        {
            var root = new TreeNode(50)
            {
                left = new TreeNode(30)
                {
                    left = new TreeNode(10),
                    right = new TreeNode(20)
                },
                right = new TreeNode(80)
                {
                    left = new TreeNode(60),
                    right = new TreeNode(90)
                }

            };

            var res = InsertIntoBST(root, 48);
        }

        public TreeNode InsertIntoBSTRec(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            helper(root, val);

            return root;
        }

        public void helper(TreeNode root, int val)
        {
            if(val < root.data)
            {
                if(root.left == null)
                {
                    root.left = new TreeNode(val);
                    return;
                }
                else
                {
                    helper(root.left, val);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                    return;
                }
                else
                {
                    helper(root.right, val);
                }
            }
        }
    }

    
}
