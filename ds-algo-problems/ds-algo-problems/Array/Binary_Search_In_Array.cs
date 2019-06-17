using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class BinarySearchInArray
    {
        public int BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
        public int BinarySearchIterative(int[] input, int key)
        {
            int min = 0;
            int max = input.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (key == input[mid])
                {
                    return mid;
                }
                else if (key < input[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
