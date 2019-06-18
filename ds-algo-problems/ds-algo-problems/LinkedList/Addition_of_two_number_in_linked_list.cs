﻿using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    class Addition_of_two_number_in_linked_list
    {
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

    }
}
