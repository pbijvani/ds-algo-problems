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
        /*
         * Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.

For example,

Given [[0, 30],[5, 10],[15, 20]],
return 2.


         */
        public void Test()
        {
            var arr = new int[][]
            {
                new int[]{1,3 },
                new int[]{4,5 },
                new int[]{5,7 },
                new int[]{ 9, 11 },
                new int[]{ 2, 8 },
                new int[]{ 6, 10 }
            };

            var res = MinMeetingRooms(arr);
            var res1 = MinMeetingRooms1(arr);

            var res3 = MinMeetingRooms2(arr);
        }

        //https://www.programcreek.com/2014/05/leetcode-meeting-rooms-ii-java/
        // O (N Log N) ()
        // Space : O(N)
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
        public int MinMeetingRooms1(int[][] meetings)
        {
            var dict = new Dictionary<int, int>();
            foreach(var intv in meetings)
            {
                var start = intv[0];
                var end = intv[1];

                for(int at = start; at < end; at++)
                {
                    if (dict.ContainsKey(at))
                    {
                        dict[at] = dict[at] + 1;
                    }
                    else
                    {
                        dict.Add(at, 1);
                    }
                }
            }
            var count = 0;
            foreach(var item in dict)
            {
                count = item.Value > count ? item.Value : count;
            }

            return count;
        }

        //https://www.jianshu.com/p/28475d91d54b?utm_campaign=maleskine&utm_content=note&utm_medium=seo_notes&utm_source=recommendation
        public int MinMeetingRooms2(int[][] intervals)
        {
            var start = new int[intervals.GetLength(0)];
            var end = new int[intervals.GetLength(0)];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            start = start.OrderBy(x => x).ToArray();
            end = end.OrderBy(x => x).ToArray();

            int room = 0, ptr = 0;

            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] < end[ptr])
                {
                    room++;
                }
                else
                {
                    ptr++;
                }
            }
            return room;

        }
    }
}
