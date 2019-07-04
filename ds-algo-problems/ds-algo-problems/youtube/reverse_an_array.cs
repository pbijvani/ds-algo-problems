using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class reverse_an_array
    {

        public int[] Reverse(int[] input)
        {
            var len = input.Length;
            var halfWay = len / 2;

            for(int i = 0; i < halfWay; i++)
            {
                int temp = input[i];
                input[i] = input[len - i - 1];
                input[len - i - 1] = temp;
            }

            return input;
        }

    }
}
