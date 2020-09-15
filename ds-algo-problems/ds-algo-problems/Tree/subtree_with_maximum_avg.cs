using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    /*
     * https://aonecode.com/amazon-subtree-with-maximum-average
     * https://mopjtv.github.io/algorithms/4/15461901041767
     * https://mrleonhuang.gitbooks.io/lintcode/content/binary-tree-and-divide-conquer/subtree-with-maximum-average.html
     */
    public class subtree_with_maximum_avg
    {
        private TreeNodeWrapper2 result = null;
        public TreeNode SubtreeWithMaximumAvg(TreeNode root)
        {
            var res = new TreeNodeWrapper1();

            helper(root);

            return res.Root;
        }

        public TreeNodeWrapper2 helper(TreeNode root)
        {
            if (root == null) return null;

            var leftTotal = helper(root.left);
            var rightTotal = helper(root.right);

            var newCount = (leftTotal == null ? 0 : leftTotal.Count) + (rightTotal == null ? 0 : rightTotal.Count) + 1;
            var newSum = (leftTotal == null ? 0 : leftTotal.Sum) + (rightTotal == null ? 0 : rightTotal.Sum) + root.data;

            var newAvg = newCount == 0 ? 0 : newSum / newCount;

            if(result == null || newAvg > result.Avg)
            {
                result = new TreeNodeWrapper2(newSum, newCount, root);
            }

            return new TreeNodeWrapper2(newSum, newCount, root);
        }

        public void test()
        {

        }
    }
    public class TreeNodeWrapper2
    {
        public TreeNodeWrapper2(int sum, int cnt, TreeNode root)
        {
            this.Sum = sum;
            this.Count = cnt;
            this.Root = root;
        }
        public int Sum { get; set; }
        public int Count { get; set; }
        public TreeNode Root { get; set; }

        public decimal Avg
        {
            get
            {
                return Sum / Count;
            }
        }

    }
}
