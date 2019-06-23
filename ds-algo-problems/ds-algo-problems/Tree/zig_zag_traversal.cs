using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    public class zig_zag_traversal
    {
        public void Traverse(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<TreeNode> list = new List<TreeNode>();
            
            int direction = 0;

            stack.Push(root);

            while(stack.Any())
            {                                
                while(stack.Any())
                {
                    var node = stack.Pop();
                    Console.WriteLine(node.data);
                    list.Add(node);
                }

                foreach(var item in list)
                {
                    if (direction == 0)
                    {
                        if (root.left != null) stack.Push(root.left);
                        if (root.right != null) stack.Push(root.right);
                    }
                    else
                    {
                        if (root.right != null) stack.Push(root.right);
                        if (root.left != null) stack.Push(root.left);
                    }
                }

                list.Clear();

                direction = direction == 0 ? 1 : 0;                
            }
        }



        public void TestTraverse()
        {
            TreeNode root = new TreeNode(500)
            {
                left = new TreeNode(400)
                {
                    left = new TreeNode(300)
                    {
                        left = new TreeNode(200),
                        right = new TreeNode(100)
                    },
                    right = new TreeNode(250)
                    {
                        left = new TreeNode(240),
                        right = new TreeNode(230)
                    }
                },
                right = new TreeNode(600)
                {
                    left = new TreeNode(550)
                    {
                        left = new TreeNode(670),
                        right = new TreeNode(690),
                    },
                    right = new TreeNode(700)
                    {
                        left = new TreeNode(750),
                        right = new TreeNode(775)
                    }
                }
            };

            Traverse(root);
        }
    }
}
