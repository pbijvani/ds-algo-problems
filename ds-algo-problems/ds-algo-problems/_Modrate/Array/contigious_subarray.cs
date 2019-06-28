using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class contigious_subarray
    {
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
                maxSum = System.Math.Max(maxSum, runningSum);
            }
            return input.Slice(startIndex, endIndex);
        }
    }
}
