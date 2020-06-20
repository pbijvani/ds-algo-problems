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

        /*
         * Recursive solution : 6/20/2020
         */
        public void TestRec()
        {
            var first = new LinkedListNode(5)
            {
                Next = new LinkedListNode(7)
                {
                    Next = new LinkedListNode(9)
                    {
                        Next = new LinkedListNode(9)
                    }
                }
            };

            var second = new LinkedListNode(7)
            {
                Next = new LinkedListNode(1)
                {
                    Next = new LinkedListNode(9)
                }
            };

            var res = Addition(first, second, 0);

        }
        public LinkedListNode Addition(LinkedListNode l1, LinkedListNode l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return null;
            }

            int value = 0;

            LinkedListNode result = new LinkedListNode(0);

            value += carry;

            if (l1 != null)
            {
                value += l1.data;
            }

            if (l2 != null)
            {
                value += l2.data;
            }

            result.data = value % 10;

            if (l1 != null || l2 != null)
            {
                var more = Addition(l1 == null ? null : l1.Next,
                                    l2 == null ? null : l2.Next,
                                    value > 9 ? 1 : 0);

                result.Next = more;
            }

            return result;
        }

        /*
         * 985 + 96 = 1081
         * L1 : 9->8->5
         * L2 : 9->6
         * Result : 1->0->8->1
         */

        public int Length(LinkedListNode node)
        {
            int len = 0;

            while (node != null)
            {
                len = len + 1;
                node = node.Next;
            }

            return len;
        }

        public LinkedListNode AddToFront(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);

            if (node != null)
            {
                newNode.Next = node;
            }

            return newNode;
        }

        public LinkedListNode PadEmptyNode(LinkedListNode node, int numberOfNode)
        {
            for (int i = 0; i < numberOfNode; i++)
            {
                LinkedListNode curr = new LinkedListNode(0);
                if (node != null)
                {
                    curr.Next = node;
                }
                node = curr;
            }
            return node;
        }
        public void TestReverseSumRec()
        {
            var first = new LinkedListNode(9)
            {
                Next = new LinkedListNode(8)
                {
                    Next = new LinkedListNode(5)
                    {

                    }
                }
            };

            var second = new LinkedListNode(9)
            {
                Next = new LinkedListNode(6)
                {

                }
            };

            var res = AdditionReverse(first, second);
        }

        public LinkedListNode AdditionReverse(LinkedListNode l1, LinkedListNode l2)
        {
            var len1 = Length(l1);
            var len2 = Length(l2);

            if (len1 != len2)
            {
                if (len1 > len2)
                {
                    l2 = PadEmptyNode(l2, len1 - len2);
                }
                else
                {
                    l1 = PadEmptyNode(l1, len1 - len2);
                }
            }

            var res = AdditionReverseRecurse(l1, l2);

            if (res.Carry == 1)
            {
                return new LinkedListNode(0)
                {
                    data = 1,
                    Next = res.Node
                };
            }
            else
                return res.Node;
        }

        public RunningSum AdditionReverseRecurse(LinkedListNode l1, LinkedListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return new RunningSum();
            }

            var result = AdditionReverseRecurse(l1.Next, l2.Next);

            if (result != null)
            {
                var sum = l1.data + l2.data + result.Carry;

                var node = new LinkedListNode(0);

                node.data = sum % 10;
                node.Next = result.Node;

                return new RunningSum()
                {
                    Carry = sum > 9 ? 1 : 0,
                    Node = node
                };
            }
            return null;
        }
    }

    public class RunningSum
    {
        public LinkedListNode Node { get; set; }
        public int Carry { get; set; }
    }
}
