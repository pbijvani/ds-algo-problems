using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Problems
{
    public class LRU_Cache
    {        
        private readonly int maxCacheSize;
        private readonly Dictionary<int, DoublyLinkedListNode> dict;

        private DoublyLinkedListNode ListHead;
        private DoublyLinkedListNode ListTail;

        public LRU_Cache()
        {            
            dict = new Dictionary<int, DoublyLinkedListNode>();
            maxCacheSize = 10;
        }

        public void Insert(int key, string data)
        {
            if(dict.ContainsKey(key))
            {
                RemoveKey(key);
            }
            
            if(dict.Count >= maxCacheSize)
            {
                RemoveKey(ListTail.Key);
            }

            var node = new DoublyLinkedListNode(key, data);
            InsertAtFrontOfList(node);
            dict.Add(key, node);
        }

        public void RemoveKey(int key)
        {
            if(dict.ContainsKey(key))
            {
                var node = dict[key];
                RemoveFromList(node);
                dict.Remove(key);
            }
        }

        public string Fetch(int key)
        {
            if(dict.ContainsKey(key))
            {
                var node = dict[key];
                if(node != ListHead)
                {
                    RemoveFromList(node);
                    InsertAtFrontOfList(node);
                }

                return node.Data;
            }
            else
            {
                return null;
            }
        }

        private void RemoveFromList(DoublyLinkedListNode node)
        {
            if (node == null) return;
            if (node.Prev != null) node.Prev.Next = node.Next;
            if (node.Next != null) node.Next.Prev = node.Prev;
            if (node == ListTail) ListTail = node.Prev;
            if (node == ListHead) ListHead = node.Next;
        }

        private void InsertAtFrontOfList(DoublyLinkedListNode node)
        {
            if(ListHead == null)
            {
                ListHead = node;
                ListTail = node;
            }
            else
            {
                ListHead.Prev = node;
                node.Next = ListHead;
                ListHead = node;
                ListHead.Prev = null;
            }
        }
    }

    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode(int key, string data)
        {
            this.Key = key;
            this.Data = data;
        }
        public int Key { get; set; }
        public string Data { get; set; }
        public DoublyLinkedListNode Next { get; set; }
        public DoublyLinkedListNode Prev { get; set; }
    }
}
