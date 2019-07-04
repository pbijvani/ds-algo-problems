using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class binary_tree_level_order_traversal
    {
        /*
         * print element of array in level order. print level 1, print level 2...
         */

        public void LevelOrderTraversal(TreeNode root)
        {
            Queue<QueueElement> queue = new Queue<QueueElement>();

            queue.Enqueue(new QueueElement(1, root));

            int currLevel = -1;
            while(queue.Any())
            {                
                var node = queue.Dequeue();                
                
                if (node.Depth != currLevel)
                {
                    currLevel = node.Depth;
                    Console.WriteLine(Environment.NewLine);
                }

                Console.Write($"{node.Node.data},");

                if (node.Node.left != null)
                    queue.Enqueue(new QueueElement(node.Depth + 1, node.Node.left));
                if(node.Node.right != null)
                    queue.Enqueue(new QueueElement(node.Depth + 1, node.Node.right));
            }
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

            LevelOrderTraversal(root);
        }

        public class QueueElement
        {
            public int Depth { get; set; }
            public TreeNode Node { get; set; }

            public QueueElement(int depth, TreeNode node)
            {
                this.Depth = depth;
                this.Node = node;
            }
        }
    }
}
