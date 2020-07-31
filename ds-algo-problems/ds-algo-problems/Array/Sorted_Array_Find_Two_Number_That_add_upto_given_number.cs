using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Sorted_Array_Find_Two_Number_That_add_upto_given_number
    {
        /// <summary>
        /// Two Sum II - Input array is sorted
        /// Given an array of integers that is already sorted in ascending order, 
        /// find two numbers such that they add up to a specific target number
        /// The function twoSum should return indices of the two numbers such that they add up to the target, 
        /// where index1 must be less than index2
        /// Input: numbers = [2,7,11,15], target = 9
        /// Output: [1,2]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 

        // Two pass Hashtable : time O(N)
        public Tuple<int, int> TwoSum1(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();

            for(int i = 0; i < numbers.Length; i++)
            {
                dict.Add(numbers[i], i);
            }

            for(int i = 0; i < numbers.Length; i++)
            {
                var missingPart = target - numbers[i];

                if(dict.ContainsKey(missingPart) && dict[missingPart] != i)
                {
                    return new Tuple<int, int>(numbers[i], numbers[dict[missingPart]]);
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        // One pass Hashtable : time O(N)
        public Tuple<int, int> TwoSumOnePass(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var missingPart = target - numbers[i];

                if(dict.ContainsKey(missingPart))
                {
                    return new Tuple<int, int>(numbers[i], numbers[dict[missingPart]]);
                }
                else
                    dict.Add(numbers[i], i);
            }


            return new Tuple<int, int>(-1, -1);
        }

        public Tuple<int, int> TwoSum(int[] numbers, int target)
        {
            for (int i = 0, j = numbers.Length; i < j;)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return new Tuple<int, int>(i, j);
                }
                else if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return new Tuple<int, int>(-1, -1);
        }
    }
}
