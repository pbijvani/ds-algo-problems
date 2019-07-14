using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class serialize_binary_tree
    {
        public string serialize(TreeNode root)
        {
            var serializedString = new StringBuilder();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root ?? null);

            while (queue.Any())
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var top = queue.Dequeue();
                    serializedString.Append(top == null ? '#' : (char)(top.data + '0'));
                    if (top != null)
                    {
                        queue.Enqueue(top.left);
                        queue.Enqueue(top.right);
                    }
                }
            }

            return serializedString.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            if (data[0] == '#') return null;
            var queue = new Queue<TreeNode>();
            var root = new TreeNode(data[0] - '0');
            queue.Enqueue(root);
            var index = 1;
            while (queue.Any())
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var top = queue.Dequeue();
                    top.left = data[index] == '#' ? null : new TreeNode(data[index] - '0');
                    if (top.left != null) queue.Enqueue(top.left);
                    index++;
                    top.right = data[index] == '#' ? null : new TreeNode(data[index] - '0');
                    if (top.right != null) queue.Enqueue(top.right);
                    index++;
                }
            }

            return root;
        }

        public void Test()
        {
            TreeNode root = new TreeNode(25)
            {
                left = new TreeNode(15)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(10)
                },
                right = new TreeNode(30)
                {
                    left = new TreeNode(35),
                    right = new TreeNode(40)
                }
            };

            var str = serialize(root);
            var tree = deserialize(str);
        }
    }
}
