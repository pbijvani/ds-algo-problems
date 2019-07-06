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
    }
}
