using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.DynamicPrograming
{
    /*
     * Find Magic Index. A[i] = i 
     */

    public class MagicIndex
    {
        // Magic Index With non duplicate array

        public int MagicIndexNonDupArray(int[] array)
        {
            return MagicIndexNonDupArray(array, 0, array.Length - 1);
        }

        public int MagicIndexNonDupArray(int[] array, int start, int end)
        {
            if (end < start) return -1;

            int midIndex = (start + end) / 2;
            int midVal = array[midIndex];

            if (midVal == midIndex) return midIndex;

            if (midIndex > midVal)
            {
                // look into right

                start = midIndex + 1;
            }
            else
            {
                // look into left
                end = midIndex - 1;
            }

            return MagicIndexNonDupArray(array, start, end);
        }

        public int MagicIndexDuplicate(int[] array)
        {
            return MagicIndexDuplicate(array, 0, array.Length - 1);
        }

        public int MagicIndexDuplicate(int[] array, int start, int end)
        {
            if (end < start) return -1;

            int midIndex = (start + end) / 2;
            int midVal = array[midIndex];

            if (midIndex == midVal)
                return midIndex;

            // Search Left
            int leftIndex = System.Math.Min(midIndex - 1, midVal);
            int left = MagicIndexDuplicate(array, start, leftIndex);
            if (left < 0)
            {
                return left;
            }

            // Search Right
            int rightIndex = System.Math.Max(midIndex + 1, midVal);
            int right = MagicIndexDuplicate(array, rightIndex, end);

            return right;
        }
    }
}
