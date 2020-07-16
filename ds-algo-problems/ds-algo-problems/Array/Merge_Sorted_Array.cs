using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Merge_Sorted_Array
    {
        /// <summary>
        /// Merge Sorted Array
        /// </summary>
        /// <param name="A"></param>
        /// <param name="m"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        public int[] MergeSortedList(int[] A, int[] B)
        {
            var aLen = A.Length;
            var bLen = B.Length;

            var output = new int[aLen + bLen];

            int aIndex = 0, bIndex = 0, nIndex = 0;
            while (aIndex < aLen && bIndex < bLen)
            {
                if (A[aIndex] < B[bIndex])
                {
                    output[nIndex] = A[aIndex];
                    aIndex++;
                }
                else
                {
                    output[nIndex] = B[bIndex];
                    bIndex++;
                }
                nIndex++;
            }

            while (aIndex < aLen)
            {
                output[nIndex] = A[aIndex];
                aIndex++;
                nIndex++;
            }

            while (bIndex < bLen)
            {
                output[nIndex] = B[bIndex];
                bIndex++;
                nIndex++;
            }

            return output;
        }

        // This is the variation of problmen where arr1 has enough empty space at the end to accomodate arr2.
        // no need to take an extra array
        // Instead of version below where we are first moving arr1 element to end of array, we can just push larger element to end.
        public int[] MergeSortedArray(int[] arr1, int[] arr2, int arr1Len)
        {
            var len1 = arr1Len;
            var len2 = arr2.Length;

            // Shift arr1 to right
            for (int i = len1 + len2 - 1; i >= len2; i--)
            {
                arr1[i] = arr1[i - len2];
            }

            var index1 = len2;
            var index2 = 0;
            var curr = 0;
            while (index1 < len1 + len2 && index2 < len2)
            {
                if (arr1[index1] < arr2[index2])
                {
                    arr1[curr] = arr1[index1];
                    index1++;
                }
                else
                {
                    arr1[curr] = arr2[index2];
                    index2++;
                }
                curr++;
            }

            while (index2 < len2)
            {
                arr1[curr] = arr2[index2];
                index2++;
                curr++;
            }

            return arr1;
        }
    }
}
