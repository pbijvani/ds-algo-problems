using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class Trapping_Rain_Water
    {
        /*
         * Given n non-negative integers representing an elevation map where the width of each bar is 1, 
         * compute how much water it is able to trap after raining.
         * 
         * Example:

Input: [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
https://leetcode.com/problems/trapping-rain-water/
         */
        public int Trap(int[] height)
        {
            var len = height.Length;
            if (len < 3) return 0;

            var trappedWater = 0;

            var left = 0;
            var right = len - 1;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            while(left < right)
            {
                var shortHeight = height[left] < height[right] ? height[left] : height[right];
                var isLeftShort = height[left] < height[right] ? true : false;

                if(shortHeight > 0)
                    AddToDict(dict, left + 1, right - 1, shortHeight);

                if(isLeftShort)
                {
                    var currLeft = height[left];
                    left++;
                    while(currLeft >= height[left] && left < right)
                    {
                        left++;
                    }
                }
                else
                {
                    var currRight = height[right];
                    right--;
                    while(currRight >= height[right] && left < right)
                    {
                        right--;
                    }
                }
                
            }

            foreach(var item in dict)
            {
                var curr = item.Value - height[item.Key];

                trappedWater = trappedWater + (curr > 0 ? curr : 0);
            }

            return trappedWater;
        }

        private void AddToDict(Dictionary<int, int> dict, int from, int to, int height)
        {
            for(int i = from; i <= to; i++)
            {
                if(dict.ContainsKey(i))
                {
                    dict[i] = height;
                }
                else
                {
                    dict.Add(i, height);
                }
            }
        }

        // O(n) solution
        public int Trap1(int[] height)
        {
            var len = height.Length;
            if (len < 2) return 0;

            var left = 0;
            var right = len - 1;
            var ans = 0;
            var left_max = 0;
            var right_max = 0;
            while(left < right)
            {
                if(height[left] < height[right])
                {
                    if(height[left] >= left_max)
                    {
                        left_max = height[left];
                    }
                    else
                    {
                        ans = ans + left_max - height[left];
                    }
                    left++;
                }
                else
                {
                    if(height[right] > right_max)
                    {
                        right_max = height[right];
                    }
                    else
                    {
                        ans = ans + right_max - height[right];
                    }
                    right--;
                }
            }
            return ans;
        }
    }
}
