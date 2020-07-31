using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.HashMap
{
    public class intersection_of_two_array
    {
        /*
         * Given two arrays, write a function to compute their intersection.

            Example 1:

            Input: nums1 = [1,2,2,1], nums2 = [2,2]
            Output: [2]
            Example 2:

            Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
            Output: [9,4]

         */


        /*
         Approach 1 : for each element in arra1 look in array2 if it exists
         Time : O(M * N)

        Approach 2: Using Hashset
        Time : O(M+N)
        Space : O(N) N is the largest of M and N 
         */


        /*
         * Below solution bring below result in case of duplicate
         *  Input: nums1 = [1,2,2,1], nums2 = [2,2]
            Output: [2, 2]

            if you want output [2], then you dont need to maintain counter in dict
           
         */
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var map = new Dictionary<int, int>();

            foreach(var num in nums1)
            {
                if(!map.ContainsKey(num))
                {
                    map.Add(num, 1);
                }
                else
                {
                    map[num] = map[num] + 1;
                }
            }

            var res = new List<int>();

            foreach (var num in nums2)
            {
                if(map.ContainsKey(num))
                {
                    res.Add(num);
                    if(map[num] == 1)
                    {
                        map.Remove(num);
                    }
                    else
                    {
                        map[num] = map[num] - 1;
                    }
                }
            }

            return res.ToArray();
        }
    }
}
