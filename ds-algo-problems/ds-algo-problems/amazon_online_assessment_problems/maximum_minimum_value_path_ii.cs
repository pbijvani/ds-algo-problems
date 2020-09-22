using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://aonecode.com/path-with-maximum-minimum-value
     * https://www.junhaow.com/lc/problems/heap/1102_path-with-maximum-minimum-value.html
     * https://code.dennyzhang.com/path-with-maximum-minimum-value
             * 
        Given a two 2D integer array, find the max score of a path from the upper left cell to bottom right cell that doesn't visit any of the cells twice. The score of a path is the minimum value in that path.

        For example:

        Input:

        [7,5,3]
        [2,0,9]
        [4,5,9]

        Here are some paths from [0,0] to [2,2] and the minimum value on each path:

        path: 7->2->4->5->9, minimum value on this path: 2

        path: 7->2->0->9->9, minimum value on this path: 0

        path: 7->2->0->5->9, minimum value on this path: 0

        Notice: the path can move all four directions. (not only right and down. ALL FOUR DIRECTIONS)

        Here 7->2->0->5->3->9->9 is also a path, and the minimum value on this path is 0. 

        The path doesn't visit the same cell twice. So 7->2->0->5->3->9->0->5->9 is not a path. 

        In the end the max score(the min value) of all the paths is 3. 

        Output: 3     
     */
    public class maximum_minimum_value_path_ii
    {
        public int MaxMinPathVal(int[,] grid)
        {
            return 0;
        }
    }
}
