using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    public class NodeWraperKthELe
    {
        public int index = 0;
    }
    public class k_th_node_from_last_singly_list
    {
        /*
         *Recursive solution:
         * Traverse through end of list
         * return int from each recursive call
         * last element returns 1
         * then each returns +1 to it.
         * when retrun value reach k keep returning k
        */

        public int Test1()
        {
            LinkedListNode head = new LinkedListNode(1);
            head.Next = new LinkedListNode(2);
            head.Next.Next = new LinkedListNode(3);
            head.Next.Next.Next = new LinkedListNode(1);
            head.Next.Next.Next.Next = new LinkedListNode(4);
            head.Next.Next.Next.Next.Next = new LinkedListNode(5);
            head.Next.Next.Next.Next.Next.Next = new LinkedListNode(6);

            var kThElement = FindKthElementIterative(head, 3);


            NodeWraperKthELe indx = new NodeWraperKthELe();

            var kthNOde = FindKthFromEnd(head, 3, indx);


            return FindKthFromEnd(head, 3);


        }

        // This solution only prints kth element
        public int FindKthFromEnd(LinkedListNode head, int k)
        {
            if (head == null) return 0;

            var index = FindKthFromEnd(head.Next, k);

            if(index == k)
            {
                Console.WriteLine("Kth ELement: " + head.data);
            }

            return index + 1;
        }

        // return node at kth position from end.
        public LinkedListNode FindKthFromEnd(LinkedListNode head, int k, NodeWraperKthELe indx)
        {
            if (head == null) return null;

            var node = FindKthFromEnd(head.Next, k, indx);

            indx.index = indx.index + 1;

            if (indx.index == k)
            {
                return head;
            }

            return node;
        }

        /*
         * Iterative solution
         * keep two pointer p1 and p2
         * p1 points to head
         * p2 point to kth element from head. keep them k node away
         * keep iterating both pointer one node at a time untill p2 reaches end of list
         * p1 is kth element from last
         */

        public int FindKthElementIterative(LinkedListNode head, int k)
        {
            LinkedListNode p1 = head;
            LinkedListNode p2 = head;

            int index = 1;

            while(index <= k && p2 != null)
            {
                p2 = p2.Next;
                index++;
            }

            if (p2 == null) return int.MinValue;

            while(p2 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1.data;
        }
    }
}
