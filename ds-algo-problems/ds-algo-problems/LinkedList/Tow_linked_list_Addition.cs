using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class Tow_linked_list_Addition
    {
        /// <summary>
        /// You are given two linked lists representing two non-negative numbers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list
        /// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        ///Output: 7 -> 0 -> 8
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public TreeNode LinkedListAdditionReverseOrder(TreeNode l1, TreeNode l2)
        {
            var fakehead = new TreeNode(-1);
            var start = fakehead;
            var overflow = 0;

            while (l1 != null || l2 != null)
            {
                var l1Value = l1 == null ? 0 : l1.data;
                var l2Value = l2 == null ? 0 : l2.data;

                var newNode = new TreeNode((l1Value + l2Value + overflow) % 10);
                start.right = newNode;
                start = start.right;

                overflow = (l1Value + l2Value + overflow) / 10;
                l1 = l1 == null ? null : l1.right;
                l2 = l2 == null ? null : l2.right;
            }

            if (overflow == 1)
            {
                var newNode = new TreeNode(1);
                start.right = newNode;
            }

            return fakehead.right;
        }
    }
}
