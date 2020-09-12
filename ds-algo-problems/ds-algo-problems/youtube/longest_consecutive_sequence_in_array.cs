using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class longest_consecutive_sequence_in_array
    {
        /*
         * Given an unsorted array of integers, find the length of the longest consecutive elements sequence
         * Input: [100, 4, 200, 1, 3, 2]
            Output: 4
            Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

            https://leetcode.com/problems/longest-consecutive-sequence/
         */

        /*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
         * Sol 1 : brute force
         * iterate over array
         * for each element, keep finding next element until it exist in array. break when it doesnt exist.
         * maintain local sequence count along.
         * at end compare it with global sequence cound
         * This is O(n pow 3) sol
         */

        /*
         * Sol2: Sort array and iterate over array to find contineous sol
         * O(N lon N)
         */

        public int LongestSequenc(int[] input)
        {
            var set = new HashSet<int>();

            foreach(var num in input)
            {
                set.Add(num);
            }
            int globalMaxCount = 0;
            foreach(var num in input)
            {                
                if (!set.Contains(num - 1))
                {
                    int localMaxCount = 1;
                    int currNum = num;                    
                    while (set.Contains(currNum + 1))
                    {
                        currNum++;
                        localMaxCount++;
                    }
                    globalMaxCount = System.Math.Max(globalMaxCount, localMaxCount);                    
                }                
            }
            return globalMaxCount;
            
        }
    }
}
