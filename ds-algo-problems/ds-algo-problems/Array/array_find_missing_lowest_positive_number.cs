using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class array_find_missing_lowest_positive_number
    {
        /*
         * Given an array of integers, find the first missing positive integer in linear time and constant space. 
         * In other words, find the lowest positive integer that does not exist in the array. 
         * The array can contain duplicates and negative numbers as well.

            For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.


         */

        // Soluntion in O(n) time and O(1) space

        public int FindMissingLowestPositiveNum1(int[] array)
        {
            var index = 0;
            var len = array.Length;

            while (index < len)
            {
                var num = array[index];
                if (num > 0 && num < len + 1)
                {
                    while (num > 0 && num < len + 1)
                    {
                        var nextIndex = num % len;
                        num = array[nextIndex];
                        array[nextIndex] = int.MinValue;
                    }
                }
                index++;
            }

            for (int i = 0; i < len; i++)
            {
                if (array[i] != int.MinValue)
                {
                    index = i;
                    break;
                }
            }

            return index == 0 ? len : index;
        }


        //Some modification to pass all leetcode test cases
        public int FindMissingLowestPositiveNum(int[] array)
        {
            if (array.Length == 0) return 1;
            var index = 0;
            var len = array.Length;

            while(index < len)
            {
                var num = array[index];
                if (num > 0 && num < len + 1)
                {                                     
                    while(num > 0 && num < len + 1)
                    {
                        var nextIndex = num % len;
                        num = array[nextIndex];
                        array[nextIndex] = int.MinValue;                        
                    }                                        
                }
                index++;
            }
            index = -1;
            for(int i = 1; i < len; i++)
            {
                if(array[i] != int.MinValue)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1 && array[0] != int.MinValue) index = 0;

            if(index == -1)
            {
                return len + 1;
            }
            else
                return index == 0 ? len : index;
        }

    }
}
