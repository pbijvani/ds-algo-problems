using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class MergeSort
    {
        /*
         * Time Complexity : O(nlogN) avg and worst case
         * Space : O(N) for gelper array used in merge
         */
        public int[] Test()
        {
            var array = new int[] { 1, 5, 3, 2, 8, 7, 6, 4 };
            var helper = new int[array.Length];
            MergeSortHelper(array, helper, 0, array.Length - 1);

            return array;
        }

        public void MergeSortHelper(int[] array, int[] helper, int left, int right)
        {
            if (left < right)
            {
                var middle = left + (right - left) / 2;

                MergeSortHelper(array, helper, left, middle);
                MergeSortHelper(array, helper, middle + 1, right);
                Merge(array, helper, left, middle, right);
            }
        }

        public void Merge(int[] array, int[] helper, int left, int middle, int right)
        {
            for (int i = left; i <= right; i++)
            {
                helper[i] = array[i];
            }

            var helperLeft = left;
            var helperRight = middle + 1;
            var curr = left;

            while (helperLeft <= middle && helperRight <= right)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    array[curr] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[curr] = helper[helperRight];
                    helperRight++;
                }
                curr++;
            }

            int remaining = middle - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                array[curr + i] = helper[helperLeft + i];
            }
        }
    }
}
