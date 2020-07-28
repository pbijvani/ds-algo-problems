using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.LinkedList
{
    /*
     * 
     * Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

        Return the linked list sorted as well.

        Example 1:

        Input: 1->2->3->3->4->4->5
        Output: 1->2->5
        Example 2:

        Input: 1->1->1->2->3
        Output: 2->3

     */
    public class remove_duplicate_variant
    {
        public Node RemoveAllDuplicate(Node head)
        {
            var set = new HashSet<int>();

            var curr = head;

            while(curr != null)
            {
                if(curr.next != null && curr.data == curr.next.data)
                {
                    set.Add(curr.data);
                }

                curr = curr.next;
            }
            var newHead = head;
            curr = head;
            Node prev = null;
            var isRepeateCase = false;

            while(curr != null)
            {
                if(set.Contains(curr.data))
                {
                    curr = curr.next;
                    isRepeateCase = true;
                    continue;
                }

                if(isRepeateCase)
                {
                    if(prev == null)
                    {
                        newHead = curr;
                    }
                    else
                    {
                        prev.next = curr;
                    }                    
                    isRepeateCase = false;                    
                }
                prev = curr;
                curr = curr.next;
            }

            if(isRepeateCase)
            {
                if (prev == null)
                {
                    newHead = curr;
                }
                else
                {
                    prev.next = curr;
                }
            }

            return newHead;
        }

        public Node RemoveAllDuplicate1(Node head)
        {
            if (head == null) return null;

            var fakeHead = new Node(int.MinValue);
            fakeHead.next = head;
            var prev = fakeHead;
            var curr = head;

            while(curr != null)
            {
                while(curr.next != null && curr.data == curr.next.data)
                {
                    curr = curr.next;
                }

                if(prev.next == curr)
                {
                    prev = prev.next;
                }
                else
                {
                    prev.next = curr.next;
                }
                curr = curr.next;
            }

            return fakeHead.next;

            
        }

        public void Test()
        {
            var head = new Node(1)
            {
                next = new Node(2)
                {
                    next = new Node(2)
                    {
                        next = new Node(3)
                        {
                            next = new Node(3)
                            {
                                next = new Node(4)
                            }
                        }
                    }
                }
            };

            //var head = new Node(1)
            //{
            //    next = new Node(1)
            //    {
            //        next = new Node(2)
            //        {
            //            next = new Node(3)
            //            {
            //                next = new Node(3)
            //                {
            //                    next = new Node(4)
            //                }
            //            }
            //        }
            //    }
            //};

            //var head = new Node(1)
            //{
            //    next = new Node(1)
            //    {
            //        next = new Node(2)
            //        {
            //            next = new Node(3)
            //            {
            //                next = new Node(4)
            //                {
            //                    next = new Node(4)
            //                }
            //            }
            //        }
            //    }
            //};

            //var head = new Node(1)
            //{
            //    next = new Node(1)
            //    {
            //        next = new Node(1)
            //        {
            //            next = new Node(1)
            //            {
            //                next = new Node(1)
            //                {
            //                    next = new Node(1)
            //                }
            //            }
            //        }
            //    }
            //};

            var res = RemoveAllDuplicate1(head);
        }
    }
}
