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

            https://www.geeksforgeeks.org/kth-smallestlargest-element-unsorted-array-set-2-expected-linear-time/

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

        //Approach 2: Quickselect

        public int[] topKFrequent1(int[] nums, int k)
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

            var len = map.Count;

            var unique = new int[len];
            
            for(int i = 0; i < len; i++)
            {
                unique[i] = map.ElementAt(i).Key;
            }

            QuickSelect(map, unique, 0, len - 1, len - k);

            return unique.SubArray(len - k, k);

        }

        private void QuickSelect(Dictionary<int, int> map, int[] unique, int left, int right, int k_smallest)
        {
            if (left == right) return;

            // select pivot
            var pivotIndex = left +  ((right - left) / 2);

            // find the pivot position in a sorted list 

            pivotIndex = PartitionQuickSort(map, unique, left, right, pivotIndex);
            //pivotIndex = Partition(map, unique, left, right, pivotIndex);

            if(pivotIndex == k_smallest)
            {
                return;
            }
            else if(k_smallest < pivotIndex)
            {
                QuickSelect(map, unique, left, pivotIndex - 1, k_smallest);
            }
            else
            {
                QuickSelect(map, unique, pivotIndex + 1, right, k_smallest);
            }
        }

        // Hoare's partition logic : move pivot to end and then perform partition
        // at end move pivot back to right position.
        private int Partition(Dictionary<int, int> map, int[] unique, int left, int right, int pivotIndex)
        {
            int pivot_frequency = map[unique[pivotIndex]];

            // move pivot to end
            swap(unique, pivotIndex, right);

            int start_index = left;

            for(int i = left; i <= right; i++)
            {
                if(map[unique[i]] < pivot_frequency)
                {
                    swap(unique, start_index, i);
                    start_index++;
                }
            }

            // 3. move pivot to its final place
            swap(unique, start_index, right);

            return start_index;
        }
        // Quick sort original partition logic
        private int PartitionQuickSort(Dictionary<int, int> map, int[] unique, int left, int right, int pivotIndex)
        {
            while(left <= right)
            {
                while(map[unique[left]] < map[unique[pivotIndex]])
                {
                    left++;
                }

                while(map[unique[right]] > map[unique[pivotIndex]])
                {
                    right--;
                }

                if(left <= right)
                {
                    swap(unique, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        private void swap(int[] nums, int n1, int n2)
        {
            int tmp = nums[n1];
            nums[n1] = nums[n2];
            nums[n2] = tmp;
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
