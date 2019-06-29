using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    public class pairs_with_given_sum
    {
        /*
         * design an algo to find all pair of int withing an array
         * which sum to a specific value
         */

        public void FindPairs(int[] input, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach(var num in input)
            {
                var val = sum - num;
                if(!map.ContainsKey(val))
                {
                    map.Add(val, num);
                }
            }

            foreach(var num in input)
            {
                if(map.ContainsKey(num))
                {
                    Console.WriteLine($"{{{num}, {map[num]}}}");
                }
            }
        }

        // This avoides duplicate pair and runs in O(n)
        public void FindPairs2(int[] input, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var num in input)
            {
                var val = sum - num;
                if (!map.ContainsKey(val))
                {
                    map.Add(val, num);
                }


                if (map.ContainsKey(num))
                {
                    Console.WriteLine($"{{{num}, {map[num]}}}");
                    map.Remove(num);
                }

            }

        }

        public void FindPairAlternate(int[] input, int sum)
        {
            System.Array.Sort(input);

            int first = 0;
            int last = input.Length - 1;

            while(first < last)
            {
                int s = input[first] + input[last];

                if(s == sum)
                {
                    Console.WriteLine($"{{{input[first]}, {input[last]}}}");
                    first++;
                    last--;
                }
                else
                {
                    if(s < sum)
                    {
                        first++;
                    }
                    else
                    {
                        last--;
                    }
                }
            }

        }
    }
}
