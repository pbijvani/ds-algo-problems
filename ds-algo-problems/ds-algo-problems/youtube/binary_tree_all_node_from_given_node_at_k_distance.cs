using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    //https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/submissions/
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

    public class DistanceK
    {
        private List<int> ans;
        TreeNode target;
        int k;
        public List<int> distanceK(TreeNode root, TreeNode _target, int K)
        {
            ans = new List<int>();
            target = _target;
            k = K;

            dfs(root);

            return ans;
        }

        private int dfs(TreeNode root)
        {
            if(root == null)
            {
                return -1;
            }
            else if(root == target)
            {
                subtree_add(root, 0);
                return 1;
            }
            else
            {
                var L = dfs(root.left);
                var R = dfs(root.right);

                if(L != -1)
                {
                    if (L == k) ans.Add(root.data);
                    subtree_add(root.right, L + 1);
                    return L + 1;
                }
                else if(R != -1)
                {
                    if (R == k) ans.Add(root.data);
                    subtree_add(root.left, R + 1);
                    return R + 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        private void subtree_add(TreeNode root, int dist)
        {
            if (root == null) return;

            if (dist == k) ans.Add(root.data);

            subtree_add(root.left, dist + 1);
            subtree_add(root.right, dist + 1);
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
