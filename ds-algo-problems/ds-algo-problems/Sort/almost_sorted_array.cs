using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class almost_sorted_array
    {
        /*
         * You are given an array and int k
         * array is almost sorted. what that mean is every element in array is within k elements away from its actual position in sorted array
         * sort the array 
         * 
         * method1: any sorting method can be applied.
         * 
         * method2: use max heap, Runtime : N Log K 
         */

        public int[] SortAlmostSortedArray(int[] array, int k)
        {
            var minHeap = new MinHeap();

            // insert k+1 element into heap

            for(int i = 0; i < k+1; i++)
            {
                minHeap.Insert(array[i]);
            }
            var index = 0;
            for(int i = k+2; i < array.Length; i++)
            {
                var minFromHeap = minHeap.Poll();

                array[index] = minFromHeap;
                index++;

                minHeap.Insert(array[i]);
            }

            for(int i = index; i < array.Length; i++)
            {
                var minFromHeap = minHeap.Poll();
                array[i] = minFromHeap;
            }

            return array;
        }
    }
}
