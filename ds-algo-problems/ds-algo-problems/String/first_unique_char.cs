using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    public class first_unique_char
    {
        /*
         * Given a string find the first non-repeating char in it and return its index.
         * if it doesnt exists then return -1
         * 
         * ex. baby
         * result : 1
         */
        public int FirstUniqueChar(string input)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for(int i = 0; i < input.Length; i++)
            {
                if(!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], i);
                }
                else
                {
                    dict[input[i]] = -1;
                }
            }

            var min = int.MaxValue;

            foreach(var item in dict)
            {
                if(item.Value > -1 && item.Value < min)
                {
                    min = item.Value;
                }
            }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
