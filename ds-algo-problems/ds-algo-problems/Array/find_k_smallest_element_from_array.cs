using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class find_k_smallest_element_from_array
    {
        // Using Min Heap..
        // Not effective because we have to build heap with all element
        // displays 0, 1, 3
        public void kSmallestElement(int[] input, int k)
        {
            MinHeap heap = new MinHeap();

            foreach(var num in input)
            {
                heap.Insert(num);
            }

            for(int i = 0; i < k; i++)
            {
                Console.WriteLine(heap.Poll());
            }
        }

        // displays 3, 1, 0
        public void kSmallestELement1(int[] input, int k)
        {
            MaxHeap heap = new MaxHeap();

            for (int i = 0; i < k; i++)
            {
                heap.Insert(input[i]);
            }

            for (int i = k; i < input.Length; i++)
            {
                if(heap.Peek() > input[i])
                {
                    heap.Poll();
                    heap.Insert(input[i]);
                }
            }

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(heap.Poll());
            }
        }
        // Using Quick Sort Selection menthod
        public int KthElement(int[] arr, int k)
        {
            return kthSmallest(arr, 0, arr.Length - 1, arr.Length - k + 1);
        }        

        public int kthSmallest(int[] arr, int startIndex,
                                  int endIndex, int k)
        {
            //if (l >= r)
            //    return index;

            int pivot = arr[endIndex];

            int left = startIndex;
            int right = endIndex;

            int index = PartitionKth(arr, left, right, pivot);

            arr.Swap<int>(index, endIndex);            


            if (k == index + 1)
                return pivot;
            else if(k < index + 1)
            {
                return kthSmallest(arr, startIndex, index - 1, k);
            }
            else 
            {
                return kthSmallest(arr, index + 1, endIndex, k);
            }
        }

        public int PartitionKth(int[] array, int left, int right, int pivot)
        {
            while (left < right)
            {
                while (array[left] < pivot && left < right)
                {
                    left++;
                }

                while (array[right] >= pivot && left < right)
                {
                    right--;
                }

                if (left < right)
                {
                    array.Swap<int>(left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }        

    }
}
