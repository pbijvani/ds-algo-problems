using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class intersection_between_3_array
    {
        /*
         * Given 3 sorted array find intersection
         */

        public int[] Intersection1(int[] a1, int[] a2, int[] a3)
        {
            int indexA1 = 0;
            int indexA2 = 0;
            int indexA3 = 0;


            List<int> result = new List<int>();
            while(indexA1 < a1.Length && indexA2 < a2.Length && indexA3 < a3.Length)
            {
                var currElem = a1[indexA1];

                bool availableInA2 = false;
                bool availableInA3 = false;
                while (indexA2 < a2.Length && a2[indexA2] <= currElem)
                {
                    if(currElem == a2[indexA2])
                    {
                        availableInA2 = true;
                        indexA2++;
                        break;
                    }
                    else
                        indexA2++;
                }
                while (indexA3 < a3.Length && a3[indexA3] <= currElem)
                {
                    if (currElem == a3[indexA3])
                    {
                        availableInA3 = true;
                        indexA3++;
                        break;
                    }
                    else
                        indexA3++;
                }

                if(availableInA2 && availableInA3)
                {
                    result.Add(currElem);
                }
                indexA1++;
            }

            return result.ToArray();
        }



        // below solutino will work even if its unsorted array
        public int[] intersection(int[] a1, int[] a2, int[] a3)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            foreach(var num in a1)
            {
                if(dict.ContainsKey(num))
                {
                    dict[num][0]++;
                }
                else
                {
                    dict.Add(num, new List<int>() { 1, 0, 0 });
                }
            }

            foreach(var num in a2)
            {
                if(dict.ContainsKey(num))
                {
                    dict[num][1]++;
                }
            }

            foreach (var num in a3)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num][2]++;
                }
            }

            var result = new List<int>();
            foreach(var item in dict)
            {
                int minCount = item.Value.Min();
                if(minCount > 0)
                {
                    for(int i = 0; i < minCount; i++)
                    {
                        result.Add(item.Key);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
