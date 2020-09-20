using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.binary_search
{
    //https://leetcode.com/problems/delete-node-in-a-bst/
    public class delete_from_bst
    {

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;

            if(key == root.data)
            {
                if(root.right == null)
                {
                    return root.left;
                }
                else if(root.left == null)
                {
                    return root.right;
                }
                else
                {
                    root.data = getMinVal(root.right);

                    root.right = DeleteNode(root.right, root.data);
                }                
            }
            else if (key < root.data) // left
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                root.right = DeleteNode(root.right, key);
            }
            return root;
        }

        private int getMinVal(TreeNode root)
        {
            int min = root.data;
            while(root.left != null)
            {
                min = root.left.data;
                root = root.left;
            }
            return min;
        }

        // Not passing all leetcode testcases
        public TreeNode DeleteNodeIterative(TreeNode root, int key)
        {
            if (root == null) return root;
            if (root.data == key && root.left == null && root.right == null) return null;
            var curr = root;
            var prev = root;

            while (true)
            {
                if (key == curr.data)
                {
                    if (curr.left == null && curr.right == null)
                    {
                        if (prev.left == curr)
                        {
                            prev.left = null;
                        }
                        else
                        {
                            prev.right = null;
                        }
                        break;
                    }
                    else if (curr.left == null || curr.right == null)
                    {
                        if (curr.left == null)
                        {
                            if (prev.left == curr)
                            {
                                prev.left = curr.right;
                            }
                            else
                            {
                                prev.right = curr.right;
                            }
                        }
                        if (curr.right == null)
                        {
                            if (prev.left == curr)
                            {
                                prev.left = curr.left;
                            }
                            else
                            {
                                prev.right = curr.left;
                            }
                        }
                        break;
                    }
                    else
                    {
                        if (curr.left.right == null)
                        {
                            if (prev.left == curr)
                            {
                                prev.left.data = curr.right.data;
                                curr.right = null;
                            }
                            else
                            {
                                prev.right.data = curr.right.data;
                                curr.right = null;
                            }
                        }
                        else
                        {
                            var inorderPre = GetInOrderPredecessor(curr.left);

                            curr.data = inorderPre;
                        }

                        break;
                    }
                }
                else if (key < curr.data)
                {
                    prev = curr;
                    curr = curr.left;
                }
                else
                {
                    prev = curr;
                    curr = curr.right;
                }

                if (curr == null)
                {
                    break;
                }
            }

            return root;
        }

        private int GetInOrderPredecessor(TreeNode root)
        {
            if (root.right.right == null)
            {
                var retVal = root.right.data;
                root.right = null;
                return retVal;
            }
            else
            {
                return GetInOrderPredecessor(root.right);
            }
        }

        public void test()
        {
            var root = new TreeNode(5)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(4)
                },
                right = new TreeNode(6)
                {
                    left = null,
                    right = new TreeNode(7)
                }
            };

            var res = DeleteNode(root, 3);
        }
    }
}
