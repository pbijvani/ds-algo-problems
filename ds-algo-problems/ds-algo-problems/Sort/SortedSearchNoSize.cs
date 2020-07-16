using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class SortedSearchNoSize
    {
        /*
         * you are give a list Listy, which doesnt have method to get number of element
         * you are given method GetELementAt(i) which returns value at index i
         * if i is out of bound it will return -1
         * Listy has positive sorted elements only.
         * 
         * Given x, find the index at which x is placed.
         * 
         * Runtime : O(log N) to find lenghth and then O(log N) for BS
         * so overall runtime is O(log N)
         */
        public int Search(Listy list, int value)
        {
            if (list.GetElementAt(0) == value) return 0;
            var index = 1;
            
            while(list.GetElementAt(index) != -1 && list.GetElementAt(index) < value)
            {
                index = index * 2;
            }

            return BinarySearch(list, index / 2, index, value);
        }

        private int BinarySearch(Listy list, int start, int end, int value)
        {
            if (start > end) return -1;

            var mid = (start + end) / 2;

            var midVal = list.GetElementAt(mid);

            if (midVal == value) return mid;

            if(midVal == -1 || value < midVal) 
            {
                // Search left
                return BinarySearch(list, start, mid - 1, value);
            }
            else
            {
                return BinarySearch(list, mid + 1, end, value);
            }
        }
    }

    public class Listy
    {
        public int GetElementAt(int i)
        {
            return i;
        }
    }
}
