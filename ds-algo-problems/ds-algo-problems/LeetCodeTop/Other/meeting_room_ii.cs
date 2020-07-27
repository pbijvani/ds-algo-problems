using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    public class meeting_room_ii
    {
        public void Test()
        {
            var arr = new int[][]
            {
                new int[]{0,30 },
                new int[]{5,10 },
                new int[]{15,20 }
            };

            var res = MinMeetingRooms(arr);
        }
        public int MinMeetingRooms(int[][] meetings)
        {
            var sortedMeetings = meetings.OrderBy(x => x[0]);

            var minHeap = new MinHeap();

            int count = 0;

            foreach(var interval in meetings)
            {
                var start = interval[0];
                var end = interval[1];

                if(minHeap.IsEmpty())
                {
                    count++;
                    minHeap.Insert(end);
                }
                else
                {
                    if(start >= minHeap.Peek())
                    {
                        minHeap.Poll();
                    }
                    else
                    {
                        count++;
                    }
                    minHeap.Insert(end);
                }
            }

            return count;
        }
    }
}
