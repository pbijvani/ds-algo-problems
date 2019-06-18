using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class Partition_linked_list_at_pivot_element
    {
        public void TestPartitionLinkedList()
        {
            Node node = new Node(3);
            node.next = new Node(5);
            node.next.next = new Node(8);
            node.next.next.next = new Node(5);
            node.next.next.next.next = new Node(10);
            node.next.next.next.next.next = new Node(2);
            node.next.next.next.next.next.next = new Node(1);

            PartitionLinkedList(node, 5);
        }
        public void PartitionLinkedList(Node head, int pivot)
        {
            Node headLeft = null, currLeft = null;
            Node headRight = null, currRight = null;

            var current = head;

            while (current != null)
            {
                if (current.data < pivot)
                {
                    if (headLeft == null)
                    {
                        headLeft = current;
                        currLeft = current;
                    }
                    else
                    {
                        currLeft.next = current;
                        currLeft = currLeft.next;
                    }
                }
                else
                {
                    if (headRight == null)
                    {
                        headRight = current;
                        currRight = current;
                    }
                    else
                    {
                        currRight.next = current;
                        currRight = currRight.next;
                    }
                }
                current = current.next;
            }

            currRight.next = null;

            currLeft.next = headRight;

            while (headLeft != null)
            {
                Console.WriteLine(headLeft.data);
                headLeft = headLeft.next;
            }
        }
    }
}
