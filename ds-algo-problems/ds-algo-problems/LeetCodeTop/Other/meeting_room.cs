using ds_algo_problems.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Other
{
    /*
     given a array meeting time interval determin if a person could attend all meetings

    [0, 30], [5, 10], [15, 20]
    output : false

     */
    public class meeting_room
    {
        public bool CanAttendMeetings(Interval[] intervals)
        {
            var start = new int[intervals.Length];
            var end = new int[intervals.Length];

            for(int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i].Start;
                end[i] = intervals[i].End;
            }

            System.Array.Sort(start);
            System.Array.Sort(end);

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                if(end[i] > start[i+1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

}
