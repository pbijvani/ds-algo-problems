using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class binary_tree_all_node_from_given_node_at_k_distance
    {
        public void NodeAtKDistance(TreeNode root, TreeNode start, int k)
        {
            Dictionary<TreeNode, bool> visited = new Dictionary<TreeNode, bool>();

            var parentDict = new Dictionary<TreeNode, TreeNode>();
            ht(root, null, parentDict);

            Queue<QueueItem> queue = new Queue<QueueItem>();
            queue.Enqueue(new QueueItem(start, 0));

            

            while (queue.Any())
            {
                var node = queue.Dequeue();
                visited.Add(node.node, true);

                if (node.level == k)
                {
                    Console.WriteLine(node.node.data);
                }
                else
                {
                    var adjList = GetAdjucencyList(node.node, parentDict);

                    adjList.ForEach(x =>
                    {
                        if(!visited.ContainsKey(x))
                            queue.Enqueue(new QueueItem(x, node.level + 1));
                    });
                }
            }
        }

        private List<TreeNode> GetAdjucencyList(TreeNode node, Dictionary<TreeNode, TreeNode> dict)
        {
            var list = new List<TreeNode>();
            
            if(node.left != null)
            {
                list.Add(node.left);
            }
            if(node.right != null)
            {
                list.Add(node.right);
            }
            if(dict.ContainsKey(node))
            {
                list.Add(dict[node]);
            }
            return list;
        }

        public void ht(TreeNode root, TreeNode parent, Dictionary<TreeNode, TreeNode> dict)
        {
            if (root == null) return;

            if(parent != null)
                dict.Add(root, parent);

            ht(root.left, root, dict);
            ht(root.right, root, dict);            
        }

        public void test()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(15)
                    },
                    right = new TreeNode(2),
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(10),
                    right = new TreeNode(12)
                    {
                        right = new TreeNode(20)
                    },
                }
            };
            var start = root.left;

            NodeAtKDistance(root, start, 2);

        }
    }

    public class QueueItem
    {
        public QueueItem(TreeNode _node, int _level)
        {
            node = _node;
            level = _level;
        }
        public TreeNode node { get; set; }
        public int level { get; set; }
    }
}
