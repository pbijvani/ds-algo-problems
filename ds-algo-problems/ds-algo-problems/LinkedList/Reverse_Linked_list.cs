using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class Reverse_Linked_list
    {
        // Iterative
        public Node ReverseLlinkedList(Node head)
        {
            Node prev = null;
            Node curr = head;
            Node next = null;

            while (true)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;

                if (curr == null)
                    break;
            }

            return prev;
        }
        //recursive
        Node newHead = null;
        public Node ReverseLinkedListRecursive(Node head)
        {
            if (head.next == null)
            {
                newHead = head;
                return head;
            }


            var next = ReverseLinkedListRecursive(head.next);
            next.next = head;

            return head;
        }
    }
}
