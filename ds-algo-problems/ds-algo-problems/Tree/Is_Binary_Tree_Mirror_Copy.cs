using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class IsBinaryTreeMirrorCopy1
    {
        public bool IsBinaryTreeMirrorCopyIterative(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);
            while (q.Any())
            {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.data != t2.data) return false;
                q.Enqueue(t1.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }
            return true;
        }

        public bool IsBinaryTreeMirrorCopy(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;

            return t1.data == t2.data &&
                IsBinaryTreeMirrorCopy(t1.left, t2.right) &&
                IsBinaryTreeMirrorCopy(t1.right, t2.left);
        }
    }
}
