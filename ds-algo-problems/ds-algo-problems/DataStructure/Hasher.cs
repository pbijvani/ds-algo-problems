using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.DataStructure
{
    public class Hasher<K, V>
    {
        private List<LinkListNodeForHash<K, V>> _hasherList;
        private int _capacity = 100;
        private class LinkListNodeForHash<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public LinkListNodeForHash<K, V> Next { get; set; }
            public LinkListNodeForHash<K, V> Prev { get; set; }

            public LinkListNodeForHash(K key, V val)
            {
                Key = key;
                Value = val;
            }
        }

        public void Insert(K key, V val)
        {
            var head = GetLinkedListNodeForKey(key);

            if(head != null)
            {
                head.Value = val;
                return;
            }

            head = new LinkListNodeForHash<K, V>(key, val);
            var index = GetHashedIndex(key);
            if(_hasherList[index] != null)
            {
                head.Next = _hasherList[index];
                _hasherList[index].Prev = head;
            }
            _hasherList[index] = head;            
        }

        public void Remove(K key)
        {
            var node = GetLinkedListNodeForKey(key);
            var index = GetHashedIndex(key);

            if (node != null)
            {
                if(node.Prev == null)
                {
                    _hasherList[index] = node.Next;
                }
                else if(node.Next == null)
                {
                    node.Prev.Next = null;
                }
                else
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }
            
            }            
            
        }

        public V Get(K key)
        {
            var node = GetLinkedListNodeForKey(key);

            return node.Value;// handle null
        }


        private LinkListNodeForHash<K, V> GetLinkedListNodeForKey(K key)
        {
            var index = GetHashedIndex(key);

            var head = _hasherList[index];

            while(head != null)
            {
                if(head.Key.ToString() == key.ToString())
                {
                    return head;
                }
                head = head.Next;
            }
            return null;
        }

        private int GetHashedIndex(K key)
        {
            return key.ToString().GetHashCode() % _capacity;
        }
    }


}
