using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    /*
        Example 1:
	        Input:  nums = [1,0,1,1,0]
	        Output:  4
	
	        Explanation:
	        Flip the first zero will get the the maximum number of consecutive 1s.
	        After flipping, the maximum number of consecutive 1s is 4.

        Example 2:
	        Input: nums = [1,0,1,0,1]
	        Output:  3
	
	        Explanation:
	        Flip each zero will get the the maximum number of consecutive 1s.
	        After flipping, the maximum number of consecutive 1s is 3.      
     */
    public class max_consecutive_ones_ii
    {
        public int ConsecutiveOnes1(int[] arr)
        {
            int k = 1; // Can flip k bits from 0 to one

            int left = 0;
            int right = 0;

            var len = arr.Length;

            int countOfZero = 0;
            int CountOfOnes = 0;
            int maxCount = 0;

            while (left <= right && right < len)
            {
                if(arr[right] == 0)
                {
                    countOfZero++;
                }
                else
                {
                    CountOfOnes++;
                }

                while(countOfZero > k)
                {
                    if (arr[left] == 0)
                        countOfZero--;
                    else
                        CountOfOnes--;
                    left++;
                }

                maxCount = System.Math.Max(maxCount, countOfZero + CountOfOnes);
                right++;
            }
            return maxCount;
        }

        public void test()
        {
            var nums = new int[] { 1, 0, 1, 1, 0 };

            var res = ConsecutiveOnes1(nums);
        }
    }
}
