using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class container_with_most_water
    {
        /*
         * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

            Note: You may not slant the container and n is at least 2.
            Example:

            Input: [1,8,6,2,5,4,8,3,7]
            Output: 49

        https://leetcode.com/problems/container-with-most-water/
         */

        // Sol 1 : Compare wach element with other element. FInd the area and then find max area
        // Its O(N2)

        public void Test()
        {
            var res = ContainerWithMostWater(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        }

        public int ContainerWithMostWater(int[] height)
        {
            var len = height.Length;
            if (len < 2) return 0;

            var left = 0;
            var right = len - 1;
            var maxArea = int.MinValue;

            while(left < right)
            {
                var isLeftShort = height[left] < height[right];
                var area = (right - left) * (isLeftShort ? height[left] : height[right]);
                maxArea = area > maxArea ? area : maxArea;
                if(isLeftShort)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }
    }
}
