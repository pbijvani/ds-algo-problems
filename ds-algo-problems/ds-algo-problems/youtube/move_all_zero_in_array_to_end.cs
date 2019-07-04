using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class move_all_zero_in_array_to_end
    {
        /*
         * Sol1 : user extra array
         */
        public int[] MoveZerosToEnd(int[] input)
        {
            var result = new int[input.Length];

            int start = 0;
            int end = input.Length - 1;
            foreach(var element in input)
            {
                if(element == 0)
                {
                    result[end] = 0;
                    end--;
                }
                else
                {
                    result[start] = element;
                    start++;
                }                
            }

            return result;
        }

        /*
         * without using extra array. O(n)
         */
        public int[] MoveZerosToEnd1(int[] input)
        {
            int start = 0;
            int index = 0;
            int len = input.Length;
            while(index < len)
            {
                if(input[index] == 0)
                {
                    index++;
                }
                else
                {
                    input[start] = input[index];
                    index++;
                    start++;
                }
            }

            while(start < len)
            {
                input[start] = 0;
                start++;
            }

            return input;
        }
    }
}
