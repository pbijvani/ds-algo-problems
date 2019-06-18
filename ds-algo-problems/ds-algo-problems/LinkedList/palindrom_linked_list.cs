using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class palindrom_linked_list
    {
        public bool IsPalindrome(Node head)
        {
            Node slow = head;
            Node fast = head;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(slow);

            while (true)
            {
                if (fast.next == null)
                {
                    stack.Pop();
                    break;
                }

                if (fast.next.next == null)
                {
                    break;
                }

                slow = slow.next;
                fast = fast.next.next;

                stack.Push(slow);
            }

            slow = slow.next;
            while (true)
            {
                var node = stack.Pop();

                if (node.data != slow.data)
                    return false;

                slow = slow.next;

                if (slow == null)
                    break;
            }
            return true;
        }
    }
}
