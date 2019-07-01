using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Problems
{
    public class histogram_largest_rectangle
    {

        /*
         * you are given a array which is equivalent of histogram.
         * find the largest rectangle.
         * 
         * Sol-1: Brute force.
         * Start from 1st elemnt and for every element traverse both side 
         * and find index where element is equal or larger of its height. Then calculate rectangele side
         * repete this for every element. Keep global max.
         * 
         * below is optimum solution
         */
        public int LargestRectangle(int[] input)
        {
            int len = input.Length;
            int largestElementIndex = 0;
            int index = 0;
            while(largestElementIndex < len && input[largestElementIndex] <= input[largestElementIndex + 1])
            {
                largestElementIndex++;
            }

            int nextLargeBarSize = input[largestElementIndex];

            int indexLeft = largestElementIndex;
            int indexRight = largestElementIndex;
            int globalMax = input[largestElementIndex];
            int localMax = input[largestElementIndex];
            
            while (indexLeft >=0 && indexRight < len)
            {
                if(indexLeft == 0)
                {
                    nextLargeBarSize = input[indexRight + 1];
                }
                else if(indexRight == len - 1)
                {
                    nextLargeBarSize = input[indexLeft - 1];
                }
                else
                {
                    nextLargeBarSize = System.Math.Max(input[indexLeft - 1], input[indexRight + 1]);
                }                

                while(indexLeft > 0 && input[indexLeft-1] >= nextLargeBarSize)
                {
                    indexLeft--;
                }

                while(indexRight < len - 1 && input[indexRight+1] >= nextLargeBarSize)
                {
                    indexRight++;
                }

                int noOfBars = indexRight - indexLeft + 1;

                localMax = noOfBars * nextLargeBarSize;

                globalMax = System.Math.Max(globalMax, localMax);

                if (indexLeft == 0 && indexRight == len - 1) break;
            }

            return globalMax;
        }
    }
}
