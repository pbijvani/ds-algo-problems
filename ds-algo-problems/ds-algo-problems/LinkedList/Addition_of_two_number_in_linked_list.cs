using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class Addition_of_two_number_in_linked_list
    {
        public void Test()
        {
            var first = new Node(5)
            {
                next = new Node(7)
                {
                    next = new Node(9)
                    {
                        next = new Node(9)
                    }
                }
            };

            var second = new Node(7)
            {
                next = new Node(1)
                {
                    next = new Node(9)
                }
            };

            NodeAddition1(first, second);
        }

        public void NodeAddition(Node node1, Node node2)
        {
            Node newHead = null;
            Node currNode = null;

            int remainder = 0;
            int carry = 0;

            while (node1 != null && node2 != null)
            {
                var sum = node1.data + node2.data + carry;

                remainder = sum % 10;
                carry = sum / 10;

                var newNode = new Node(remainder);

                if (currNode == null)
                {
                    currNode = newNode;
                    newHead = currNode;
                }
                else
                {
                    currNode.next = newNode;
                    currNode = currNode.next;
                }

                node1 = node1.next;
                node2 = node2.next;
            }
            if (carry > 0)
            {
                currNode.next = new Node(carry);
            }
        }

        public void NodeAddition1(Node node1, Node node2)
        {
            Node newHead = null;
            Node currNode = null;

            int remainder = 0;
            int carry = 0;

            while (node1 != null || node2 != null)
            {
                var sum = (node1 == null ? 0 :node1.data) + 
                    (node2 == null ? 0 :node2.data) + 
                    carry;

                remainder = sum % 10;
                carry = sum / 10;

                var newNode = new Node(remainder);

                if (currNode == null)
                {
                    currNode = newNode;
                    newHead = currNode;
                }
                else
                {
                    currNode.next = newNode;
                    currNode = currNode.next;
                }

                node1 = node1 == null ? null : node1.next;
                node2 = node2 == null ? null : node2.next;
            }
            if (carry > 0)
            {
                currNode.next = new Node(carry);
            }
        }
    }
}
