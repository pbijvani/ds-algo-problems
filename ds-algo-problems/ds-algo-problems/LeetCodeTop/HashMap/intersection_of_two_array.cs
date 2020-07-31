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

        /*
         * Variation: Given array are sorted.
         * Time: O(M + N)
         * Space: O(1)
         */
        public int[] IntersectionSortedArray(int[] nums1, int[] nums2)
        {
            var len1 = nums1.Length;
            var len2 = nums2.Length;

            if (len1 == 0 || len2 == 0) return new int[] { };

            var ptr1 = 0;
            var ptr2 = 0;

            var list = new List<int>();

            while(ptr1 < len1 && ptr2 < len2)
            {
                if(nums1[ptr1] == nums2[ptr2])
                {
                    list.Add(nums1[ptr1]);
                    ptr1++;
                    ptr2++;
                }
                else if(nums1[ptr1] < nums2[ptr2])
                {
                    ptr1++;
                }
                else // nums1[ptr1] > nums2[ptr2]
                {
                    ptr2++;
                }
            }

            return list.ToArray();
        }

        public void Test()
        {
            var arr1 = new int[] { 1, 2, 2, 1 };
            var arr2 = new int[] { 2, 2 };

            var res = IntersectionSortedArray(arr1, arr2);
        }
    }
}
