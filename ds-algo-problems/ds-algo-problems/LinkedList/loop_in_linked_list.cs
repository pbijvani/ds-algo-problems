using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    //https://java2blog.com/find-start-node-of-loop-in-linkedlist/
    class loop_in_linked_list
    {
        public bool HasCycle(Node head)
        {
            Node slow = head;
            Node fast = head;

            while (true)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast.next == null) break;
                if (fast == slow) return true;
            }

            return false;
        }

        public Node GetMeetingPoint(Node head)
        {
            Node slow = head;
            Node fast = head;

            while (true)
            {

                slow = slow.next;
                fast = fast.next.next;

                if (fast.next == null) return null;
                if (fast == slow) return fast;
            }
        }
        public Node GetStartOfLoop(Node node1, Node node2)
        {

            while (true)
            {
                if (node1 == null || node2 == null) return null;
                if (node2 == node1) return node1;

                node1 = node1.next;
                node2 = node2.next;
            }
        }

        public Node FindStartOfLoop()
        {
            Node node = new Node(10);
            node.next = new Node(20);
            node.next.next = new Node(30);
            node.next.next.next = new Node(40);
            node.next.next.next.next = new Node(50);
            node.next.next.next.next.next = node.next.next;

            var meetingPoint = GetMeetingPoint(node);

            if (meetingPoint != null)
            {
                var res = GetStartOfLoop(node, meetingPoint);
                return res;
            }
            return null;
        }


        public bool TestHasCycle()
        {
            Node node = new Node(10);
            node.next = new Node(20);
            node.next.next = new Node(30);
            node.next.next.next = new Node(40);
            node.next.next.next.next = new Node(50);
            //node.next.next.next.next.next = node;

            return HasCycle(node);
        }
    }
}
