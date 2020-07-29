using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Heap
{
    public class KthLargest
    {
        /*
         
        Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

        Your KthLargest class will have a constructor which accepts an integer k and an integer array nums, which contains initial elements from the stream. For each call to the method KthLargest.add, return the element representing the kth largest element in the stream.

        Example:

        int k = 3;
        int[] arr = [4,5,8,2];
        KthLargest kthLargest = new KthLargest(3, arr);
        kthLargest.add(3);   // returns 4
        kthLargest.add(5);   // returns 5
        kthLargest.add(10);  // returns 5
        kthLargest.add(9);   // returns 8
        kthLargest.add(4);   // returns 8

        https://leetcode.com/problems/kth-largest-element-in-a-stream/

         */

        private readonly MinHeap _minHeap;
        private readonly int _k;
        public KthLargest(int k, int[] nums)
        {
            _minHeap = new MinHeap();
            _k = k;

            foreach(var item in nums)
            {
                this.Add(item);
            }
        }

        public int Add(int val)
        {
            if(_minHeap.IsEmpty() || _minHeap.Peek() <= val)
            {
                _minHeap.Insert(val);

                if(_minHeap.Size() > _k)
                {
                    _minHeap.Poll();
                }
            }

            return _minHeap.Peek();
        }

        public int GetKthLargest()
        {
            if(_minHeap.IsEmpty())
            {
                return -1;
            }
            else
            {
                return _minHeap.Peek();
            }
        }

        public void Test()
        {
            var obj = new KthLargest(3, new int[] { 10, 20, 30, 40, 50, 60, 70, 80 });

            Console.WriteLine(obj.GetKthLargest());
            Console.WriteLine(obj.Add(11));
            Console.WriteLine(obj.Add(22));
            Console.WriteLine(obj.Add(85));
            Console.WriteLine(obj.Add(65));
        }
    }
}
