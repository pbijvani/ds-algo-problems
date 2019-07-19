using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class insert_interval
    {

        /// <summary>
        /*
        Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

        You may assume that the intervals were initially sorted according to their start times.

        Example 1:

        Given intervals [1,3],[6,9] insert and merge [2,5] would result in [1,5],[6,9].

        Example 2:

        Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] would result in [1,2],[3,10],[12,16].

        This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].


         */
        /// </summary>
        public void TestInsertInterval()
        {
            var input = new List<List<int>>()
            {
                new List<int>(){ 4, 6 },
                new List<int>(){ 9, 11 }
            };

            var res = InsertInterval(input, new Tuple<int, int>(7, 8));

            input = new List<List<int>>()
            {
                new List<int>(){ 4, 6 },
                new List<int>(){ 9, 11 }
            };

            var res1 = InsertInterval(input, new Tuple<int, int>(15, 17));


            input = new List<List<int>>()
            {
                new List<int>(){ 4, 6 },
                new List<int>(){ 9, 11 }
            };

            var res2 = InsertInterval(input, new Tuple<int, int>(5, 8));
        }

        public List<List<int>> InsertInterval(List<List<int>> intervals, Tuple<int, int> interval)
        {

            var curr = interval;

            var i = 0;
            var len = intervals.Count;

            while (i < len)
            {
                if (intervals[i].Last() < curr.Item1) i++;

                else if (intervals[i].First() > curr.Item2)
                {
                    intervals.Insert(i, new List<int>() { curr.Item1, curr.Item2 });
                    break;
                }
                else
                {
                    curr = new Tuple<int, int>(System.Math.Min(curr.Item1, intervals[i].First()), System.Math.Max(curr.Item2, intervals[i].Last()));
                    intervals.RemoveAt(i);
                }
            }

            if (i == len)
            {
                intervals.Insert(i, new List<int>() { curr.Item1, curr.Item2 });
            }

            return intervals;

        }

    }
}
