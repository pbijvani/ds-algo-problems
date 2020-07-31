using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Heap
{
    public class k_pair_with_smallest_sum
    {
        /*
            You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

            Define a pair (u,v) which consists of one element from the first array and one element from the second array.

            Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

            Example 1:

            Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
            Output: [[1,2],[1,4],[1,6]] 
            Explanation: The first 3 pairs are returned from the sequence: 
                         [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
            Example 2:

            Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
            Output: [1,1],[1,1]
            Explanation: The first 2 pairs are returned from the sequence: 
                         [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
            Example 3:

            Input: nums1 = [1,2], nums2 = [3], k = 3
            Output: [1,3],[2,3]
            Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]   
            
            https://leetcode.com/problems/find-k-pairs-with-smallest-sums/
         */

        // Time : O(K Log K)
        public List<List<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            if(nums1.Length == 0 || nums2.Length == 0 || k == 0)
            {
                return null;
            }

            var minHeap = new ds_algo_problems.DataStructure.Heap<Pair>();

            foreach(var item in nums1)
            {
                minHeap.Add(new Pair()
                {
                    num1 = item,
                    num2 = nums2[0],
                    index2 = 0
                });
            }

            var result = new List<List<int>>();

            while(k > 0 && minHeap.GetSize() > 0)
            {
                var heapElement = minHeap.PopMin();

                result.Add(new List<int>() { heapElement.num1, heapElement.num2 });

                if (heapElement.index2 < nums2.Length - 1)
                {
                    minHeap.Add(new Pair()
                    {
                        num1 = heapElement.num1,
                        num2 = nums2[heapElement.index2 + 1],
                        index2 = heapElement.index2 + 1
                    });
                }

                k = k - 1;
            }

            return result;
        }

        public void Test()
        {
            var res = KSmallestPairs(new int[] { 1, 7, 11 }, new int[] { 2, 4, 6 }, 3);
        }
    }

    public class Pair : IComparable
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int index2 { get; set; }
        public int Sum
        {
            get { return num1 + num2; }
        }
        public int CompareTo(object obj)
        {
            var typedObj = obj as Pair;

            if(this.Sum == typedObj.Sum)
            {
                return 0;
            }
            else if(this.Sum > typedObj.Sum)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }
    }
}
