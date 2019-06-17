using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class MergeSortedArray
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
    }
}
