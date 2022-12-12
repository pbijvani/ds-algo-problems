using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class print_inorder_preorder_postorder
    {
        public void PrintInorder(TreeNode node)
        {
            if (node == null) return;

            PrintInorder(node.left);

            Console.Write($"{node.data}, ");

            PrintInorder(node.right);
        }

        public void PrintPreorder(TreeNode node)
        {
            if (node == null) return;            

            Console.Write($"{node.data}, ");

            PrintInorder(node.left);

            PrintInorder(node.right);
        }

        public void PrintPostorder(TreeNode node)
        {
            if (node == null) return;            

            PrintInorder(node.left);

            PrintInorder(node.right);

            Console.Write($"{node.data}, ");
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

            PrintInorder(root);
        }
    }
}
