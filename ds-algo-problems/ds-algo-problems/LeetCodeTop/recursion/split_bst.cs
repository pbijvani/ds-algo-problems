using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.recursion
{
    /*
     * https://leetcode.com/problems/split-bst/
     * https://leetcode.jp/problemdetail.php?id=776
     * https://www.youtube.com/watch?v=ADun2n_ueZQ
     * https://github.com/fishercoder1534/Leetcode/blob/master/src/main/java/com/fishercoder/solutions/_776.java
     */
    public class split_bst
    {
        public TreeNode[] SplitBst(TreeNode root, int v)
        {
            var result = new TreeNode[] { null, null };

            if(root == null)
            {
                return result;
            }

            var x = root.data > v ? 1 : 0;
            var y = root.data > v ? 0 : 1;

            var node = root.data > v ? root.left : root.right;

            result[x] = root; // If searching in right result[1] = root

            var t = SplitBst(node, v);

            node = t[x];
            result[y] = t[y];

            return result;
        }


        public TreeNode[] SplitBst1(TreeNode root, int v)
        {
            if(root == null)
            {
                return new TreeNode[] { null, null };
            }
            else if(root.data <= v)
            {
                var result = SplitBst1(root.right, v);
                root.right = result[0];
                result[0] = root;
                return result;
            }
            else // root.data > v
            {
                var result = SplitBst1(root.left, v);
                root.left = result[1];
                result[1] = root;
                return result;
            }
        }

        public void test()
        {
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(6)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(7)
                }
            };

            var res = SplitBst1(root, 2);
        }
    }
}
