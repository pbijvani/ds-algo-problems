using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Heap
{
    public class top_k_frequent_ele
    {
        /*
         Given a non-empty array of integers, return the k most frequent elements.

        Example 1:

        Input: nums = [1,1,1,2,2,3], k = 2
        Output: [1,2]
        Example 2:

        Input: nums = [1], k = 1
        Output: [1]

        Time complexity : \mathcal{O}(N \log k)O(Nlogk) if k < Nk<N

        Space complexity : \mathcal{O}(N + k)O(N+k) to store the hash map with not more NN elements and a heap with kk elements.


        https://leetcode.com/problems/top-k-frequent-elements/

         */
        public int[] TopKFrequent(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();

            foreach(var num in nums)
            {
                if(map.ContainsKey(num))
                {
                    map[num] = map[num] + 1;
                }
                else
                {
                    map.Add(num, 1);
                }
            }

            var minHeap = new Heap<ElementFrequency>();

            for(int i = 0; i < map.Count; i++)
            {
                var item = map.ElementAt(i);
                
                if(i < k)
                {
                    minHeap.Add(new ElementFrequency()
                    {
                        Element = item.Key,
                        Frequency = item.Value
                    });
                }
                else
                {
                    if(item.Value > minHeap.GetMin().Frequency)
                    {
                        minHeap.PopMin();
                        minHeap.Add(new ElementFrequency()
                        {
                            Element = item.Key,
                            Frequency = item.Value
                        });
                    }
                }

                // We need a custom heap with holds both key and value
                
                // Step 1: Insert first k element in minHeap

                // Step 2: repeat from k+1 to N
                // If element count is greater than minHeap.Peek(), then remove top element and insert new

            }

            var resultArray = new int[k];

            for(int i = 0; i < k; i++)
            {
                var item = minHeap.PopMin();

                resultArray[i] = item.Element;
            }

            return resultArray;
        }
    }

    public class ElementFrequency : IComparable
    {
        public int Element { get; set; }
        public int Frequency { get; set; }

        public int CompareTo(object obj)
        {
            var typedObj = obj as ElementFrequency;

            if (this.Frequency == typedObj.Frequency) return 0;
            else if (this.Frequency > typedObj.Frequency) return 1;
            else return -1;
        }
    }
}
