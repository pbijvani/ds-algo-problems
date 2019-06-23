using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class tow_array_min_difference
    {
        // Tow array. min difference (non negative) between element of two array

        // 1. Brute force
        // 2. Sort Both array and trver in O(a+b)
        // 3. Sort one array and then for each element in other array apply binary search in sorted array. 
        // this is better than 2. if one array is smaller in size then other.
        public int MinDiff(int[] a1, int[] a2)
        {
            a1.ToList().Sort();
            a2.ToList().Sort();

            int i = 0;
            int j = 0;
            int minDiff = int.MaxValue;
            while(i < a1.Length && j < a2.Length)
            {
                minDiff = System.Math.Min(minDiff, System.Math.Abs(a1[i] - a2[j]));
                if (a1[i] > a1[j])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return minDiff;
        }
    }
}
