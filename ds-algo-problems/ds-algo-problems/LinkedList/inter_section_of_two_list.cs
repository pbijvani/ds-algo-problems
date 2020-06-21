using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class inter_section_of_two_list
    {
        public Node GetIntersectingNode(Node head1, Node head2)
        {
            var head1Org = head1;
            var head2Org = head2;

            int differenceInLength = 0;
            bool? IsHead1Short = null;
            while (true)
            {
                if (head1 == head2)
                {
                    return head2;
                }

                if (head1 != null) head1 = head1.next;
                if (head2 != null) head2 = head2.next;

                if (head1 == null && head2 == null) break;

                if (head1 == null || head2 == null)
                {
                    differenceInLength++;

                    if (IsHead1Short == null)
                    {
                        IsHead1Short = head1 == null ? true : false;
                    }
                }


            }

            Node headStartNode = IsHead1Short.Value ? head1Org : head2Org;

            while (differenceInLength > 0)
            {
                if (IsHead1Short.Value)
                {
                    head2Org = head2Org.next;
                }
                else
                {
                    head1Org = head1Org.next;
                }
                differenceInLength--;
            }

            while (true)
            {
                if (head1Org == head2Org) return head1Org;

                head1Org = head1Org.next;
                head2Org = head2Org.next;

                if (head1Org == null || head2Org == null) return null;
            }
        }

        public void TestGetIntersectingNode()
        {
            var point1 = new Node(80);
            var point2 = new Node(90);

            point1.next = point2;

            Node node1 = new Node(10);
            node1.next = new Node(20);
            node1.next.next = new Node(30);
            node1.next.next.next = new Node(40);
            node1.next.next.next.next = point1;

            Node node2 = new Node(10);
            node2.next = new Node(20);
            node2.next.next = new Node(30);
            node2.next.next.next = new Node(40);
            node2.next.next.next.next = new Node(50);
            node2.next.next.next.next.next = point1;

            var res = GetIntersectingNode(node1, node2);

            var res1 = GetIntersection(node1, node2);

        }

        /*
         * Same mathod. little different implementation.
         * 6/20/2020
         */

        public Node GetIntersection(Node l1, Node l2)
        {
            if (l1 == null || l2 == null) return null;

            var l1Res = GetNodeLenthAndTail(l1);
            var l2Res = GetNodeLenthAndTail(l2);            

            if (l1Res.Tail != l2Res.Tail) return null;

            var shorter = l1Res.Length > l2Res.Length ? l2 : l1;
            var longer = l1Res.Length > l2Res.Length ? l1 : l2;

            var lenDiff = System.Math.Abs(l1Res.Length - l2Res.Length);

            longer = GetKthNode(longer, lenDiff);

            while(shorter != longer)
            {
                shorter = shorter.next;
                longer = longer.next;
            }

            return longer;

        }

        public Node GetKthNode(Node node, int k)
        {
            for(int i = 0; i < k; i++)
            {
                node = node.next;
            }

            return node;
        }

        public NodeLenthAndTail GetNodeLenthAndTail(Node head)
        {
            if (head == null) return null;

            var len = 1;

            while(head.next != null)
            {
                len++;
                head = head.next;
            }

            return new NodeLenthAndTail()
            {
                Length = len,
                Tail = head
            };
        }
    }

    public class NodeLenthAndTail
    {
        public Node Tail { get; set; }
        public int Length { get; set; }
    }
}
