using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class contigious_subarray
    {
        /// <summary>
        /// Find the contiguous subarray within an array (containing at least one number) 
        /// which has the largest sum.
        //For example, given the array[−2, 1,−3, 4,−1, 2, 1,−5, 4],
        //the contiguous subarray[4,−1, 2, 1] has the largest sum = 6.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SubArrayLargestSum(int[] input)
        {
            int maxSum = input[0];
            int runningSum = input[0];

            int startIndexRunning = 0;
            int endIndexRunning = 0;

            int startIndex = 0;
            int endIndex = 0;

            for(int i = 1; i < input.Length; i++)
            {
                if(runningSum + input[i] > input[i])
                {                    
                    runningSum += input[i];
                    endIndexRunning = i;
                }
                else
                {
                    runningSum = input[i];
                    startIndexRunning = endIndexRunning = i;
                }

                if(runningSum > maxSum)
                {
                    maxSum = runningSum;
                    startIndex = startIndexRunning;
                    endIndex = endIndexRunning;
                }                                
            }
            return input.SubArray(startIndex, endIndex-startIndex+1);
        }

        public void test()
        {
            var arr = new int[] { -2, 1,-3, 4,-1, 2, 1,-5, 4 };

            var res = SubArrayLargestSum(arr);
        }
    }
}
