using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://aonecode.com/amazon-online-assessment-load-balancer
     * https://stackoverflow.com/questions/52600864/drop-two-elements-to-split-the-array-to-three-part-evenly-in-on/52600976
     * 
        Given an array containing only positive integers, return if you can pick two integers from the array which cuts the array into three pieces such that the sum of elements in all pieces is equal.

 
        Example 1:

        Input:  array = [2, 4, 5, 3, 3, 9, 2, 2, 2]

        Output: true

        Explanation: choosing the number 5 and 9 results in three pieces [2, 4], [3, 3] and [2, 2, 2]. Sum = 6.

 

        Example 2:

        Input:  array =[1, 1, 1, 1],

        Output: false      
     */
    public class load_balancer
    {
        public int[] LoadBalancer(int[] array)
        {
            var len = array.Length;

            if (len < 5) return new int[] { };

            var totalSum = array.Sum();            

            var leftIndex = 1;
            var rightIndex = len - 2;

            var sumLeft = array[0];
            var sumRight = array[len - 1];

            while(leftIndex < rightIndex)
            {
                if(sumLeft == sumRight)
                {
                    var totalRes = totalSum - array[leftIndex] - array[rightIndex];
                    if(3* sumLeft == totalRes)
                    {
                        return new int[] { array[leftIndex], array[rightIndex] };
                    }
                    else
                    {
                        sumLeft = sumLeft + array[leftIndex];
                        leftIndex++;
                    }
                }
                else if(sumLeft < sumRight)
                {
                    sumLeft = sumLeft + array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    sumRight = sumRight + array[rightIndex];
                    rightIndex--;
                }
            }            

            return new int[] { };
        }

        public void test()
        {
            var array = new int[] { 2, 4, 5, 3, 3, 9, 2, 2, 2 };

            var res = LoadBalancer(array);
        }

        private int GetPartIndex(int[] array, int startIndex, int partSum)
        {
            var len = array.Length;
            var runningSum = 0;

            var index = startIndex;
            while (index < len && runningSum != partSum)
            {
                runningSum = runningSum + array[index];
                index++;
            }

            if (runningSum == partSum)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }
    }
}
