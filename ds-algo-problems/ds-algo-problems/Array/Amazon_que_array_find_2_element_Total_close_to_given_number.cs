using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Amazon_que_array_find_2_element_Total_close_to_given_number
    {
        /*

   Solution 1 : this can be solved by first sorting array packagesSpace and then traversing
               array and calculating two adjucent element with total equal or close to truckSpace.
               But for this total time complexity = Time complexity of sort + time complexity of linear traverse.

   Below Implemented Solution: I am maintaing two variable (first and second) which represents two element
   in array having total colse to truckSpace. Now I am traversing array starting index 2 and with each iteration I am checking 
   if current element from array is worth replacing with first or second so that we can get close to truckSpace.
   At the end we end up with two package with space close to truckSpace.

   Time complexity : O(n)
   space complexity; O(n)

   */

        public List<int> IDsOfPackages(int truckSpace, List<int> packagesSpace)
        {
            // Boundry condtion.
            if (truckSpace < 31 || packagesSpace.Count < 3)
            {
                return new List<int>();
            }

            // assign first to first element of array and second to second elemen of array
            int first = packagesSpace[0];
            int second = packagesSpace[1];

            // maintaing index
            int firstIndex = 0;
            int secondIndex = 1;

            // Maximum capacity of truck
            int maxSpaceToOccupy = truckSpace - 30;

            // Space occupied by two packages we loaded so far
            int spcaeLoadedSoFar = first + second;


            // start from index = 2
            for (int i = 2; i < packagesSpace.Count; i++)
            {
                // Try to replace first and second package with package-i
                int spcaeCase1 = first + packagesSpace[i];
                int spcaeCase2 = second + packagesSpace[i];

                // calculating difference from maxSpaceToOccupy. 
                // Any differece close to zero is right candicate to replace.
                int differenceSpaceCase1 = maxSpaceToOccupy - spcaeCase1;
                int differenceSpaceCase2 = maxSpaceToOccupy - spcaeCase2;
                int differenceCurrenLoad = maxSpaceToOccupy - spcaeLoadedSoFar;

                // Below is my logic to calculate if its worth replacing package-i with first or second
                List<Tuple<int, int>> differences = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(differenceSpaceCase1, 1),
                new Tuple<int, int>(differenceSpaceCase2, 2),
                new Tuple<int, int>(differenceCurrenLoad, 0)
            };

                var choice = differences.Where(x => x.Item1 >= 0).OrderBy(x => x.Item1).FirstOrDefault();

                if (choice == null)
                {
                    choice = differences.OrderByDescending(x => x.Item1).FirstOrDefault();
                }

                if (choice.Item2 == 1)
                {
                    second = packagesSpace[i];
                    secondIndex = i;
                }
                else if (choice.Item2 == 2)
                {
                    first = packagesSpace[i];
                    firstIndex = i;
                }
                else
                {
                    continue;
                }
                // calculate space loaded in truck again.
                spcaeLoadedSoFar = first + second;
            }
            //return index of first and second
            return new List<int>() { firstIndex, secondIndex };

        }
    }
}
