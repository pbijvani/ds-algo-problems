using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class sub_sort
    {
        /*
         * given a array find indices m and n
         * such that if you sort  element from m to n, 
         * the entire array would be sorted.
         * find smallest such sub sequence
         * 
         * {1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19}
         * 
         * Ans : 4-9
         * 
         * https://leetcode.com/problems/shortest-unsorted-continuous-subarray/solution/
         * 
         */
        public void SubSort(int[] input)
        {
            int leftStart = -1;
            int leftEnd = -1;
            int rightStart = -1;
            int rightEnd = -1;
            int midStart = -1;
            int midEnd = -1;

            int i = 0;
            leftStart = 0;
            leftEnd = 0;
            while(i < input.Length - 1)
            {
                if(input[i] > input[i + 1])
                {
                    leftEnd = i;
                    midStart = i + 1;
                    break;
                }
                i++;
            }

            i = input.Length - 1;
            rightEnd = i;
            while(i > 0)
            {
                if(input[i] < input[i - 1])
                {
                    rightStart = i;
                    midEnd = i - 1;
                    break;
                }
                i--;
            }

            // find min and max from mid array
            i = midStart;
            int midMin = int.MaxValue;
            int midMax = int.MinValue;

            while(i <= midEnd)
            {
                if(input[i] > midMax)
                {
                    midMax = input[i];
                }
                if(input[i] < midMin)
                {
                    midMin = input[i];
                }
                i++;
            }

            int m = -1;
            int n = -1;
            // go left from leftEnd and find element less than midMin
            i = leftEnd;
            while(i >= 0)
            {
                if(input[i] <= midMin)
                {
                    m = i + 1;
                    break;
                }
                i--;
            }

            // go right from rightStart
            i = rightStart;
            while(i <= rightEnd)
            {
                if(input[i] >= midMax)
                {
                    n = i - 1;
                    break;
                }
                i++;
            }

            Console.WriteLine($"m: {m}, n: {n}");
        }

        /*
         * another method:
         * when we say left.end <= min(remaining elements on right)
         * right.start > max (remainerr)
         * 
         * start from right traverse to left. Maintain running min.
         * find element where current element > running min
         */
        public void SubSortAnother(int[] input)
        {
            int m = findLeftSequenceEnd(input);
            // m = ....
        }

        public int findLeftSequenceEnd(int[] input)
        {
            int min = int.MaxValue;
            int m = 0;
            for(int i = input.Length - 1; i >=0; i--)
            {
                if (input[i] > min)
                    m = i;
                min = System.Math.Min(min, input[i]);
            }
            return m;
        }
    }
}
