using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    /*
Given a sorted array arr, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

 

Example 1:

Input: arr = [1,2,3,4,5], k = 4, x = 3
Output: [1,2,3,4]
Example 2:

Input: arr = [1,2,3,4,5], k = 4, x = -1
Output: [1,2,3,4]
 

https://leetcode.com/problems/find-k-closest-elements/      
     */
    public class Find_k_closest_elements_of_given_number_in_array
    {
        /*
Time complexity : O(\log n +k)O(logn+k). O(\log n)O(logn) is for the time of binary search, while O(k)O(k) is for shrinking the index range to k elements.

Space complexity : O(k)O(k). It is to generate the required sublist.         
         */
        public IList<int> FindClosestElements1(int[] arr, int k, int x)
        {
            var len = arr.Length;

            if (len < k) return arr; 
            if (x <= arr[0] || len == k) return SubArray(arr, 0, k - 1, k);
            if (x > arr[len-1]) return SubArray(arr, len - k, len - 1, k);

            var index = BS(arr, x);

            var left = index;
            var right = index;            

            while(right - left + 1 < k)
            {
                var opt1 = left == 0 ? int.MaxValue : System.Math.Abs(arr[left - 1] - x);
                var opt2 = right == arr.Length - 1 ? int.MaxValue : System.Math.Abs(arr[right + 1] - x);

                if (opt1 <= opt2)
                {
                    left--;
                }
                else
                {
                    right++;
                }
            }

            return SubArray(arr, left, right, k);
        }

        private int[] SubArray(int[] arr, int left, int right, int k)
        {
            var res = new int[k];
            var indx = 0;
            for (int i = left; i <= right; i++)
            {
                res[indx] = arr[i];
                indx++;
            }

            return res;
        }

        public int BS(int[] arr, int x)
        {
            // Binary Search
            // If x found return index of x
            // If x not found, return index of closest ele of x

            var left = 0;
            var right = arr.Length - 1;
            var mid = -1;

            while(left <= right)
            {
                mid = (left + right) / 2;

                if (arr[mid] == x) return mid;

                if(x < arr[mid])
                {
                    right = mid - 1;
                }

                if(arr[mid] < x)
                {
                    left = mid + 1;
                }
            }

            if (mid == 0)
            {
                return -1;
            }
            else 
            {
                return System.Math.Abs(arr[mid] - x) < System.Math.Abs(arr[mid - 1] - x) ? mid : mid - 1;
            }

        }

        public int[] FindClosestELement(int[] input, int k, int x)
        {
            int len = input.Length;
            if (x <= input[0])
            {
                return input.SubArray(0, k);
            }
            else if (x >= input[len - 1])
            {
                return input.SubArray(len - k - 1, k);
            }
            else
            {
                var difference = new int[len];

                for (int j = 0; j < len; j++)
                {
                    difference[j] = System.Math.Abs(input[j] - x);
                }

                int i = 0;

                while (difference[i] > difference[i + 1])
                {
                    i++;
                }

                int left = i;
                int right = i;
                int count = 0;

                int[] result = new int[k];
                result[count] = input[i];

                while (count < k - 1)
                {
                    var option1 = right == len ? int.MaxValue : System.Math.Abs(difference[right] - difference[right + 1]);
                    var option2 = left == 0 ? int.MaxValue : System.Math.Abs(difference[left] - difference[left - 1]);

                    if (option1 < option2)
                    {
                        right++;
                        count++;
                        result[count] = input[right];
                    }
                    else
                    {
                        left--;
                        count++;
                        result[count] = input[left];
                    }
                }

                return result;
            }
        }
    }
}
