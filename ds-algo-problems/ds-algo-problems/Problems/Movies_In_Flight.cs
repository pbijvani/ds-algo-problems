using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class Movies_In_Flight
    {
        /*
    You are on a flight and wanna watch two movies during this flight. 
    You are given int[] movie_duration which includes all the movie durations. 
    You are also given the duration of the flight which is d in minutes. 
    Now, you need to pick two movies and the total duration of the two movies is less than or equal to (d - 30min). 
    Find the pair of movies with the longest total duration. If multiple found, return the pair with the longest movie.

    e.g. 
    Input
    movie_duration: [90, 85, 75, 60, 120, 150, 125]
    d: 250

    Output from aonecode.com
    [90, 125]
    90min + 125min = 215 is the maximum number within 220 (250min - 30min)

 */
        public int GetMoviesToWatch1(int[] movieDuration, int duration)
        {
            int first = movieDuration[0];
            int second = movieDuration[1];

            int maxDurationToWatchMovie = duration - 30;
            int maxDurationSoFar = first + second;

            for (int i = 2; i < movieDuration.Length; i++)
            {
                int durationCase1 = 0;
                int durationCase2 = 0;

                durationCase1 = first + movieDuration[i];
                durationCase2 = second + movieDuration[i];


                var differenceCase1 = maxDurationToWatchMovie - durationCase1;
                var differenceCase2 = maxDurationToWatchMovie - durationCase2;
                var currDifference = maxDurationToWatchMovie - maxDurationSoFar;

                List<Tuple<int, int>> differences = new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(differenceCase1, 1),
                    new Tuple<int, int>(differenceCase2, 2),
                    new Tuple<int, int>(currDifference, 0)
                };


                var choice = differences.Where(x => x.Item1 >= 0).OrderBy(x => x.Item1).FirstOrDefault();

                if (choice == null)
                {
                    choice = differences.OrderByDescending(x => x.Item1).FirstOrDefault();
                }

                if (choice.Item2 == 1)
                {
                    second = movieDuration[i];
                }
                else if (choice.Item2 == 2)
                {
                    first = movieDuration[i];
                }
                else
                    continue;


                maxDurationSoFar = first + second;


            }
            Console.WriteLine($"{first}, {second} = {maxDurationSoFar}");
            return maxDurationSoFar;
        }


        public int GetMoviesToWatch(int[] movieDuration, int duration)
        {


            int first = 0;
            int second = 0;

            if (movieDuration[0] > movieDuration[1])
            {
                first = movieDuration[0];
                second = movieDuration[1];
            }
            else
            {
                first = movieDuration[1];
                second = movieDuration[0];
            }

            int longestMovieDuration = 0;

            if (first + second <= duration - 30)
            {
                longestMovieDuration = first + second;
            }

            for (int i = 2; i < movieDuration.Length; i++)
            {

                int durationCase1 = first + movieDuration[i];
                int durationCase2 = second + movieDuration[i];



                if (durationCase1 > durationCase2 && durationCase1 <= duration - 30 && durationCase1 > longestMovieDuration)
                {
                    second = movieDuration[i];
                }
                else if (durationCase1 > durationCase2 && durationCase2 <= duration - 30 && durationCase2 > longestMovieDuration)
                {
                    first = movieDuration[i];
                }
                else if (durationCase2 > durationCase1 && durationCase2 <= duration - 30 && durationCase2 > longestMovieDuration)
                {
                    first = movieDuration[i];
                }
                else if (durationCase2 > durationCase1 && durationCase1 <= duration - 30 && durationCase1 > longestMovieDuration)
                {
                    second = movieDuration[i];
                }
                else
                    continue;

                if ((first + second) > longestMovieDuration && (first + second) <= duration - 30)
                {
                    longestMovieDuration = first + second;
                }

            }
            return longestMovieDuration;
        }

        private int findBetterDuration(int duration1, int duration2, int maxDurationSoFar, int maxDurationToWatchMovie)
        {
            if (duration1 >= duration2 && duration1 < maxDurationToWatchMovie)
            {
                return 1;
            }
            if (duration1 >= duration2 && duration2 < maxDurationToWatchMovie)
            {
                return 2;
            }
            if (duration2 >= duration1 && duration2 < maxDurationToWatchMovie)
            {
                return 1;
            }
            if (duration2 >= duration1 && duration1 < maxDurationToWatchMovie)
            {
                return 2;
            }
            return 0;
        }

        /*
         * Update on : 9/12/2020
         * Seems above solution might not work for all cases.
         * We can solve it using sorted array and two pointer approach
         * 
         * not tested yet
         * 
         * https://leetcode.com/discuss/interview-question/313719/Amazon-or-Online-Assessment-2019-or-Movies-on-Flight
         * 
         * O (n log n)
         */

        public int[] FindMovies(int[] movies, int d)
        {
            System.Array.Sort(movies);
            var len = movies.Length;
            var left = 0;
            var right = len - 1;

            d = d - 30;

            var maxDuration = 0;
            var i = -1;
            var j = -1;

            while(left < right)
            {
                var sum = movies[left] + movies[right];

                if(sum <= d && (sum > maxDuration || (sum == maxDuration && System.Math.Max(movies[left], movies[right]) > System.Math.Max(movies[i], movies[j]))))
                {
                    maxDuration = sum;
                    i = left;
                    j = right;
                }

                if(sum > d)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return new int[] { i, j };
        }

    }
}
