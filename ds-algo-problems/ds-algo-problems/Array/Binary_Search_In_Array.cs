using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class BinarySearchInArray
    {
        public int BinarySearchRecursive(int[] inputArray, int key, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }
            else
            {
                int mid = (startIndex + endIndex) / 2;
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, startIndex, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, endIndex);
                }
            }
        }
        public int BinarySearchIterative(int[] input, int key)
        {
            int startIndex = 0;
            int endIndex = input.Length - 1;

            while (startIndex <= endIndex)
            {
                int mid = (startIndex + endIndex) / 2;

                if (key == input[mid])
                {
                    return mid;
                }
                else if (key < input[mid])
                {
                    endIndex = mid - 1;
                }
                else
                {
                    startIndex = mid + 1;
                }
            }
            return -1;
        }
    }
}
