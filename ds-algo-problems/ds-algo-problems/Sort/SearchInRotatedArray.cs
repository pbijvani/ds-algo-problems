using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    public class SearchInRotatedArray
    {
        /*
         * you are given a array which was sorted initially but then rotated few times.
         * You need to search for index of given element
         * 
         * Sol 1 : search sequentially : O(n)
         * 
         * Sol 2 : Search sequentially untill you find element or you find a element where next element is smaller. 
         * then from that element to end of array is sorted array. Apply binary search on 2nd half
         * Worst case complexity : O(N), best case O(k + lon(n-k)) - Where K is times array was rotated
         * 
         * Sol3: Modified binary search
         * 
         * Array1 : 70, 75, 17, 18, 30, 31, 35, 50, 60
         * Arrat2 : 25, 25, 26, 27, 30, 31, 13, 18, 23
         * 
         * mid point is 30 on both array, but 18 is on left in array1 and on right in array2
         * how to figure out if search on left or right?
         * 
         * compare mid point with end points. 
         * Array1 : 70 > 30 .. so 2nd half is sorted and if element belong in 2nd half apply BS on 2nd half
         * Array2 : 25 < 30 : first half is sorted. Apply BS on first half
         * 
         * Exception
         * 30..........30................30
         * we dont know which half it belongs. search both.
         * 
         * 30.............30..............25.. 
         * So we know left half is all 30... search 2nd half
         * 
         * 40..............30..............30
         * so 2nd half is all 30 ..search first half
         * 
         * Runtime: O(log N) if all element unique.
         * O(n) of all element are duplicate. 
         */


        public int Search(int[] array, int element)
        {
            return SearchRec(array, 0, array.Length - 1, element);
        }

        public int SearchRec(int[] array, int left, int right, int target)
        {
            if (left > right) return -1;

            var mid = (left + right) / 2;

            if (array[mid] == target) return mid;

            bool searchLeft = false;
            bool searchRight = false;

            if(array[left] < array[mid] && array[mid] < array[right]) // array is sorted. not rotated
            {
                searchLeft = target <= array[mid];
                searchRight = target > array[mid];
            }
            else if(array[left] < array[mid])
            {
                if(array[left] <= target && target < array[mid])
                {
                    searchLeft = true;
                }
                else
                {
                    searchRight = true;
                }
            }
            else if(array[mid] < array[right])
            {
                if (array[mid] <= target && target <= array[right])
                {
                    searchRight = true;
                }
                else
                {
                    searchLeft = true;
                }
            }
            else if(array[mid] == array[right] && array[mid] == array[left])
            {
                searchLeft = true;
                searchRight = true;
            }
            else if(array[left] == array[mid])
            {
                searchRight = true;
            }
            else if(array[mid] == array[right])
            {
                searchLeft = true;
            }

            var result = searchLeft ? SearchRec(array, left, mid - 1, target) : -1;

            if(result == -1)
            {
                result = searchRight ? SearchRec(array, mid + 1, right, target) : -1;
            }


            return result;
        }

    }
}
