using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop
{
    /*
        Painting Fence Algorithm
        
        Given a fence with n posts and k colors, 
        find out the number of ways of painting the fence such that at most 2 adjacent posts have the same color. 
        Since answer can be large return it modulo 10^9 + 7.

        Examples:

        Input : n = 2 k = 4
        Output : 16
        We have 4 colors and 2 posts.
        Ways when both posts have same color : 4 
        Ways when both posts have diff color :
        4*(choices for 1st post) * 3(choices for 
        2nd post) = 12

        Input : n = 3 k = 2
        Output : 6
        https://www.geeksforgeeks.org/painting-fence-algorithm/     
     */
    public class paint_fence
    {
        public long CountWays(int n, int k)
        {
            if(n == 0)
            {
                return 0;
            }
            if(n == 1)
            {
                return k;
            }

            long same = 0;
            long diff = 0;
            if (n == 2)
            {
                same = k;
                diff = k * (k - 1);
            }

            for(int i = 3; i <=n; i++)
            {
                var prevDiff = diff;
                diff = (same + diff) * (k - 1);
                same = prevDiff * 1;
            }

            return same + diff;
        }
    }
}
