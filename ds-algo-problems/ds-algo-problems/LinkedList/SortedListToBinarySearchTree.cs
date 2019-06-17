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
    }
}
