using ds_algo_problems.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LinkedList
{
    public class SortedListToBinarySearchTree
    {
        /*
         * RUntime : Time - N log N
         * Space : Log N
         */
        public TreeNode sortedListToBST(Node head)
        {

            // If the head doesn't exist, then the linked list is empty
            if (head == null)
            {
                return null;
            }

            // Find the middle element for the list.
            Node mid = this.findMiddleElement(head);

            // The mid becomes the root of the BST.
            TreeNode node = new TreeNode(mid.data);

            // Base case when there is just one element in the linked list
            if (head == mid)
            {
                return node;
            }

            // Recursively form balanced BSTs using the left and right halves of the original list.
            node.left = this.sortedListToBST(head);
            node.right = this.sortedListToBST(mid.next);
            return node;
        }

        private Node findMiddleElement(Node head)
        {
            // The pointer used to disconnect the left half from the mid node.
            Node prevPtr = null;
            Node slowPtr = head;
            Node fastPtr = head;

            // Iterate until fastPr doesn't reach the end of the linked list.
            while (fastPtr != null && fastPtr.next != null)
            {
                prevPtr = slowPtr;
                slowPtr = slowPtr.next;
                fastPtr = fastPtr.next.next;
            }

            // Handling the case when slowPtr was equal to head.
            if (prevPtr != null)
            {
                prevPtr.next = null;
            }

            return slowPtr;
        }


        /*
         * Method 2 : Convert linked list to ArrayList (List)
         * ANd then apply BST
         * Time: O (N)
         * SPace : O (N)
         */

        public TreeNode SortedListToBST1(Node node)
        {
            var list = GetArrayList(node);

            var len = list.Count;

            return SortedListToBST1Rec(list, 0, len - 1);
        }

        public TreeNode SortedListToBST1Rec(List<int> list, int start, int end)
        {
            var mid = (start + end) / 2;

            var treeNode = new TreeNode(list[mid]);

            if(mid == start)
            {
                return treeNode;
            }

            treeNode.left = SortedListToBST1Rec(list, start, mid - 1);
            treeNode.right = SortedListToBST1Rec(list, mid + 1, end);

            return treeNode;
        }

        private List<int> GetArrayList(Node node)
        {
            var ret = new List<int>();
            while(node != null)
            {
                ret.Add(node.data);
                node = node.next;
            }
            return ret;
        }
    }

    /*
     * BST when you do in order traversal, it will giv you element in sorted order.
     * using this propety of BST will just traverse to sorted list from left to right and construct tree
     * Time : O (N)
     Space : O (log N)
     */ 
    public class ListToBSTInOrder
    {
        public Node _head;
        public ListToBSTInOrder(Node head)
        {
            _head = head;
        }

        private int GetLength()
        {
            var len = 0;
            var curr = _head;
            while(curr != null)
            {
                len++;
            }
            return len;
        }

        private TreeNode ConvertToTreeRec(int left, int right)
        {
            if (left > right) return null;

            var mid = (left + right) / 2;

            // First step of simulated inorder traversal. Recursively form
            // the left half
            TreeNode leftNode = ConvertToTreeRec(left, mid - 1);

            // Once left half is traversed, process the current node
            TreeNode root = new TreeNode(_head.data);
            root.left = leftNode;

            // Maintain the invariance mentioned in the algorithm
            _head = _head.next;

            TreeNode rightNode = ConvertToTreeRec(mid + 1, right);
            root.right = rightNode;

            return root;
        }

        public TreeNode ConvertToBST()
        {
            var len = GetLength();

            return ConvertToTreeRec(0, len - 1);
        }
    }

}
