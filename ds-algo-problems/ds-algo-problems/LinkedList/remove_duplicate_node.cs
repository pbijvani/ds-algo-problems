using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    public class remove_duplicate_node
    {
        public void Test1()
        {
            LinkedListNode head = new LinkedListNode(1);
            head.Next = new LinkedListNode(2);
            head.Next.Next = new LinkedListNode(3);
            head.Next.Next.Next = new LinkedListNode(1);
            head.Next.Next.Next.Next = new LinkedListNode(4);
            head.Next.Next.Next.Next.Next = new LinkedListNode(5);

            LinkedListRemoveDuplicateWIthoutExtraBuffer(head);

            LinkedListRemoveDuplicate(head);


        }
        public void LinkedListRemoveDuplicate(LinkedListNode head)
        {
            HashSet<int> dict = new HashSet<int>();
            LinkedListNode prev = null;
            LinkedListNode curr = head;
            while (curr != null)
            {
                if (dict.Contains(curr.data))
                {
                    prev.Next = curr.Next;
                }
                else
                {
                    dict.Add(curr.data);
                }

                prev = curr;
                curr = curr.Next;
            }
        }

        public void LinkedListRemoveDuplicateWIthoutExtraBuffer(LinkedListNode head)
        {
            HashSet<int> dict = new HashSet<int>();
            LinkedListNode prev = null;
            LinkedListNode curr = head;
            LinkedListNode running = head;

            while (curr != null)
            {
                running = curr;
                prev = curr;

                while (running != null)
                {
                    if (running.data == curr.data)
                    {
                        prev.Next = running.Next;
                    }
                    prev = running;
                    running = running.Next;
                }

                curr = curr.Next;
            }
        }
    }

    public class LinkedListNode
    {
        public LinkedListNode(int _data)
        {
            data = _data;
        }

        public int data { get; set; }
        public LinkedListNode Next { get; set; }
        public LinkedListNode Prev { get; set; }
    }
}
