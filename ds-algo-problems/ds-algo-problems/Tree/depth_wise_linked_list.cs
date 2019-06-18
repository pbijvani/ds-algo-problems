using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    class depth_wise_linked_list
    {
        public void BinaryTreeToDepthWiseLinkedList(TreeNode root, int depth, Dictionary<int, Tuple<Node, Node>> list)
        {
            if (root == null) return;

            var node = new Node(root.data);
            if (!list.ContainsKey(depth))
            {
                list.Add(depth, new Tuple<Node, Node>(node, node));
            }
            else
            {
                list[depth].Item2.next = node;
                list[depth].Item2.next = list[depth].Item2;
            }

            BinaryTreeToDepthWiseLinkedList(root.left, depth + 1, list);
            BinaryTreeToDepthWiseLinkedList(root.right, depth + 1, list);
        }
    }
}
