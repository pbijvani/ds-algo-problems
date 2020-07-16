using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class SparseSearch
    {
        /*
         * you are given a sorted array of striing that is interspersed with empty strings
         * "aa", "", "", "bb", "", "", "", "", "", "cc"
         * 
         * write a method to find location of given string
         * 
         * used iterative BS. Can use recursive as well
         * 
         * RunTime : O(log N) : Avg case, O (N) worst case
         * where n is the number of element in array. Not considering cost of string comparision.
         */

        public int FindIndex(string[] array, string val)
        {
            if (array == null || val == null || val == "")
                return -1;

            return FindIndex(array, val, 0, array.Length - 1);
        }

        public int FindIndex(string[] array, string val, int first, int last)
        {
            if (first > last) return -1;

            while(first <= last)
            {
                var mid = (first + last) / 2;

                if(array[mid] == "")
                {
                    mid = GetNearestNonEmptyIndex(array, mid, first, last);

                    if (mid == -1) return mid;
                }

                var midVal = array[mid];

                if(midVal == val)
                {
                    return mid;
                }
                else if(midVal.CompareTo(val) < 0)
                {
                    last = mid - 1;
                }
                else if (midVal.CompareTo(val) < 0)
                {
                    first = mid + 1;
                }

            }

            return -1;
        }

        private int GetNearestNonEmptyIndex(string[] array, int mid, int first, int last)
        {
            var left = mid - 1;
            var right = mid + 1;

            while (true)
            {
                if (left < first && right > last)
                {
                    return -1;
                }
                else if (first <= left && array[left] != "")
                {
                    mid = left;
                    break;
                }
                else if (right <= last && array[right] != "")
                {
                    mid = right;
                    break;
                }
                left--;
                right++;
            }

            return mid;
        }
    }
}
