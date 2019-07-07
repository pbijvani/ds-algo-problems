using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class courses_prerequisite
    {
        private const int gray = 1;
        private const int white = 0;
        private const int black = 2;
        public int[] CourseSchedule(int noOfCourses, int[,] prereq)
        {
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < prereq.GetLength(0); i++)
            {
                if (adjList.ContainsKey(prereq[i, 1]))
                {
                    adjList[prereq[i, 1]].Add(prereq[i, 0]);
                }
                else
                {
                    adjList.Add(prereq[i, 1], new List<int>() { prereq[i, 0] });
                }
            }

            var visited = new int[noOfCourses];
            var order = new List<int>();
            var res = new List<int>();
            var hasCycle = false;
            for (int i = 0; i < noOfCourses; i++)
            {
                if (visited[i] == white)
                {
                    hasCycle = dsfHelper(adjList, visited, i, order);

                    if (hasCycle) break;
                }
            }

            if (hasCycle) return null;
            else
            {
                res.Reverse();
                return res.ToArray();
            }
        }

        public bool dsfHelper(Dictionary<int, List<int>> preReq, int[] visited, int start, List<int> order)
        {
            var hasCycle = false;
            visited[start] = gray;
            if (preReq.ContainsKey(start))
            {
                var list = preReq[start];
                foreach (var node in list)
                {
                    if (visited[node] == white)
                    {
                        hasCycle = dsfHelper(preReq, visited, node, order);

                        if (hasCycle) return true;
                    }
                    if (visited[node] == gray)
                    {
                        return true;
                    }
                }
            }

            visited[start] = black;
            order.Add(start);

            return hasCycle;
        }

        public void Test()
        {
            //var preReq = new int[,] {
            //    {1,0},
            //    {2,0},
            //    {2,1},
            //    {3,1},
            //    {4,1},
            //    {4,2},
            //    {5,1},
            //    {6,5},
            //    {6,4}
            //};
            //int noOfCourse = 7;

            var preReqWithCircularDep = new int[,] {
                {1,0},
                {2,0},
                {2,1},
                {3,1},
                {4,1},
                {4,2},
                {5,1},
                {6,5},
                {6,4},
                //{7,3},
                //{1,7},
                {1,4}
            };
            int noOfCourse = 7;

            var res = CourseSchedule(noOfCourse, preReqWithCircularDep);
        }
    }
}
