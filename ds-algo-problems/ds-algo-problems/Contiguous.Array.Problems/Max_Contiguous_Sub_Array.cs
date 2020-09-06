using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class MaxContiguousSubArray
    {
        /// <summary>
        /// Find the contiguous subarray within an array (containing at least one number) 
        /// which has the largest sum.
        //For example, given the array[−2, 1,−3, 4,−1, 2, 1,−5, 4],
        //the contiguous subarray[4,−1, 2, 1] has the largest sum = 6.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int maxSubArray3(int[] arr)
        {
            var res = new int[arr.Length];
            int runningTotal = arr[0];
            int maxSoFar = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                runningTotal = runningTotal + arr[i] > arr[i] ? runningTotal + arr[i] : arr[i];
                if (maxSoFar < runningTotal)
                {
                    maxSoFar = runningTotal;
                }
            }
            return maxSoFar;
        }
    }
}
