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
        }
    }
}
